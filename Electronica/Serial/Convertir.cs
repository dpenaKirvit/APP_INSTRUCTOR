using System;

namespace Electronica.Serial
{
    public static class Convertir
    {
        public static int ObtenerValor(byte b1, byte b2)
        {
            byte[] b = new byte[] { b2, b1 };
            int res = BitConverter.ToUInt16(b, 0);
            return res;
        }

        public static bool ObtenerValor(byte valor, int bit)
        {
            if ((valor & bit) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Booleano(byte valor, int valorTrue)
        {
            if (valor == valorTrue)
            {
                return true;
            }
            return false;
        }

        public static byte Booleano(bool valor, byte valorTrue, byte valorFalse)
        {
            if (valor)
            {
                return valorTrue;
            }
            else
            {
                return valorFalse;
            }
        }

        /// <summary>
        /// Obtiene un valor dado dos bytes
        /// </summary>
        /// <param name="b1">Byte 1</param>
        /// <param name="b2">Byte 2</param>
        /// <param name="nBase">Base a transformar el entero (2, 8, 10, 16)</param>
        /// <returns></returns>
        public static int ObtenerValor(byte b1, byte b2, int nBase)
        {
            int valor = ObtenerValor(b1, b2);
            return Convert.ToInt32(Convert.ToString(valor, nBase));
        }

        public static bool CambioValor(int valorActual, ref int valorAnterior, int diferencia)
        {
            if (Math.Abs(valorActual - valorAnterior) >= diferencia)
            {
                valorAnterior = valorActual;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obtiene el digito de chequeo de una trama de lectura
        /// </summary>
        /// <param name="datos">Datos para obtener el digito de chequeo</param>
        /// <returns>Digito de chequeo</returns>
        public static byte ObtenerDigitoChequeo(byte[] datos, int posicion)
        {
            byte suma = 0;

            for (int i = 0; i < posicion; i++)
            {
                suma ^= datos[i];
            }
            return suma;
        }

        public static byte ObtenerDigitoChequeo(byte[] datos, int desde, int hasta)
        {
            byte suma = 0;

            for (int i = desde; i <= hasta; i++)
            {
                suma ^= datos[i];
            }
            return suma;
        }

        /// <summary>
        /// Obtiene el digito de chequeo de una trama de lectura CRC, por medio de suma de
        /// </summary>
        /// <param name="datos">Datos para obtener el digito de chequeo</param>
        /// <returns>Digito de chequeo</returns>
        public static byte ObtenerCRC(byte[] datos, int posicion)
        {
            byte suma = 0;

            for (int i = 0; i < posicion; i++)
            {
                suma += datos[i];
            }
            suma = (byte)(255 - suma + 1);
            return suma;
        }

        /// <summary>
        /// Verifica si dos tramas son iguales en tamaño y datos
        /// </summary>
        /// <param name="trama1"></param>
        /// <param name="trama2"></param>
        /// <returns></returns>
        public static bool TramasIguales(byte[] trama1, byte[] trama2)
        {
            bool igual = true;

            if (trama1 == null || trama2 == null)
            {
                return false;
            }

            if (trama1.Length == trama2.Length)
            {
                for (int x = 0; x < trama1.Length; x++)
                {
                    if (trama1[x] != trama2[x])
                    {
                        igual = false;
                        break;
                    }
                }
            }
            else
            {
                igual = false;
            }
            return igual;
        }

        /// <summary>
        /// Devuelve una trama de datos igual a laque se pasa por referencia
        /// </summary>
        /// <param name="trama"></param>
        /// <returns></returns>
        public static byte[] AsignarTrama(byte[] trama)
        {
            byte[] nueva = new byte[trama.Length];
            for (int x = 0; x < trama.Length; x++)
            {
                nueva[x] = trama[x];
            }
            return nueva;
        }
    }
}
