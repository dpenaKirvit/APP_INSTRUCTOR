using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x27
    {
        #region Propiedades y variables
        public VariableDigital<bool> _OH_13_1_SW_4_1_DE; public bool OH_13_1_SW_4_1_DE() { return _OH_13_1_SW_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_13_1_SW_4_2_DE; public bool OH_13_1_SW_4_2_DE() { return _OH_13_1_SW_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_13_1_SW_4_3_DE; public bool OH_13_1_SW_4_3_DE() { return _OH_13_1_SW_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_13_2_SW_4_1_DE; public bool OH_13_2_SW_4_1_DE() { return _OH_13_2_SW_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_13_2_SW_4_2_DE; public bool OH_13_2_SW_4_2_DE() { return _OH_13_2_SW_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_13_2_SW_4_3_DE; public bool OH_13_2_SW_4_3_DE() { return _OH_13_2_SW_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_13_3_SW_4_1_DE; public bool OH_13_3_SW_4_1_DE() { return _OH_13_3_SW_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_13_3_SW_4_2_DE; public bool OH_13_3_SW_4_2_DE() { return _OH_13_3_SW_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_13_3_SW_4_3_DE; public bool OH_13_3_SW_4_3_DE() { return _OH_13_3_SW_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_13_4_SW_4_1_DE; public bool OH_13_4_SW_4_1_DE() { return _OH_13_4_SW_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_13_4_SW_4_2_DE; public bool OH_13_4_SW_4_2_DE() { return _OH_13_4_SW_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_13_4_SW_4_3_DE; public bool OH_13_4_SW_4_3_DE() { return _OH_13_4_SW_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_14_1_SW_2_DE; public bool OH_14_1_SW_2_DE() { return _OH_14_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_14_2_SW_2_DE; public bool OH_14_2_SW_2_DE() { return _OH_14_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_14_3_SW_2_DE; public bool OH_14_3_SW_2_DE() { return _OH_14_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_14_4_SW_2_DE; public bool OH_14_4_SW_2_DE() { return _OH_14_4_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_14_5_SW_2_DE; public bool OH_14_5_SW_2_DE() { return _OH_14_5_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_14_6_SW_2_DE; public bool OH_14_6_SW_2_DE() { return _OH_14_6_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_15_2_SW_3_1_DE; public bool OH_15_2_SW_3_1_DE() { return _OH_15_2_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_15_2_SW_3_2_DE; public bool OH_15_2_SW_3_2_DE() { return _OH_15_2_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_15_3_PH_2_DE; public bool OH_15_3_PH_2_DE() { return _OH_15_3_PH_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_9_SW_2_DE; public bool OH_16_9_SW_2_DE() { return _OH_16_9_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_10_SW_2_DE; public bool OH_16_10_SW_2_DE() { return _OH_16_10_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_11_SW_2_DE; public bool OH_16_11_SW_2_DE() { return _OH_16_11_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_12_SW_2_DE; public bool OH_16_12_SW_2_DE() { return _OH_16_12_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_13_SW_2_DE; public bool OH_16_13_SW_2_DE() { return _OH_16_13_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_14_SW_2_DE; public bool OH_16_14_SW_2_DE() { return _OH_16_14_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_15_SW_2_DE; public bool OH_16_15_SW_2_DE() { return _OH_16_15_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_16_16_SW_2_DE; public bool OH_16_16_SW_2_DE() { return _OH_16_16_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_17_2_SW_2_DE; public bool OH_17_2_SW_2_DE() { return _OH_17_2_SW_2_DE.Valor; }

        private VariableDigital<bool> _OH_14_7_PHK_2_DS; public bool OH_14_7_PHK_2_DS { get => _OH_14_7_PHK_2_DS.Valor; set => _OH_14_7_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_14_8_PHK_2_DS; public bool OH_14_8_PHK_2_DS { get => _OH_14_8_PHK_2_DS.Valor; set => _OH_14_8_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_14_9_PHK_2_DS; public bool OH_14_9_PHK_2_DS { get => _OH_14_9_PHK_2_DS.Valor; set => _OH_14_9_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_14_10_PHK_2_DS; public bool OH_14_10_PHK_2_DS { get => _OH_14_10_PHK_2_DS.Valor; set => _OH_14_10_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_14_11_PHK_2_DS; public bool OH_14_11_PHK_2_DS { get => _OH_14_11_PHK_2_DS.Valor; set => _OH_14_11_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_14_12_PHK_2_DS; public bool OH_14_12_PHK_2_DS { get => _OH_14_12_PHK_2_DS.Valor; set => _OH_14_12_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_15_1_PH_2_DS; public bool OH_15_1_PH_2_DS { get => _OH_15_1_PH_2_DS.Valor; set => _OH_15_1_PH_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_15_4_PH_2_DS; public bool OH_15_4_PH_2_DS { get => _OH_15_4_PH_2_DS.Valor; set => _OH_15_4_PH_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_1_PHK_2_DS; public bool OH_16_1_PHK_2_DS { get => _OH_16_1_PHK_2_DS.Valor; set => _OH_16_1_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_2_PHK_2_DS; public bool OH_16_2_PHK_2_DS { get => _OH_16_2_PHK_2_DS.Valor; set => _OH_16_2_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_3_PHK_2_DS; public bool OH_16_3_PHK_2_DS { get => _OH_16_3_PHK_2_DS.Valor; set => _OH_16_3_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_4_PHK_2_DS; public bool OH_16_4_PHK_2_DS { get => _OH_16_4_PHK_2_DS.Valor; set => _OH_16_4_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_5_PHK_2_DS; public bool OH_16_5_PHK_2_DS { get => _OH_16_5_PHK_2_DS.Valor; set => _OH_16_5_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_6_PHK_2_DS; public bool OH_16_6_PHK_2_DS { get => _OH_16_6_PHK_2_DS.Valor; set => _OH_16_6_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_7_PHK_2_DS; public bool OH_16_7_PHK_2_DS { get => _OH_16_7_PHK_2_DS.Valor; set => _OH_16_7_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_16_8_PHK_2_DS; public bool OH_16_8_PHK_2_DS { get => _OH_16_8_PHK_2_DS.Valor; set => _OH_16_8_PHK_2_DS.Valor = value; }

        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _OH_13_1_SW_4_1_DE = new VariableDigital<bool>() { Id = 300, Nombre = "OH_13_1_SW_4_1_DE" }; variablesLectura.Add(_OH_13_1_SW_4_1_DE);
            _OH_13_1_SW_4_2_DE = new VariableDigital<bool>() { Id = 301, Nombre = "OH_13_1_SW_4_2_DE" }; variablesLectura.Add(_OH_13_1_SW_4_2_DE);
            _OH_13_1_SW_4_3_DE = new VariableDigital<bool>() { Id = 302, Nombre = "OH_13_1_SW_4_3_DE" }; variablesLectura.Add(_OH_13_1_SW_4_3_DE);
            _OH_13_2_SW_4_1_DE = new VariableDigital<bool>() { Id = 303, Nombre = "OH_13_2_SW_4_1_DE" }; variablesLectura.Add(_OH_13_2_SW_4_1_DE);
            _OH_13_2_SW_4_2_DE = new VariableDigital<bool>() { Id = 304, Nombre = "OH_13_2_SW_4_2_DE" }; variablesLectura.Add(_OH_13_2_SW_4_2_DE);
            _OH_13_2_SW_4_3_DE = new VariableDigital<bool>() { Id = 305, Nombre = "OH_13_2_SW_4_3_DE" }; variablesLectura.Add(_OH_13_2_SW_4_3_DE);
            _OH_13_3_SW_4_1_DE = new VariableDigital<bool>() { Id = 306, Nombre = "OH_13_3_SW_4_1_DE" }; variablesLectura.Add(_OH_13_3_SW_4_1_DE);
            _OH_13_3_SW_4_2_DE = new VariableDigital<bool>() { Id = 307, Nombre = "OH_13_3_SW_4_2_DE" }; variablesLectura.Add(_OH_13_3_SW_4_2_DE);
            _OH_13_3_SW_4_3_DE = new VariableDigital<bool>() { Id = 308, Nombre = "OH_13_3_SW_4_3_DE" }; variablesLectura.Add(_OH_13_3_SW_4_3_DE);
            _OH_13_4_SW_4_1_DE = new VariableDigital<bool>() { Id = 309, Nombre = "OH_13_4_SW_4_1_DE" }; variablesLectura.Add(_OH_13_4_SW_4_1_DE);
            _OH_13_4_SW_4_2_DE = new VariableDigital<bool>() { Id = 310, Nombre = "OH_13_4_SW_4_2_DE" }; variablesLectura.Add(_OH_13_4_SW_4_2_DE);
            _OH_13_4_SW_4_3_DE = new VariableDigital<bool>() { Id = 311, Nombre = "OH_13_4_SW_4_3_DE" }; variablesLectura.Add(_OH_13_4_SW_4_3_DE);
            _OH_14_1_SW_2_DE = new VariableDigital<bool>() { Id = 312, Nombre = "OH_14_1_SW_2_DE" }; variablesLectura.Add(_OH_14_1_SW_2_DE);
            _OH_14_2_SW_2_DE = new VariableDigital<bool>() { Id = 313, Nombre = "OH_14_2_SW_2_DE" }; variablesLectura.Add(_OH_14_2_SW_2_DE);
            _OH_14_3_SW_2_DE = new VariableDigital<bool>() { Id = 314, Nombre = "OH_14_3_SW_2_DE" }; variablesLectura.Add(_OH_14_3_SW_2_DE);
            _OH_14_4_SW_2_DE = new VariableDigital<bool>() { Id = 315, Nombre = "OH_14_4_SW_2_DE" }; variablesLectura.Add(_OH_14_4_SW_2_DE);
            _OH_14_5_SW_2_DE = new VariableDigital<bool>() { Id = 316, Nombre = "OH_14_5_SW_2_DE" }; variablesLectura.Add(_OH_14_5_SW_2_DE);
            _OH_14_6_SW_2_DE = new VariableDigital<bool>() { Id = 317, Nombre = "OH_14_6_SW_2_DE" }; variablesLectura.Add(_OH_14_6_SW_2_DE);
            _OH_15_2_SW_3_1_DE = new VariableDigital<bool>() { Id = 318, Nombre = "OH_15_2_SW_3_1_DE" }; variablesLectura.Add(_OH_15_2_SW_3_1_DE);
            _OH_15_2_SW_3_2_DE = new VariableDigital<bool>() { Id = 319, Nombre = "OH_15_2_SW_3_2_DE" }; variablesLectura.Add(_OH_15_2_SW_3_2_DE);
            _OH_15_3_PH_2_DE = new VariableDigital<bool>() { Id = 320, Nombre = "OH_15_3_PH_2_DE" }; variablesLectura.Add(_OH_15_3_PH_2_DE);
            _OH_16_9_SW_2_DE = new VariableDigital<bool>() { Id = 321, Nombre = "OH_16_9_SW_2_DE" }; variablesLectura.Add(_OH_16_9_SW_2_DE);
            _OH_16_10_SW_2_DE = new VariableDigital<bool>() { Id = 322, Nombre = "OH_16_10_SW_2_DE" }; variablesLectura.Add(_OH_16_10_SW_2_DE);
            _OH_16_11_SW_2_DE = new VariableDigital<bool>() { Id = 323, Nombre = "OH_16_11_SW_2_DE" }; variablesLectura.Add(_OH_16_11_SW_2_DE);
            _OH_16_12_SW_2_DE = new VariableDigital<bool>() { Id = 324, Nombre = "OH_16_12_SW_2_DE" }; variablesLectura.Add(_OH_16_12_SW_2_DE);
            _OH_16_13_SW_2_DE = new VariableDigital<bool>() { Id = 325, Nombre = "OH_16_13_SW_2_DE" }; variablesLectura.Add(_OH_16_13_SW_2_DE);
            _OH_16_14_SW_2_DE = new VariableDigital<bool>() { Id = 326, Nombre = "OH_16_14_SW_2_DE" }; variablesLectura.Add(_OH_16_14_SW_2_DE);
            _OH_16_15_SW_2_DE = new VariableDigital<bool>() { Id = 327, Nombre = "OH_16_15_SW_2_DE" }; variablesLectura.Add(_OH_16_15_SW_2_DE);
            _OH_16_16_SW_2_DE = new VariableDigital<bool>() { Id = 328, Nombre = "OH_16_16_SW_2_DE" }; variablesLectura.Add(_OH_16_16_SW_2_DE);
            _OH_17_2_SW_2_DE = new VariableDigital<bool>() { Id = 329, Nombre = "OH_17_2_SW_2_DE" }; variablesLectura.Add(_OH_17_2_SW_2_DE);
        }

        private void InicializarVariablesEscritura()
        {
            _OH_14_7_PHK_2_DS = new VariableDigital<bool>() { Id = 2300, Nombre = "OH_14_7_PHK_2_DS" }; variablesEscritura.Add(_OH_14_7_PHK_2_DS);
            _OH_14_8_PHK_2_DS = new VariableDigital<bool>() { Id = 2301, Nombre = "OH_14_8_PHK_2_DS" }; variablesEscritura.Add(_OH_14_8_PHK_2_DS);
            _OH_14_9_PHK_2_DS = new VariableDigital<bool>() { Id = 2302, Nombre = "OH_14_9_PHK_2_DS" }; variablesEscritura.Add(_OH_14_9_PHK_2_DS);
            _OH_14_10_PHK_2_DS = new VariableDigital<bool>() { Id = 2303, Nombre = "OH_14_10_PHK_2_DS" }; variablesEscritura.Add(_OH_14_10_PHK_2_DS);
            _OH_14_11_PHK_2_DS = new VariableDigital<bool>() { Id = 2304, Nombre = "OH_14_11_PHK_2_DS" }; variablesEscritura.Add(_OH_14_11_PHK_2_DS);
            _OH_14_12_PHK_2_DS = new VariableDigital<bool>() { Id = 2305, Nombre = "OH_14_12_PHK_2_DS" }; variablesEscritura.Add(_OH_14_12_PHK_2_DS);
            _OH_15_1_PH_2_DS = new VariableDigital<bool>() { Id = 2306, Nombre = "OH_15_1_PH_2_DS" }; variablesEscritura.Add(_OH_15_1_PH_2_DS);
            _OH_15_4_PH_2_DS = new VariableDigital<bool>() { Id = 2307, Nombre = "OH_15_3_PH_2_DS" }; variablesEscritura.Add(_OH_15_4_PH_2_DS);
            _OH_16_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2308, Nombre = "OH_16_1_PHK_2_DS" }; variablesEscritura.Add(_OH_16_1_PHK_2_DS);
            _OH_16_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2309, Nombre = "OH_16_2_PHK_2_DS" }; variablesEscritura.Add(_OH_16_2_PHK_2_DS);
            _OH_16_3_PHK_2_DS = new VariableDigital<bool>() { Id = 2310, Nombre = "OH_16_3_PHK_2_DS" }; variablesEscritura.Add(_OH_16_3_PHK_2_DS);
            _OH_16_4_PHK_2_DS = new VariableDigital<bool>() { Id = 2311, Nombre = "OH_16_4_PHK_2_DS" }; variablesEscritura.Add(_OH_16_4_PHK_2_DS);
            _OH_16_5_PHK_2_DS = new VariableDigital<bool>() { Id = 2312, Nombre = "OH_16_5_PHK_2_DS" }; variablesEscritura.Add(_OH_16_5_PHK_2_DS);
            _OH_16_6_PHK_2_DS = new VariableDigital<bool>() { Id = 2313, Nombre = "OH_16_6_PHK_2_DS" }; variablesEscritura.Add(_OH_16_6_PHK_2_DS);
            _OH_16_7_PHK_2_DS = new VariableDigital<bool>() { Id = 2314, Nombre = "OH_16_7_PHK_2_DS" }; variablesEscritura.Add(_OH_16_7_PHK_2_DS);
            _OH_16_8_PHK_2_DS = new VariableDigital<bool>() { Id = 2315, Nombre = "OH_16_8_PHK_2_DS" }; variablesEscritura.Add(_OH_16_8_PHK_2_DS);
        }
        #endregion MetodosPrivados
    }
}
