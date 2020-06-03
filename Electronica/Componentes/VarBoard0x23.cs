using Electronica.Simulacion;
using System.Collections.Generic;
using System.Linq;

namespace Electronica.Componentes
{
    public partial class VarBoard0x23
    {
        #region Propiedades y Variables
        private List<IVariableHardware> variablesLectura;
        private List<IVariableHardware> variablesEscritura;

        private byte[] solicitudEstado;
        public byte[] SolicitudEstado
        {
            get { return solicitudEstado; }
        }
        #endregion

        #region Constructores
        public VarBoard0x23()
        {
            variablesLectura = new List<IVariableHardware>();
            variablesEscritura = new List<IVariableHardware>();

            solicitudEstado = Globales.ObtenerPeticion(CodigoBoard.Board0x23, TipoTrama.SolicitudEstado);
            InicializarVariablesLectura();
            InicializarVariablesEscritura();
        }
        #endregion Constructores

        #region MetodosPublicos
        public void Procesar(List<byte[]> datos)
        {
            //Procesa las variables de lectura
            foreach (byte[] var in datos)
            {
                int id = Globales.ObtenerValor(var[0], var[1]);
                IVariableHardware vHrd = variablesLectura.FirstOrDefault(v => v.Id == id);
                Globales.ProcesarVariable(ref vHrd, var);
            }
        }

        public byte[] Escribir()
        {
            List<byte> datVar = new List<byte>();
            foreach (IVariableHardware iv in variablesEscritura.FindAll(v => v.CambioVariable))
            {
                datVar.Add(Globales.ObtenerByteAlto(iv.Id));
                datVar.Add(Globales.ObtenerByteBajo(iv.Id));

                if (iv is VariableAnaloga)
                {
                    VariableAnaloga va = (VariableAnaloga)iv;
                    if (va.ModoCalibracion)
                    {
                        datVar.Add(Globales.ObtenerByteAlto((int)va.ValorSinProcesar));
                        datVar.Add(Globales.ObtenerByteBajo((int)va.ValorSinProcesar));
                    }
                    else
                    {
                        datVar.Add(Globales.ObtenerByteAlto((int)va.Valor));
                        datVar.Add(Globales.ObtenerByteBajo((int)va.Valor));
                    }
                }
                else if (iv is VariableDigital<bool>)
                {
                    VariableDigital<bool> va = (VariableDigital<bool>)iv;
                    datVar.Add(0x20);
                    datVar.Add(va.Valor ? (byte)ValorBooleano.Verdadero : (byte)ValorBooleano.Falso);
                }
            }

            byte[] datos = new byte[datVar.Count + 6];
            datos[0] = (byte)TipoByte.STX;
            datos[1] = (byte)CodigoBoard.Board0x23;
            datos[2] = (byte)TipoTrama.EnvioVariables;
            datos[datos.Length - 1] = (byte)TipoByte.ETX;
            int ind = 3;
            foreach (byte b in datVar)
            {
                datos[ind] = b;
                ind++;
            }
            datos = Globales.AsignarDigitoChequeo(datos);

            return datos;
        }

        #endregion MetodosPublicos
    }
}
