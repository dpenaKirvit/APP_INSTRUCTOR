using Electronica.Serial;
using Electronica.Simulacion;
using System.Collections.Generic;

namespace Electronica.Componentes
{
    public static class Globales
    {
        public static byte[] ObtenerDigitoChequeo(byte[] datos)
        {
            byte dg = Convertir.ObtenerDigitoChequeo(datos, 1, datos.Length - 4);
            byte[] chk = new byte[2];
            chk[0] = ObtenerByteAlto(dg);
            chk[1] = ObtenerByteBajo(dg);
            return chk;
        }
        public static bool ValidarDigitoChequeo(byte[] datos)
        {
            byte[] chk = ObtenerDigitoChequeo(datos);

            byte[] chkOri = new byte[2];
            chkOri[0] = datos[datos.Length - 3];
            chkOri[1] = datos[datos.Length - 2];

            if (!Convertir.TramasIguales(chk, chkOri))
            {
                return false;
            }

            return true;
        }
        public static byte[] AsignarDigitoChequeo(byte[] datos)
        {
            byte[] chk = ObtenerDigitoChequeo(datos);
            datos[datos.Length - 3] = chk[0];
            datos[datos.Length - 2] = chk[1];
            return datos;
        }
        public static byte[] ObtenerPeticion(CodigoBoard codBoard, TipoTrama tTrama)
        {
            byte[] pet = new byte[6];
            pet[0] = (byte)TipoByte.STX;
            pet[1] = (byte)codBoard;
            pet[2] = (byte)tTrama;
            pet[5] = (byte)TipoByte.ETX;
            pet = AsignarDigitoChequeo(pet);
            return pet;
        }
        public static List<byte[]> SepararVariables(byte[] datos)
        {
            List<byte[]> var = new List<byte[]>();
            int pos = 3;
            while (pos + 3 < datos.Length)
            {
                var.Add(new byte[] { datos[pos], datos[pos + 1], datos[pos + 2], datos[pos + 3] });
                pos += 4;
            }
            return var;
        }
        public static byte ObtenerByteAlto(int valor)
        {
            return (byte)(((byte)(valor / 100)) + 0x20);
        }
        public static byte ObtenerByteBajo(int valor)
        {
            return (byte)(((byte)(valor % 100)) + 0x20);
        }
        public static int ObtenerValor(byte b1, byte b2)
        {
            b1 = (byte)(b1 - 0x20);
            b2 = (byte)(b2 - 0x20);
            int res = b1 * 100 + b2;
            return res;
        }
        public static void ProcesarVariable(ref IVariableHardware vHrd, byte[] var)
        {
            if (vHrd is VariableDigital<bool>)
            {
                ((VariableDigital<bool>)vHrd).Valor = Convertir.Booleano(var[3], (int)ValorBooleano.Verdadero);
            }
            else if (vHrd is VariableAnaloga)
            {
                ((VariableAnaloga)vHrd).Valor = Globales.ObtenerValor(var[2], var[3]);
            }
            else if (vHrd is VariableEncoder)
            {
                VariableEncoder enc = (VariableEncoder)vHrd;
                if (Convertir.Booleano(var[2], (int)ValorBooleano.Verdadero))
                {
                    enc.Incrementar((var[3] - 0x20));
                }
                else if (var[2] == (byte)ValorBooleano.Falso)
                {
                    enc.Decrementar((var[3] - 0x20));
                }
            }
        }
    }
}
