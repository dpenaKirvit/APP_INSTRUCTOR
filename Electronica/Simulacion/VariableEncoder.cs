namespace Electronica.Simulacion
{
    public class VariableEncoder : IVariableHardware
    {
        #region Propiedades
        public CambiosEncoder CambioEncoder
        {
            get
            {
                if (numeroCambios > 0)
                {
                    return CambiosEncoder.Incremento;
                }
                else if (numeroCambios < 0)
                {
                    return CambiosEncoder.Decremento;
                }
                return CambiosEncoder.Ninguno;
            }
        }
        private int numeroCambios;
        public bool erase;
        public int NumeroCambios()
        {
            int num = numeroCambios; //Guarda el número de pasos y los borra, porque ya fue usado
            numeroCambios = 0;
            return num;
        }
        //public int NumeroCambios  MFMR TRATANDO DE SOLUCIONAR ERROR
        //{
        //    get
        //    {
        //        int num = numeroCambios; //Guarda el número de pasos y los borra, porque ya fue usado
        //        numeroCambios = 0;
        //        return num;
        //    }
        //}
        public int ObtenerNumeroCambios()
        {
            return numeroCambios;
        }
        public void BorrarNumeroCambios()
        {
            numeroCambios = 0;
        }
        #endregion Propiedades

        #region Miembros de IVariableHardware
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PosicionTrama { get; set; }
        public bool CambioVariable
        {
            get
            {
                if (numeroCambios != 0)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion
        public void Incrementar()
        {
            numeroCambios++;
            erase = true;
        }
        public void Decrementar()
        {
            numeroCambios--;
            erase = true;
        }

        public void Incrementar(int pasos)
        {
            numeroCambios += pasos;
            erase = true;
        }
        public void Decrementar(int pasos)
        {
            numeroCambios -= pasos;
            erase = true;
        }
    }
}
