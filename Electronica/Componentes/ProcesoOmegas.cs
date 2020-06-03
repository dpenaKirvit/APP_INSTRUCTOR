using Electronica.Serial;
using Electronica.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Electronica.Componentes
{
    public class ProcesoOmegas
    {
        const string cNombreComponente = "C130_Omegas";
        #region Variables
        private bool estaConectado;
        private bool estaConectado2;
        private bool estaConectado3;

        private Queue<byte> bufferDatos;
        
        private PuertoSerial pSerial;
        private PuertoSerial pSerial2;
        private PuertoSerial pSerial3;
        private PuertoSerial pSerial4;


        private List<byte> tramaActual;
        private List<byte> tramaActual2;
        private List<byte> tramaActual3;
        private List<byte> tramaActual4;

        private VarBoard0x21 varBoard0x21;
        private VarBoard0x22 varBoard0x22;
        private VarBoard0x23 varBoard0x23;
        private VarBoard0x24 varBoard0x24;
        private VarBoard0x25 varBoard0x25;
        private VarBoard0x26 varBoard0x26;
        private VarBoard0x27 varBoard0x27;

        private VarBoard0x2E varBoard0x2E;
        private VarBoard0x2F varBoard0x2F;
        private VarBoard0x30 varBoard0x30;
        private VarBoard0x38 varBoard0x38;

        private VarBoard0x28 varBoard0x28;
        private VarBoard0x29 varBoard0x29;


        private byte[] peticionCambioVariables;
        private byte[] peticionCambioVariables2;
        private byte[] peticionCambioVariables3;

        #endregion Variables

        #region Propiedades
        public bool EstaConectado
        {
            get { return estaConectado; }
        }

        public bool EstaConectado2
        {
            get { return estaConectado2; }
        }
        public bool EstaConectado3
        {
            get { return estaConectado3; }
        }
        public VarBoard0x21 Board0x21 { get => varBoard0x21; }
        public VarBoard0x22 Board0x22 { get => varBoard0x22; }
        public VarBoard0x23 Board0x23 { get => varBoard0x23; }
        public VarBoard0x24 Board0x24 { get => varBoard0x24; }
        public VarBoard0x25 Board0x25 { get => varBoard0x25; }
        public VarBoard0x26 Board0x26 { get => varBoard0x26; }
        public VarBoard0x27 Board0x27 { get => varBoard0x27; }

        public VarBoard0x2E Board0x2E { get => varBoard0x2E; }
        public VarBoard0x2F Board0x2F { get => varBoard0x2F; }
        public VarBoard0x30 Board0x30 { get => varBoard0x30; }
        public VarBoard0x38 Board0x38 { get => varBoard0x38; }

        public VarBoard0x28 Board0x28 { get => varBoard0x28; }
        public VarBoard0x29 Board0x29 { get => varBoard0x29; }

        #endregion Propiedades

        public ProcesoOmegas()
        {
            peticionCambioVariables = Globales.ObtenerPeticion(CodigoBoard.Board0x21, TipoTrama.CambioVariables);
            peticionCambioVariables2 = Globales.ObtenerPeticion(CodigoBoard.Board0x2E, TipoTrama.CambioVariables);
            peticionCambioVariables3 = Globales.ObtenerPeticion(CodigoBoard.Board0x28, TipoTrama.CambioVariables);

            bufferDatos = new Queue<byte>();
            
            pSerial = new PuertoSerial();
            pSerial.Baudios = 115200;
            pSerial.DtrEnable = true;
            pSerial.TiempoEsperaBytes = 200;

            pSerial2 = new PuertoSerial();
            pSerial2.Baudios = 115200;
            pSerial2.DtrEnable = true;
            pSerial2.TiempoEsperaBytes = 200;

            pSerial3 = new PuertoSerial();
            pSerial3.Baudios = 115200;
            pSerial3.DtrEnable = true;
            pSerial3.TiempoEsperaBytes = 200;

            pSerial4 = new PuertoSerial();
            pSerial4.Baudios = 115200;
            pSerial4.DtrEnable = true;
            pSerial4.TiempoEsperaBytes = 200;

            tramaActual = new List<byte>();
            tramaActual2 = new List<byte>();
            tramaActual3 = new List<byte>();
            tramaActual4 = new List<byte>();



            varBoard0x21 = new VarBoard0x21();
            varBoard0x22 = new VarBoard0x22();
            varBoard0x23 = new VarBoard0x23();
            varBoard0x24 = new VarBoard0x24();
            varBoard0x25 = new VarBoard0x25();
            varBoard0x26 = new VarBoard0x26();
            varBoard0x27 = new VarBoard0x27();
            
            varBoard0x2E = new VarBoard0x2E();
            varBoard0x2F = new VarBoard0x2F();
            varBoard0x30 = new VarBoard0x30(); 
            varBoard0x38 = new VarBoard0x38();

            varBoard0x28 = new VarBoard0x28();
            varBoard0x29 = new VarBoard0x29();
        }

        #region Metodos Publicos
        //PUERTO 0
        public void Detectar()
        {
            estaConectado = false;
            foreach (string s in pSerial.ObtenerPuertos())
            {
                if (VerificarPuerto(s))
                {
                    estaConectado = true;
                    break;
                }
            }
        }
        //PUERTO1
        public void Detectar2()
        {
            estaConectado2 = false;
            foreach (string s in pSerial2.ObtenerPuertos())
            {
                if (VerificarPuerto2(s))
                {
                    estaConectado2 = true;
                    break;
                }
            }
        }

        public void Detectar3()
        {
            estaConectado3 = false;
            foreach (string s in pSerial3.ObtenerPuertos())
            {
                if (VerificarPuerto3(s))
                {
                    estaConectado3 = true;
                    break;
                }
            }
        }

        public void Abrir()
        {
            pSerial.Abrir();
            pSerial2.Abrir();
            pSerial3.Abrir();
            //pSerial4.Abrir();
        }

        public void Cerrar()
        {            
            pSerial.Cerrar();
            pSerial2.Cerrar();
            pSerial3.Cerrar();
            //pSerial4.Cerrar();
        }


        //PUERTO 0
        public void Procesar()
        {            
            try
            {
               LeerDatos(peticionCambioVariables, 30);
               Thread.Sleep(200);
            }
            catch (Exception ex)
            {
            }
        }


        public void Procesar2()
        {
            try
            {
                LeerDatos2(peticionCambioVariables2, 30);
                Thread.Sleep(200);
                // LeerDatos2(peticionCambioVariables2, 30);

            }
            catch (Exception ex)
            {
            }
        }
        public void Procesar3()
        {
            try
            {
                LeerDatos3(peticionCambioVariables3, 30);
                Thread.Sleep(200);
                // LeerDatos2(peticionCambioVariables2, 30);

            }
            catch (Exception ex)
            {
            }
        }

        //PUERTO 0
        public void Escribir()
        {            
            int tmpEspera = 20;
            try
            {
                byte[] datos = varBoard0x21.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
                datos = varBoard0x22.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
                datos = varBoard0x23.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
                datos = varBoard0x24.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
                datos = varBoard0x25.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
                datos = varBoard0x26.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
                datos = varBoard0x27.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial.EscribirPuerto(datos);
                }
            }
            catch (Exception ex)
            {
            }
        }


        public void Escribir2()
        {
            int tmpEspera = 20;
            try
            {
                byte[] datos = varBoard0x2E.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial2.EscribirPuerto(datos);
                }
                datos = varBoard0x2F.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial2.EscribirPuerto(datos);
                }
                datos = varBoard0x30.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial2.EscribirPuerto(datos);
                }
                datos = varBoard0x38.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial2.EscribirPuerto(datos);
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        public void Escribir3()
        {
            int tmpEspera = 20;
            try
            {
                byte[] datos = varBoard0x28.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial3.EscribirPuerto(datos);
                }
                datos = varBoard0x29.Escribir();
                if (datos.Length > 6)
                {
                    Thread.Sleep(tmpEspera);
                    pSerial3.EscribirPuerto(datos);
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Metodos Publicos

        #region Metodos Privados
        //PUERTO 0
        private bool VerificarPuerto(string nomPuerto)
        {
            try
            {
                pSerial.NombrePuerto = nomPuerto;
                pSerial.Abrir();

                int tmpEspera = 100;
                
                byte[] datos = pSerial.LeerBufferPuerto(varBoard0x21.SolicitudEstado, tmpEspera);
                
                
                bool ok = ValidarRespuestaSolicitud(datos);
                if (ok)
                {
                    //Actualiza el estado de las variables de las otras boards
                    LeerDatos(varBoard0x22.SolicitudEstado, tmpEspera);
                    LeerDatos(varBoard0x23.SolicitudEstado, tmpEspera);
                    LeerDatos(varBoard0x24.SolicitudEstado, tmpEspera);
                    LeerDatos(varBoard0x25.SolicitudEstado, tmpEspera);
                    LeerDatos(varBoard0x26.SolicitudEstado, tmpEspera);
                    LeerDatos(varBoard0x27.SolicitudEstado, tmpEspera);
                }
                return ok;
            }
            catch
            {
                return false;
            }
            finally
            {
                pSerial.Cerrar();
            }
        }


        //PUERTO 1
        private bool VerificarPuerto2(string nomPuerto)
        {
            try
            {
                pSerial2.NombrePuerto = nomPuerto;
                pSerial2.Abrir();

                int tmpEspera = 100;

                byte[] datos = pSerial2.LeerBufferPuerto(varBoard0x2E.SolicitudEstado, tmpEspera);


                bool ok = ValidarRespuestaSolicitud2(datos);
                if (ok)
                {
                    //Actualiza el estado de las variables de las otras boards
                   
                    LeerDatos2(varBoard0x2F.SolicitudEstado, tmpEspera);
                    LeerDatos2(varBoard0x30.SolicitudEstado, tmpEspera);
                    LeerDatos2(varBoard0x38.SolicitudEstado, tmpEspera);
                   
                }
                return ok;
            }
            catch
            {
                return false;
            }
            finally
            {
                pSerial2.Cerrar();
            }
        }

        private bool VerificarPuerto3(string nomPuerto)
        {
            try
            {
                pSerial3.NombrePuerto = nomPuerto;
                pSerial3.Abrir();

                int tmpEspera = 100;

                byte[] datos = pSerial3.LeerBufferPuerto(varBoard0x28.SolicitudEstado, tmpEspera);


                bool ok = ValidarRespuestaSolicitud3(datos);
                if (ok)
                {
                    //Actualiza el estado de las variables de las otras boards
                    
                    LeerDatos3(varBoard0x29.SolicitudEstado, tmpEspera);
                    

                }
                return ok;
            }
            catch
            {
                return false;
            }
            finally
            {
                pSerial3.Cerrar();
            }
        }

        //PUERTO 0
        private bool ValidarRespuestaSolicitud(byte[] datos)
        {
            foreach (byte b in datos)
            {
                bufferDatos.Enqueue(b);
            }

            Queue<byte[]> tramas = BuscarTramas();

            if (datos.Length <= 6)
            {
                return false;
            }            
            byte[] t = tramas.Peek();
            if (t[0] != (byte)TipoByte.STX)
            {
                return false;
            }
            if (t[1] != (byte)CodigoBoard.Board0x21)
            {
                return false;
            }
            if (t[2] != (byte)TipoTrama.SolicitudEstado)
            {
                return false;
            }
            if (t[t.Length - 1] != (byte)TipoByte.ETX)
            {
                return false;
            }
            if (!Globales.ValidarDigitoChequeo(t))
            {
                return false;
            }

            //Procesa las variables
            ProcesarTrama(tramas);  //MFMR PENDIENTE DEFINIR SI ES UNA O DOS
            return true;
        }
        //PUERTO 0


        //puerto1
        private bool ValidarRespuestaSolicitud2(byte[] datos)
        {
            foreach (byte b in datos)
            {
                bufferDatos.Enqueue(b);
            }

            Queue<byte[]> tramas = BuscarTramas2();

            if (datos.Length <= 6)
            {
                return false;
            }
            byte[] t = tramas.Peek();
            if (t[0] != (byte)TipoByte.STX)
            {
                return false;
            }
            if (t[1] != (byte)CodigoBoard.Board0x2E)
            {
                return false;
            }
            if (t[2] != (byte)TipoTrama.SolicitudEstado)
            {
                return false;
            }
            if (t[t.Length - 1] != (byte)TipoByte.ETX)
            {
                return false;
            }
            if (!Globales.ValidarDigitoChequeo(t))
            {
                return false;
            }

            //Procesa las variables
            ProcesarTrama2(tramas);  //MFMR PENDIENTE DEFINIR SI ES UNA O DOS
            return true;
        }

        private bool ValidarRespuestaSolicitud3(byte[] datos)
        {
            foreach (byte b in datos)
            {
                bufferDatos.Enqueue(b);
            }

            Queue<byte[]> tramas = BuscarTramas3();

            if (datos.Length <= 6)
            {
                return false;
            }
            byte[] t = tramas.Peek();
            if (t[0] != (byte)TipoByte.STX)
            {
                return false;
            }
            if (t[1] != (byte)CodigoBoard.Board0x28)
            {
                return false;
            }
            if (t[2] != (byte)TipoTrama.SolicitudEstado)
            {
                return false;
            }
            if (t[t.Length - 1] != (byte)TipoByte.ETX)
            {
                return false;
            }
            if (!Globales.ValidarDigitoChequeo(t))
            {
                return false;
            }

            //Procesa las variables
            ProcesarTrama3(tramas);  //MFMR PENDIENTE DEFINIR SI ES UNA O DOS
            return true;
        }


        private Queue<byte[]> BuscarTramas()
        {
            Queue<byte[]> tramas = new Queue<byte[]>();
            if (bufferDatos != null)
            {
                while (bufferDatos.Count > 0)
                {
                    byte b = bufferDatos.Dequeue();
                    if (tramaActual.Count == 0)
                    {
                        if (b == (byte)TipoByte.STX)
                        {
                            tramaActual.Add(b);
                        }
                    }
                    else
                    {
                        tramaActual.Add(b);
                        if (b == (byte)TipoByte.ETX)
                        {
                            if (tramaActual.Count > 6)
                            {
                                byte[] t = tramaActual.ToArray();
                                if (Globales.ValidarDigitoChequeo(t))
                                {
                                    tramas.Enqueue(t);
                                }
                            }
                            tramaActual.Clear();
                        }
                    }
                }
            }
            return tramas;
        }

//puerto 2
        private Queue<byte[]> BuscarTramas2()
        {
            Queue<byte[]> tramas = new Queue<byte[]>();
            if (bufferDatos != null)
            {
                while (bufferDatos.Count > 0)
                {
                    byte b = bufferDatos.Dequeue();
                    if (tramaActual2.Count == 0)
                    {
                        if (b == (byte)TipoByte.STX)
                        {
                            tramaActual2.Add(b);
                        }
                    }
                    else
                    {
                        tramaActual2.Add(b);
                        if (b == (byte)TipoByte.ETX)
                        {
                            if (tramaActual2.Count > 6)
                            {
                                byte[] t = tramaActual2.ToArray();
                                if (Globales.ValidarDigitoChequeo(t))
                                {
                                    tramas.Enqueue(t);
                                }
                            }
                            tramaActual2.Clear();
                        }
                    }
                }
            }
            return tramas;
        }

        private Queue<byte[]> BuscarTramas3()
        {
            Queue<byte[]> tramas = new Queue<byte[]>();
            if (bufferDatos != null)
            {
                while (bufferDatos.Count > 0)
                {
                    byte b = bufferDatos.Dequeue();
                    if (tramaActual3.Count == 0)
                    {
                        if (b == (byte)TipoByte.STX)
                        {
                            tramaActual3.Add(b);
                        }
                    }
                    else
                    {
                        tramaActual3.Add(b);
                        if (b == (byte)TipoByte.ETX)
                        {
                            if (tramaActual3.Count > 6)
                            {
                                byte[] t = tramaActual3.ToArray();
                                if (Globales.ValidarDigitoChequeo(t))
                                {
                                    tramas.Enqueue(t);
                                }
                            }
                            tramaActual3.Clear();
                        }
                    }
                }
            }
            return tramas;
        }


        //PUERTO 0
        private void ProcesarTrama(Queue<byte[]> tramas)
        {
            //Inicializa las variables
            while (tramas.Count > 0)
            {
                byte[] trama = tramas.Dequeue();
                //Procesa cada una de las tramas en los componentes
                if (trama[2] == (byte)TipoTrama.CambioVariables || trama[2] == (byte)TipoTrama.SolicitudEstado)
                {
                    switch (trama[1])
                    {
                        case (byte)CodigoBoard.Board0x21:
                            varBoard0x21.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x22:
                            varBoard0x22.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x23:
                            varBoard0x23.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x24:
                            varBoard0x24.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x25:
                            varBoard0x25.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x26:
                            varBoard0x26.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x27:
                            varBoard0x27.Procesar(Globales.SepararVariables(trama));
                            break;
                    }
                }
            }
        }
        


        //puerto1

        private void ProcesarTrama2(Queue<byte[]> tramas)
        {
            //Inicializa las variables
            while (tramas.Count > 0)
            {
                byte[] trama = tramas.Dequeue();
                //Procesa cada una de las tramas en los componentes
                if (trama[2] == (byte)TipoTrama.CambioVariables || trama[2] == (byte)TipoTrama.SolicitudEstado)
                {
                    switch (trama[1])
                    {
                        case (byte)CodigoBoard.Board0x2E:
                            varBoard0x2E.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x2F:
                            varBoard0x2F.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x30:
                            varBoard0x30.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x38:
                            varBoard0x38.Procesar(Globales.SepararVariables(trama));
                            break;
                        
                    }
                }
            }
        }

        private void ProcesarTrama3(Queue<byte[]> tramas)
        {
            //Inicializa las variables
            while (tramas.Count > 0)
            {
                byte[] trama = tramas.Dequeue();
                //Procesa cada una de las tramas en los componentes
                if (trama[2] == (byte)TipoTrama.CambioVariables || trama[2] == (byte)TipoTrama.SolicitudEstado)
                {
                    switch (trama[1])
                    {
                        case (byte)CodigoBoard.Board0x28:
                            varBoard0x28.Procesar(Globales.SepararVariables(trama));
                            break;
                        case (byte)CodigoBoard.Board0x29:
                            varBoard0x29.Procesar(Globales.SepararVariables(trama));
                            break;
                        
                    }
                }
            }
        }


        //PUERTO 0
        private void LeerDatos(byte[] pet, int msEspera)
        {
            byte[] datos = pSerial.LeerBufferPuerto(pet, msEspera);
            foreach (byte b in datos)
            {
                bufferDatos.Enqueue(b);
            }
            Queue<byte[]> tramas = BuscarTramas();
            ProcesarTrama(tramas);
        }

        //puerto1
        private void LeerDatos2(byte[] pet, int msEspera)
        {
            byte[] datos = pSerial2.LeerBufferPuerto(pet, msEspera);
            foreach (byte b in datos)
            {
                bufferDatos.Enqueue(b);
            }
            Queue<byte[]> tramas = BuscarTramas2();
            ProcesarTrama2(tramas);
        }
        private void LeerDatos3(byte[] pet, int msEspera)
        {
            byte[] datos = pSerial3.LeerBufferPuerto(pet, msEspera);
            foreach (byte b in datos)
            {
                bufferDatos.Enqueue(b);
            }
            Queue<byte[]> tramas = BuscarTramas3();
            ProcesarTrama3(tramas);
        }


        #endregion Metodos Privados

        #region Eventos
        private void pSerial_DatosRecibidos(object sender, byte[] datos)
        {
            if (datos != null)
            {
                foreach (byte b in datos)
                {
                    try
                    {
                        bufferDatos.Enqueue(b);
                    }
                    catch (Exception ex)
                    {                        
                    }
                }
            }
        }
        #endregion Eventos
    }
}
