using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x28
    {
        #region Propiedades y variables
        public VariableDigital<bool> _FC_2_1_SW_2_DE; public bool FC_2_1_SW_2_DE() { return _FC_2_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _FC_2_2_SW_3_1_DE; public bool FC_2_2_SW_3_1_DE() { return _FC_2_2_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_2_2_SW_3_2_DE; public bool FC_2_2_SW_3_2_DE() { return _FC_2_2_SW_3_2_DE.Valor; }
        //public VariableDigital<bool> _DISPONIBLE_DE; public bool DISPONIBLE_DE() { return _DISPONIBLE_DE.Valor; }
        // public VariableDigital<bool> _DISPONIBLE_DE; public bool DISPONIBLE_DE() { return _DISPONIBLE_DE.Valor; }
        public VariableDigital<bool> _FC_2_3_SW_3_1_DE; public bool FC_2_3_SW_3_1_DE() { return _FC_2_3_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_2_3_SW_3_2_DE; public bool FC_2_3_SW_3_2_DE() { return _FC_2_3_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_2_4_SW_3_1_DE; public bool FC_2_4_SW_3_1_DE() { return _FC_2_4_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_2_4_SW_3_2_DE; public bool FC_2_4_SW_3_2_DE() { return _FC_2_4_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_2_5_SW_2_DE; public bool FC_2_5_SW_2_DE() { return _FC_2_5_SW_2_DE.Valor; }
        public VariableDigital<bool> _FC_2_6_PHK_2_DE; public bool FC_2_6_PHK_2_DE() { return _FC_2_6_PHK_2_DE.Valor; }
        public VariableDigital<bool> _FC_4_1_L_4_1_DE; public bool FC_4_1_L_4_1_DE() { return _FC_4_1_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_4_1_L_4_2_DE; public bool FC_4_1_L_4_2_DE() { return _FC_4_1_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_4_1_L_4_3_DE; public bool FC_4_1_L_4_3_DE() { return _FC_4_1_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_4_2_L_4_1_DE; public bool FC_4_2_L_4_1_DE() { return _FC_4_2_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_4_2_L_4_2_DE; public bool FC_4_2_L_4_2_DE() { return _FC_4_2_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_4_2_L_4_3_DE; public bool FC_4_2_L_4_3_DE() { return _FC_4_2_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_4_3_L_4_1_DE; public bool FC_4_3_L_4_1_DE() { return _FC_4_3_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_4_3_L_4_2_DE; public bool FC_4_3_L_4_2_DE() { return _FC_4_3_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_4_3_L_4_3_DE; public bool FC_4_3_L_4_3_DE() { return _FC_4_3_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_4_4_L_4_1_DE; public bool FC_4_4_L_4_1_DE() { return _FC_4_4_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_4_4_L_4_2_DE; public bool FC_4_4_L_4_2_DE() { return _FC_4_4_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_4_4_L_4_3_DE; public bool FC_4_4_L_4_3_DE() { return _FC_4_4_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_18_1_L_4_1_DE; public bool FC_18_1_L_4_1_DE() { return _FC_18_1_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_18_1_L_4_2_DE; public bool FC_18_1_L_4_2_DE() { return _FC_18_1_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_18_1_L_4_3_DE; public bool FC_18_1_L_4_3_DE() { return _FC_18_1_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_18_2_L_4_1_DE; public bool FC_18_2_L_4_1_DE() { return _FC_18_2_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_18_2_L_4_2_DE; public bool FC_18_2_L_4_2_DE() { return _FC_18_2_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_18_2_L_4_3_DE; public bool FC_18_2_L_4_3_DE() { return _FC_18_2_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_18_3_L_4_1_DE; public bool FC_18_3_L_4_1_DE() { return _FC_18_3_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_18_3_L_4_2_DE; public bool FC_18_3_L_4_2_DE() { return _FC_18_3_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_18_3_L_4_3_DE; public bool FC_18_3_L_4_3_DE() { return _FC_18_3_L_4_3_DE.Valor; }
        public VariableDigital<bool> _FC_18_4_L_4_1_DE; public bool FC_18_4_L_4_1_DE() { return _FC_18_4_L_4_1_DE.Valor; }
        public VariableDigital<bool> _FC_18_4_L_4_2_DE; public bool FC_18_4_L_4_2_DE() { return _FC_18_4_L_4_2_DE.Valor; }
        public VariableDigital<bool> _FC_18_4_L_4_3_DE; public bool FC_18_4_L_4_3_DE() { return _FC_18_4_L_4_3_DE.Valor; }

        public VariableAnaloga _FC_4_1_L_4_AE; public double FC_4_1_L_4_AE { get => _FC_4_1_L_4_AE.Valor; }
        public VariableAnaloga _FC_4_2_L_4_AE; public double FC_4_2_L_4_AE { get => _FC_4_2_L_4_AE.Valor; }
        public VariableAnaloga _FC_4_3_L_4_AE; public double FC_4_3_L_4_AE { get => _FC_4_3_L_4_AE.Valor; }
        public VariableAnaloga _FC_4_4_L_4_AE; public double FC_4_4_L_4_AE { get => _FC_4_4_L_4_AE.Valor; }
        public VariableAnaloga _FC_18_1_L_4_AE; public double FC_18_1_L_4_AE { get => _FC_18_1_L_4_AE.Valor; }
        public VariableAnaloga _FC_18_2_L_4_AE; public double FC_18_2_L_4_AE { get => _FC_18_2_L_4_AE.Valor; }
        public VariableAnaloga _FC_18_3_L_4_AE; public double FC_18_3_L_4_AE { get => _FC_18_3_L_4_AE.Valor; }
        public VariableAnaloga _FC_18_4_L_4_AE; public double FC_18_4_L_4_AE { get => _FC_18_4_L_4_AE.Valor; }

        private VariableDigital<bool> _FC_2_6_PHK_2_DS; public bool FC_2_6_PHK_2_DS { get => _FC_2_6_PHK_2_DS.Valor; set => _FC_2_6_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_2_6_PHK_2_2_DS; public bool FC_2_6_PHK_2_2_DS { get => _FC_2_6_PHK_2_2_DS.Valor; set => _FC_2_6_PHK_2_2_DS.Valor = value; }

        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {

            _FC_2_1_SW_2_DE = new VariableDigital<bool>() { Id = 350, Nombre = "FC_2_1_SW_2_DE" }; variablesLectura.Add(_FC_2_1_SW_2_DE);
            _FC_2_2_SW_3_1_DE = new VariableDigital<bool>() { Id = 351, Nombre = "FC_2_2_SW_3_1_DE" }; variablesLectura.Add(_FC_2_2_SW_3_1_DE);
            _FC_2_2_SW_3_2_DE = new VariableDigital<bool>() { Id = 352, Nombre = "FC_2_2_SW_3_2_DE" }; variablesLectura.Add(_FC_2_2_SW_3_2_DE);
            // _DISPONIBLE_DE = new VariableDigital<bool>() { Id = 353, Nombre = "DISPONIBLE_DE" }; variablesLectura.Add(_DISPONIBLE_DE);
            //  _DISPONIBLE_DE = new VariableDigital<bool>() { Id = 354, Nombre = "DISPONIBLE_DE" }; variablesLectura.Add(_DISPONIBLE_DE);
            _FC_2_3_SW_3_1_DE = new VariableDigital<bool>() { Id = 355, Nombre = "FC_2_3_SW_3_1_DE" }; variablesLectura.Add(_FC_2_3_SW_3_1_DE);
            _FC_2_3_SW_3_2_DE = new VariableDigital<bool>() { Id = 356, Nombre = "FC_2_3_SW_3_2_DE" }; variablesLectura.Add(_FC_2_3_SW_3_2_DE);
            _FC_2_4_SW_3_1_DE = new VariableDigital<bool>() { Id = 357, Nombre = "FC_2_4_SW_3_1_DE" }; variablesLectura.Add(_FC_2_4_SW_3_1_DE);
            _FC_2_4_SW_3_2_DE = new VariableDigital<bool>() { Id = 358, Nombre = "FC_2_4_SW_3_2_DE" }; variablesLectura.Add(_FC_2_4_SW_3_2_DE);
            _FC_2_5_SW_2_DE = new VariableDigital<bool>() { Id = 359, Nombre = "FC_2_5_SW_2_DE" }; variablesLectura.Add(_FC_2_5_SW_2_DE);
            _FC_2_6_PHK_2_DE = new VariableDigital<bool>() { Id = 360, Nombre = "FC_2_6_PHK_2_DE" }; variablesLectura.Add(_FC_2_6_PHK_2_DE);
            _FC_4_1_L_4_1_DE = new VariableDigital<bool>() { Id = 361, Nombre = "FC_4_1_L_4_1_DE" }; variablesLectura.Add(_FC_4_1_L_4_1_DE);
            _FC_4_1_L_4_2_DE = new VariableDigital<bool>() { Id = 362, Nombre = "FC_4_1_L_4_2_DE" }; variablesLectura.Add(_FC_4_1_L_4_2_DE);
            _FC_4_1_L_4_3_DE = new VariableDigital<bool>() { Id = 363, Nombre = "FC_4_1_L_4_3_DE" }; variablesLectura.Add(_FC_4_1_L_4_3_DE);
            _FC_4_2_L_4_1_DE = new VariableDigital<bool>() { Id = 364, Nombre = "FC_4_2_L_4_1_DE" }; variablesLectura.Add(_FC_4_2_L_4_1_DE);
            _FC_4_2_L_4_2_DE = new VariableDigital<bool>() { Id = 365, Nombre = "FC_4_2_L_4_2_DE" }; variablesLectura.Add(_FC_4_2_L_4_2_DE);
            _FC_4_2_L_4_3_DE = new VariableDigital<bool>() { Id = 366, Nombre = "FC_4_2_L_4_3_DE" }; variablesLectura.Add(_FC_4_2_L_4_3_DE);
            _FC_4_3_L_4_1_DE = new VariableDigital<bool>() { Id = 367, Nombre = "FC_4_3_L_4_1_DE" }; variablesLectura.Add(_FC_4_3_L_4_1_DE);
            _FC_4_3_L_4_2_DE = new VariableDigital<bool>() { Id = 368, Nombre = "FC_4_3_L_4_2_DE" }; variablesLectura.Add(_FC_4_3_L_4_2_DE);
            _FC_4_3_L_4_3_DE = new VariableDigital<bool>() { Id = 369, Nombre = "FC_4_3_L_4_3_DE" }; variablesLectura.Add(_FC_4_3_L_4_3_DE);
            _FC_4_4_L_4_1_DE = new VariableDigital<bool>() { Id = 370, Nombre = "FC_4_4_L_4_1_DE" }; variablesLectura.Add(_FC_4_4_L_4_1_DE);
            _FC_4_4_L_4_2_DE = new VariableDigital<bool>() { Id = 371, Nombre = "FC_4_4_L_4_2_DE" }; variablesLectura.Add(_FC_4_4_L_4_2_DE);
            _FC_4_4_L_4_3_DE = new VariableDigital<bool>() { Id = 372, Nombre = "FC_4_4_L_4_3_DE" }; variablesLectura.Add(_FC_4_4_L_4_3_DE);
            _FC_18_1_L_4_1_DE = new VariableDigital<bool>() { Id = 373, Nombre = "FC_18_1_L_4_1_DE" }; variablesLectura.Add(_FC_18_1_L_4_1_DE);
            _FC_18_1_L_4_2_DE = new VariableDigital<bool>() { Id = 374, Nombre = "FC_18_1_L_4_2_DE" }; variablesLectura.Add(_FC_18_1_L_4_2_DE);
            _FC_18_1_L_4_3_DE = new VariableDigital<bool>() { Id = 375, Nombre = "FC_18_1_L_4_3_DE" }; variablesLectura.Add(_FC_18_1_L_4_3_DE);
            _FC_18_2_L_4_1_DE = new VariableDigital<bool>() { Id = 376, Nombre = "FC_18_2_L_4_1_DE" }; variablesLectura.Add(_FC_18_2_L_4_1_DE);
            _FC_18_2_L_4_2_DE = new VariableDigital<bool>() { Id = 377, Nombre = "FC_18_2_L_4_2_DE" }; variablesLectura.Add(_FC_18_2_L_4_2_DE);
            _FC_18_2_L_4_3_DE = new VariableDigital<bool>() { Id = 378, Nombre = "FC_18_2_L_4_3_DE" }; variablesLectura.Add(_FC_18_2_L_4_3_DE);
            _FC_18_3_L_4_1_DE = new VariableDigital<bool>() { Id = 379, Nombre = "FC_18_3_L_4_1_DE" }; variablesLectura.Add(_FC_18_3_L_4_1_DE);
            _FC_18_3_L_4_2_DE = new VariableDigital<bool>() { Id = 380, Nombre = "FC_18_3_L_4_2_DE" }; variablesLectura.Add(_FC_18_3_L_4_2_DE);
            _FC_18_3_L_4_3_DE = new VariableDigital<bool>() { Id = 381, Nombre = "FC_18_3_L_4_3_DE" }; variablesLectura.Add(_FC_18_3_L_4_3_DE);
            _FC_18_4_L_4_1_DE = new VariableDigital<bool>() { Id = 382, Nombre = "FC_18_4_L_4_1_DE" }; variablesLectura.Add(_FC_18_4_L_4_1_DE);
            _FC_18_4_L_4_2_DE = new VariableDigital<bool>() { Id = 383, Nombre = "FC_18_4_L_4_2_DE" }; variablesLectura.Add(_FC_18_4_L_4_2_DE);
            _FC_18_4_L_4_3_DE = new VariableDigital<bool>() { Id = 384, Nombre = "FC_18_4_L_4_3_DE" }; variablesLectura.Add(_FC_18_4_L_4_3_DE);

            _FC_4_1_L_4_AE = new VariableAnaloga(@"Calibracion\FC_4_1_L_4_AE.xml", 1) { Id = 4070, Nombre = "FC_4_1_L_4_AE" }; variablesLectura.Add(_FC_4_1_L_4_AE);
            _FC_4_2_L_4_AE = new VariableAnaloga(@"Calibracion\FC_4_2_L_4_AE.xml", 1) { Id = 4071, Nombre = "FC_4_2_L_4_AE" }; variablesLectura.Add(_FC_4_2_L_4_AE);
            _FC_4_3_L_4_AE = new VariableAnaloga(@"Calibracion\FC_4_3_L_4_AE.xml", 1) { Id = 4072, Nombre = "FC_4_3_L_4_AE" }; variablesLectura.Add(_FC_4_3_L_4_AE);
            _FC_4_4_L_4_AE = new VariableAnaloga(@"Calibracion\FC_4_4_L_4_AE.xml", 1) { Id = 4073, Nombre = "FC_4_4_L_4_AE" }; variablesLectura.Add(_FC_4_4_L_4_AE);
            _FC_18_1_L_4_AE = new VariableAnaloga(@"Calibracion\FC_18_1_L_4_AE.xml", 1) { Id = 4074, Nombre = "FC_18_1_L_4_AE" }; variablesLectura.Add(_FC_18_1_L_4_AE);
            _FC_18_2_L_4_AE = new VariableAnaloga(@"Calibracion\FC_18_2_L_4_AE.xml", 1) { Id = 4075, Nombre = "FC_18_2_L_4_AE" }; variablesLectura.Add(_FC_18_2_L_4_AE);
            _FC_18_3_L_4_AE = new VariableAnaloga(@"Calibracion\FC_18_3_L_4_AE.xml", 1) { Id = 4076, Nombre = "FC_18_3_L_4_AE" }; variablesLectura.Add(_FC_18_3_L_4_AE);
            _FC_18_4_L_4_AE = new VariableAnaloga(@"Calibracion\FC_18_4_L_4_AE.xml", 1) { Id = 4077, Nombre = "FC_18_4_L_4_AE" }; variablesLectura.Add(_FC_18_4_L_4_AE);
        }

        private void InicializarVariablesEscritura()
        {
            _FC_2_6_PHK_2_DS = new VariableDigital<bool>() { Id = 2350, Nombre = "FC_2_6_PHK_2_DS" }; variablesEscritura.Add(_FC_2_6_PHK_2_DS);
            _FC_2_6_PHK_2_2_DS = new VariableDigital<bool>() { Id = 2351, Nombre = "FC_2_6_PHK_2_2_DS" }; variablesEscritura.Add(_FC_2_6_PHK_2_2_DS);


        }
        #endregion MetodosPrivados
    }
}
