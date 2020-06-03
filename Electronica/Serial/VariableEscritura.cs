namespace Electronica.Serial
{
    public class VariableEscritura<TipoDato>
    {
        private TipoDato variable;
        private TipoDato variableAnt;
        private bool cambioVariable;

        public TipoDato Valor
        {
            get
            {
                variableAnt = variable;
                return variable;
            }
            set
            {
                if (!variableAnt.Equals(value))
                {
                    variable = variableAnt = value;
                    cambioVariable = true;
                }
                else
                {
                    cambioVariable = false;
                }
            }
        }

        public bool CambioVariable
        {
            get
            {
                return cambioVariable;
            }
        }
    }
}
