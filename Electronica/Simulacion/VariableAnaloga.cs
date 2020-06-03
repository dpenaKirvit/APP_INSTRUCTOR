using System.IO;

namespace Electronica.Simulacion
{
    public class VariableAnaloga : IVariableHardware
    {
        #region Variables
        private double valorAnt;
        #endregion

        #region Propiedades
        public bool ModoCalibracion { get; set; }
        public bool erase;

        public double Valor
        {
            get
            {
                return calibracion.Salida;
            }
            set
            {
                calibracion.ProcesarValor(value);
                erase = true;
            }
        }

        public double ValorEntrada
        {
            get { return Calibracion.Entrada; }
        }

        private Calibracion calibracion;
        public Calibracion Calibracion
        {
            get { return calibracion; }
        }

        private double valorSinProcesar;
        public double ValorSinProcesar
        {
            get { return valorSinProcesar; }
            set { valorSinProcesar = value; }
        }
        #endregion Propiedades

        #region Constructores
        public VariableAnaloga(string archivo, int difCambio)
        {
            calibracion = new Calibracion(difCambio);

            if (!File.Exists(archivo))
            {
                CrearArchivo(archivo);
            }

            calibracion.Abrir(archivo);
        }

        private void CrearArchivo(string archivo)
        {
            string contenido =
@"<?xml version=""1.0"" standalone=""yes""?>
<EsquemaCalibracion xmlns=""http://tempuri.org/EsquemaCalibracion.xsd"">
  <Calibracion>
    <Punto>1</Punto>
    <Entrada>0</Entrada>
    <Salida>0</Salida>
  </Calibracion>
  <Calibracion>
    <Punto>2</Punto>
    <Entrada>500</Entrada>
    <Salida>500</Salida>
  </Calibracion>
  <Calibracion>
    <Punto>3</Punto>
    <Entrada>1000</Entrada>
    <Salida>1000</Salida>
  </Calibracion>
</EsquemaCalibracion>";

            using (StreamWriter stream = File.CreateText(archivo))
            {
                stream.Write(contenido);
                stream.Flush();
            }
        }
        #endregion

        #region Miembros de IVariableHardware
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PosicionTrama { get; set; }

        public bool CambioVariable
        {
            get
            {
                if (ModoCalibracion)
                {
                    if (!valorSinProcesar.Equals(valorAnt))
                    {
                        valorAnt = valorSinProcesar;
                        return true;
                    }
                }
                else
                {
                    if (!calibracion.Salida.Equals(valorAnt))
                    {
                        valorAnt = calibracion.Salida;
                        return true;
                    }
                }
                return false;
            }
        }
        #endregion
    }
}
