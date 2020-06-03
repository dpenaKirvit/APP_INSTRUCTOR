using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x2F
    {
        #region Propiedades y variables
        public VariableDigital<bool> _PS_2_7_SW_3_1_DE; public bool PS_2_7_SW_3_1_DE() { return _PS_2_7_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _PS_2_7_SW_3_2_DE; public bool PS_2_7_SW_3_2_DE() {return  _PS_2_7_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _PS_3_1_SW_2_DE; public bool PS_3_1_SW_2_DE() { return _PS_3_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _PS_3_2_SW_2_DE; public bool PS_3_2_SW_2_DE() { return _PS_3_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _PS_3_5_SW_2_DE; public bool PS_3_5_SW_2_DE() { return  _PS_3_5_SW_2_DE.Valor; }
        public VariableDigital<bool> _PS_3_7_SW_3_1_DE; public bool PS_3_7_SW_3_1_DE() { return _PS_3_7_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _PS_3_7_SW_3_2_DE; public bool PS_3_7_SW_3_2_DE() { return _PS_3_7_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _PS_3_8_SW_2_DE; public bool PS_3_8_SW_2_DE() { return _PS_3_8_SW_2_DE.Valor; }
        public VariableDigital<bool> _PE_2_SW_3_1_DE; public bool PE_2_SW_3_1_DE() { return  _PE_2_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _PE_2_SW_3_2_DE; public bool PE_2_SW_3_2_DE() { return  _PE_2_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _DISPONIBLE_DE; public bool DISPONIBLE_DE() { return  _DISPONIBLE_DE.Valor; }
        public VariableDigital<bool> _PS_1_1_SW_3_1_DE; public bool PS_1_1_SW_3_1_DE() { return  _PS_1_1_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _PS_1_1_SW_3_2_DE; public bool PS_1_1_SW_3_2_DE() { return  _PS_1_1_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _PS_1_2_SW_2_DE; public bool PS_1_2_SW_2_DE() { return  _PS_1_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _PS_1_3_SW_2_DE; public bool PS_1_3_SW_2_DE() { return  _PS_1_3_SW_2_DE.Valor; }


        public VariableAnaloga _PS_2_1_PT_1_AE; public double PS_2_1_PT_1_AE() { return  _PS_2_1_PT_1_AE.Valor; }
        public VariableAnaloga _PS_2_2_PT_1_AE; public double PS_2_2_PT_1_AE() { return  _PS_2_2_PT_1_AE.Valor; }
        public VariableAnaloga _PS_2_4_PT_1_AE; public double PS_2_4_PT_1_AE() { return  _PS_2_4_PT_1_AE.Valor; }
        public VariableAnaloga _PS_2_5_PT_1_AE; public double PS_2_5_PT_1_AE() { return  _PS_2_5_PT_1_AE.Valor; }
        public VariableAnaloga _PS_2_6_PT_1_AE; public double PS_2_6_PT_1_AE() { return _PS_2_6_PT_1_AE.Valor; }


        public VariableDigital<bool> _PS_3_3_PH_2_DS; public bool PS_3_3_PH_2_DS { get => _PS_3_3_PH_2_DS.Valor; set => _PS_3_3_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _PS_3_4_PH_2_DS; public bool PS_3_4_PH_2_DS { get => _PS_3_4_PH_2_DS.Valor; set => _PS_3_4_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _PS_3_6_PH_2_DS; public bool PS_3_6_PH_2_DS { get => _PS_3_6_PH_2_DS.Valor; set => _PS_3_6_PH_2_DS.Valor = value; }


        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _PS_2_7_SW_3_1_DE = new VariableDigital<bool>() { Id = 800, Nombre = "PS_2_7_SW_3_1_DE" }; variablesLectura.Add(_PS_2_7_SW_3_1_DE);
            _PS_2_7_SW_3_2_DE = new VariableDigital<bool>() { Id = 801, Nombre = "PS_2_7_SW_3_2_DE" }; variablesLectura.Add(_PS_2_7_SW_3_2_DE);
            _PS_3_1_SW_2_DE = new VariableDigital<bool>() { Id = 802, Nombre = "PS_3_1_SW_2_DE" }; variablesLectura.Add(_PS_3_1_SW_2_DE);
            _PS_3_2_SW_2_DE = new VariableDigital<bool>() { Id = 803, Nombre = "PS_3_2_SW_2_DE" }; variablesLectura.Add(_PS_3_2_SW_2_DE);
            _PS_3_5_SW_2_DE = new VariableDigital<bool>() { Id = 804, Nombre = "PS_3_5_SW_2_DE" }; variablesLectura.Add(_PS_3_5_SW_2_DE);
            _PS_3_7_SW_3_1_DE = new VariableDigital<bool>() { Id = 805, Nombre = "PS_3_7_SW_3_1_DE" }; variablesLectura.Add(_PS_3_7_SW_3_1_DE);
            _PS_3_7_SW_3_2_DE = new VariableDigital<bool>() { Id = 806, Nombre = "PS_3_7_SW_3_2_DE" }; variablesLectura.Add(_PS_3_7_SW_3_2_DE);
            _PS_3_8_SW_2_DE = new VariableDigital<bool>() { Id = 807, Nombre = "PS_3_8_SW_2_DE" }; variablesLectura.Add(_PS_3_8_SW_2_DE);
            _PE_2_SW_3_1_DE = new VariableDigital<bool>() { Id = 808, Nombre = "PE_2_SW_3_1_DE" }; variablesLectura.Add(_PE_2_SW_3_1_DE);
            _PE_2_SW_3_2_DE = new VariableDigital<bool>() { Id = 809, Nombre = "PE_2_SW_3_2_DE" }; variablesLectura.Add(_PE_2_SW_3_2_DE);
            _DISPONIBLE_DE = new VariableDigital<bool>() { Id = 810, Nombre = "DISPONIBLE_DE" }; variablesLectura.Add(_DISPONIBLE_DE);
            _PS_1_1_SW_3_1_DE = new VariableDigital<bool>() { Id = 811, Nombre = "PS_1_1_SW_3_1_DE" }; variablesLectura.Add(_PS_1_1_SW_3_1_DE);
            _PS_1_1_SW_3_2_DE = new VariableDigital<bool>() { Id = 812, Nombre = "PS_1_1_SW_3_2_DE" }; variablesLectura.Add(_PS_1_1_SW_3_2_DE);
            _PS_1_2_SW_2_DE = new VariableDigital<bool>() { Id = 813, Nombre = "PS_1_2_SW_2_DE" }; variablesLectura.Add(_PS_1_2_SW_2_DE);
            _PS_1_3_SW_2_DE = new VariableDigital<bool>() { Id = 814, Nombre = "PS_1_3_SW_2_DE" }; variablesLectura.Add(_PS_1_3_SW_2_DE);

        }

        private void InicializarVariablesEscritura()
        {
            _PS_3_3_PH_2_DS = new VariableDigital<bool>() { Id = 2800, Nombre = "PS_3_3_PH_2_DS" }; variablesEscritura.Add(_PS_3_3_PH_2_DS);
            _PS_3_4_PH_2_DS = new VariableDigital<bool>() { Id = 2801, Nombre = "PS_3_4_PH_2_DS" }; variablesEscritura.Add(_PS_3_4_PH_2_DS);
            _PS_3_6_PH_2_DS = new VariableDigital<bool>() { Id = 2802, Nombre = "PS_3_6_PH_2_DS" }; variablesEscritura.Add(_PS_3_6_PH_2_DS);

        }
        #endregion MetodosPrivados
    }
}
