using System;
using System.Data;
using System.IO;

namespace Electronica.Simulacion
{
    /// <summary>
    /// Carga un archivo XML EsquemaCalibracion y lo procesa.
    /// </summary>
    public class Calibracion
    {
        private DataView vista;
        private double entrada, entradaAnt;
        private double salida;
        private int difCambio;

        public string ArchivoXml { get; set; }

        public int DiferenciaCambio
        {
            get { return difCambio; }
            set { difCambio = value; }
        }
        public double Entrada
        {
            get { return entrada; }
        }
        public double Salida
        {
            get { return salida; }
        }
        public Calibracion()
        {
            EsquemaCalibracion datosXml = new EsquemaCalibracion();
            vista = datosXml.Calibracion.DefaultView;
            vista.Sort = "Entrada";

            difCambio = 3;
        }
        public Calibracion(int diferenciaCambio)
        {
            EsquemaCalibracion datosXml = new EsquemaCalibracion();
            vista = datosXml.Calibracion.DefaultView;
            vista.Sort = "Entrada";

            if (diferenciaCambio < 0)
            {
                diferenciaCambio = 0;
            }
            difCambio = diferenciaCambio;
        }
        public string ObtenerPuntosString()
        {
            try
            {
                string puntos = string.Empty;
                foreach (EsquemaCalibracion.CalibracionRow fila in vista.Table.Rows)
                {
                    puntos += fila.Punto + "|" + fila.Entrada + "|" + fila.Salida + "#";
                }
                return puntos;
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Cargar la calibracion desde un archivo XML
        /// </summary>
        /// <param name="NombreArchivo">Ruta y nombre del archivo XML</param>
        public void Abrir(string archivoXML)
        {
            try
            {
                EsquemaCalibracion datosXml = new EsquemaCalibracion();
                datosXml.ReadXml(archivoXML);
                this.ArchivoXml = archivoXML;
                vista = datosXml.Tables["Calibracion"].DefaultView;
                vista.Sort = "Entrada";
                datosXml.Dispose();
            }
            catch (IOException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Guarda los valores en el archivo asignado por la propiedad ArchivoXml
        /// </summary>
        public void Guardar()
        {
            try
            {
                EsquemaCalibracion datos = (EsquemaCalibracion)vista.Table.DataSet;
                datos.WriteXml(ArchivoXml);
                datos.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Guarda nuevos valores para la calibracion buscado los punto limites y dandole una holgura
        /// </summary>
        /// <param name="ArchivoXML">Ruta donde se va ha grabar el archivo XML</param>
        public void Guardar(string ArchivoXML)
        {
            try
            {
                EsquemaCalibracion datos = (EsquemaCalibracion)vista.Table.DataSet;
                datos.WriteXml(ArchivoXML);
                datos.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca un punto, edita la entrada y la salida, si este no existe crea el punto
        /// </summary>
        /// <param name="Punto">Punto a buscar</param>
        /// <param name="Entrada">Entrada para el punto</param>
        /// <param name="Salida">Salida para el punto</param>
        public void ProcesarPunto(int Punto, double Entrada, double Salida)
        {
            EsquemaCalibracion datos = (EsquemaCalibracion)vista.Table.DataSet;
            EsquemaCalibracion.CalibracionRow[] fila = (EsquemaCalibracion.CalibracionRow[])datos.Calibracion.Select("Punto = " + Punto);
            if (fila.Length > 0)
            {
                fila[0].BeginEdit();
                fila[0].Entrada = Entrada;
                fila[0].Salida = Salida;
                fila[0].EndEdit();
            }
            else
            {
                datos.Calibracion.AddCalibracionRow(Punto, Entrada, Salida);
            }
            datos.AcceptChanges();
            datos.Dispose();
        }
        /// <summary>
        /// Procesa un valor de entrada y retorna el valor de salida correspondiente
        /// </summary>
        /// <param name="valor">Valor de entrada</param>
        /// <returns>Valor de salida representativo a la entrada</returns>
        public double ProcesarValor(double valor)
        {
            entrada = valor;
            if (Math.Abs(entrada - entradaAnt) >= difCambio)
            {
                salida = ObtenerValor(entrada);
                entradaAnt = entrada;
            }
            return salida;
        }
        /// <summary>
        /// Devuelve el valor de salida correspondiente al valor de entrada dado según los datos de calibración
        /// </summary>
        /// <param name="Entrada">Valor o entrada que se debe prosesar</param>
        /// <returns>Valor o salida resultante</returns>
        private double ObtenerValor(double Entrada)
        {
            double salida = 0;
            if (vista.Count > 0)
            {
                if (Entrada <= (double)vista[0]["Entrada"])
                {
                    salida = (double)vista[0]["Salida"];
                }
                else if (Entrada >= (double)vista[vista.Count - 1]["Entrada"])
                {
                    salida = (double)vista[vista.Count - 1]["Salida"];
                }
                else
                {
                    for (int i = 1; i < vista.Count; i++)
                    {
                        if (Entrada <= (double)vista[i]["Entrada"])
                        {
                            salida = ObtenerSalida((double)vista[i]["Entrada"], (double)vista[i]["Salida"],
                                (double)vista[i - 1]["Entrada"], (double)vista[i - 1]["Salida"], Entrada);
                            break;
                        }
                    }
                }
            }
            return salida;
        }

        /// <summary>
        /// Actualiza los puntos extremos de la configuración
        /// </summary>
        /// <param name="datos">Puntos de calibración</param>
        /// <param name="enEntrada">indica si la actualización se aplica a los valores de entrada o de salida</param>
        /// <param name="holgura">Valor para la actualización</param>
        public void ActualizarPuntosExtremos(bool enEntrada, int holgura)
        {
            EsquemaCalibracion datos = (EsquemaCalibracion)vista.Table.DataSet;
            double inicial = 0;
            double final = 0;
            if (enEntrada == true)
            {
                inicial = datos.Calibracion[0].Entrada;
                final = datos.Calibracion[datos.Calibracion.Rows.Count - 1].Entrada;
            }
            else
            {
                inicial = datos.Calibracion[0].Salida;
                final = datos.Calibracion[datos.Calibracion.Rows.Count - 1].Salida;
            }

            holgura = ObtenerHolgura(enEntrada, holgura);

            if (enEntrada == true)
            {
                datos.Calibracion[0].Entrada = inicial + holgura;
                datos.Calibracion[datos.Calibracion.Rows.Count - 1].Entrada = final - holgura;
            }
            else
            {
                datos.Calibracion[0].Salida = inicial + holgura;
                datos.Calibracion[datos.Calibracion.Rows.Count - 1].Salida = final - holgura;
            }
            ActualizarPuntosCero(enEntrada, holgura);
        }

        private void ActualizarPuntosCero(bool enEntrada, int holgura)
        {
            EsquemaCalibracion datos = (EsquemaCalibracion)vista.Table.DataSet;
            for (int i = 0; i < datos.Calibracion.Rows.Count - 1; i++)
            {
                EsquemaCalibracion.CalibracionRow fila1 = datos.Calibracion[i];
                EsquemaCalibracion.CalibracionRow fila2 = datos.Calibracion[i + 1];
                if (enEntrada == true)
                {
                    if (fila1.Salida == fila2.Salida)
                    {
                        fila1.Entrada -= holgura;
                        fila2.Entrada += holgura;
                    }
                }
                else
                {
                    if (fila1.Entrada == fila2.Entrada)
                    {
                        fila1.Salida -= holgura;
                        fila2.Salida += holgura;
                    }
                }
            }
        }


        private int ObtenerHolgura(bool enEntrada, int holgura)
        {
            EsquemaCalibracion datos = (EsquemaCalibracion)vista.Table.DataSet;
            double inicial = 0;
            double final = 0;
            if (enEntrada == true)
            {
                inicial = datos.Calibracion[0].Entrada;
                final = datos.Calibracion[datos.Calibracion.Rows.Count - 1].Entrada;
            }
            else
            {
                inicial = datos.Calibracion[0].Salida;
                final = datos.Calibracion[datos.Calibracion.Rows.Count - 1].Salida;
            }

            if (inicial < final)
            {
                return holgura;
            }
            else
            {
                return -holgura;
            }
        }

        /// <summary>
        /// Obtiene la salida de un valor de entrada dado dos puntos
        /// </summary>
        /// <param name="Px1">Valor del punto de entrada 1</param>
        /// <param name="Py1">Valor del punto de salida 1</param>
        /// <param name="Px2">Valor del punto de entrada 2</param>
        /// <param name="Py2">Valor del punto de salida 2</param>
        /// <param name="Entrada">valor de entrada</param>
        /// <returns>Obtiene la salida</returns>
        private double ObtenerSalida(double Px1, double Py1, double Px2, double Py2, double Entrada)
        {
            double salida = 0, m = 0, b = 0;
            m = (Py1 - Py2) / (Px1 - Px2);
            b = Py1 - (m * Px1);
            salida = (m * Entrada) + b;
            return salida;
        }

        public string GuardarZephyrus(string msg, bool enEntrada, int holgura)
        {
            try
            {
                string[] puntos = msg.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in puntos)
                {
                    string[] valor = s.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    if (valor.Length == 3)
                    {
                        this.ProcesarPunto(int.Parse(valor[0]), double.Parse(valor[1]), double.Parse(valor[2]));
                    }
                }

                this.ActualizarPuntosExtremos(enEntrada, holgura);
                this.Guardar();
                return "Calibracion=Guardada";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
