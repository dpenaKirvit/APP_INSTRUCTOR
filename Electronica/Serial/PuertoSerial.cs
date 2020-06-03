using System;
using System.IO.Ports;
using System.Threading;


namespace Electronica.Serial
{
    public delegate void DatosRecibidosEventHandle(object sender, byte[] datos);

    public class PuertoSerial
    {
        public event DatosRecibidosEventHandle DatosRecibidos;
        
        private SerialPort puerto;
        private bool bufferHabilitado;
        
        #region Propiedades
        public int TiempoEsperaBytes { get; set; }

        public string NombrePuerto
        {
            get
            {
                return puerto.PortName;
            }
            set
            {
                puerto.PortName = value;
            }
        }

        public int Baudios
        {
            get
            {
                return puerto.BaudRate;
            }
            set
            {
                puerto.BaudRate = value;
            }
        }

        public int TiempoEsperaLectura
        {
            get
            {
                return puerto.ReadTimeout;
            }
            set
            {
                puerto.ReadTimeout = value;
            }
        }

        public int TiempoEsperaEscritura
        {
            get
            {
                return puerto.WriteTimeout;
            }
            set
            {
                puerto.WriteTimeout = value;
            }
        }

        public bool DtrEnable
        {
            set
            {
                puerto.DtrEnable = value;
            }
            get
            {
                return puerto.DtrEnable;
            }
        }

        public bool RtsEnable
        {
            set
            {
                puerto.RtsEnable = value;
            }
            get
            {
                return puerto.RtsEnable;
            }
        }

        public bool EstaAbierto
        {
            get
            {
                return puerto.IsOpen;
            }
        }

        /// <summary>
        /// Indica si el puerto maneja buffer para la recepción de datos
        /// </summary>
        public bool BufferHabilitado
        {
            get { return bufferHabilitado; }
            set
            {
                if (value)
                {
                    if (bufferHabilitado == false)
                    {
                        puerto.DataReceived += new SerialDataReceivedEventHandler(puerto_DataReceived);
                    }
                }
                else
                {
                    if (bufferHabilitado == true)
                    {
                        puerto.DataReceived -= puerto_DataReceived;
                    }
                }
                bufferHabilitado = value;
            }
        }
        #endregion Propiedades

        public PuertoSerial()
        {
            puerto = new SerialPort();
            this.TiempoEsperaLectura = 200;
            this.TiempoEsperaEscritura = 200;
            this.TiempoEsperaBytes = 50;
        }

        public void Abrir()
        {
            try
            {
                //Verifica que el puerto asignado este en el sistema
                bool esta = false;
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (s == this.NombrePuerto)
                    {
                        esta = true;
                        break;
                    }
                }

                if (!esta)
                {
                    throw new Exception("El nombre del puerto no se encuentra en el sistema");
                }

                if (puerto.IsOpen == false)
                {
                    puerto.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Cierra el puerto
        /// </summary>
        public void Cerrar()
        {
            puerto.Close();
        }

        /// <summary>
        /// Obtiene los puertos del sistema
        /// </summary>
        /// <returns></returns>
        public string[] ObtenerPuertos()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// Escribe en el puerto, espera x milisegundos y Lee el buffer del puerto
        /// </summary>
        /// <param name="peticion">Datos que el hardware espera para responder</param>
        /// <returns>Datos leidos del buffer</returns>
        public byte[] LeerBufferPuerto(byte[] peticion, int esperarMs)
        {
            byte[] datos = new byte[0];
            DateTime tiempo = DateTime.Now;
            try
            {
                puerto.Write(peticion, 0, peticion.Length);
                //Espera X milisegundos para que el puerto responda (por defecto está en 5 msg)
                Thread.Sleep(esperarMs);

                if (puerto.BytesToRead > 0)
                {
                    datos = new byte[puerto.BytesToRead];
                    puerto.Read(datos, 0, datos.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return datos;
        }

        /// <summary>
        /// Lee el puerto enviando una petición y lee una cantidad de bytes especifica
        /// </summary>
        /// <param name="peticion">Datos que el hardware espera para responder</param>
        /// <param name="cantidad">Cantidad de bytes a leer del buffer</param>
        /// <returns>Datos leidos del buffer</returns>
        public byte[] LeerPuerto(byte[] peticion, int cantidad)
        {
            byte[] datos = new byte[cantidad];
            try
            {
                puerto.Write(peticion, 0, peticion.Length);
                DateTime dt = DateTime.Now;
                bool tiempoExcedido = false;
                while (puerto.BytesToRead < cantidad)
                {
                    TimeSpan tmr = DateTime.Now - dt;
                    Thread.Sleep(15);
                    if (tmr.Milliseconds > TiempoEsperaBytes)
                    {
                        tiempoExcedido = true;
                        break;
                    }
                }
                if (tiempoExcedido == true)
                {
                    datos = null;
                    throw new Exception("No se ha podido leer el dispositivo. El tiempo de lectura ha sido excedido");
                }
                else
                {
                    puerto.Read(datos, 0, datos.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return datos;
        }

        public void EscribirPuerto(byte[] datos)
        {
            try
            {
                if (datos.Length > 0)
                {
                    puerto.Write(datos, 0, datos.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Escribe en el puerto y retorna una trama de verificación
        /// </summary>
        /// <param name="datos"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public byte[] EscribirPuerto(byte[] datos, int cantidad)
        {
            try
            {
                return LeerPuerto(datos, cantidad);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LimpiarBuffers()
        {
            puerto.DiscardOutBuffer();
            puerto.DiscardInBuffer();
        }

        private void puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (puerto.BytesToRead > 0)
            {
                byte[] datos = new byte[puerto.BytesToRead];
                puerto.Read(datos, 0, datos.Length);
                if (DatosRecibidos != null)
                {
                    DatosRecibidos(this, datos);
                }
            }
        }
    }
}
