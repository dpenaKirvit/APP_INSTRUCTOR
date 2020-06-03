namespace Electronica.Simulacion
{
    public class VariableDigital<T> : IVariableHardware
    {
        #region Variables
        T valorAnt;
        public bool erase;

        #endregion

        #region Propiedades
        private T valor;
        public T Valor
        {
            get
            {
                //valorAnt = valor;
                return valor;
            }
            set
            {
                valor = value;
                erase = true;
            }
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
                if (!valor.Equals(valorAnt))
                {
                    valorAnt = valor;
                    erase = true;
                    return true;
                }
                return false;
            }
        }

        public bool VerificarCambio
        {
            get
            {
                if (!valor.Equals(valorAnt))
                {
                    return true;
                }
                return false;
            }
        }

        #endregion
    }
}
