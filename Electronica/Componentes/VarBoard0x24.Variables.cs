using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x24
    {
        #region Propiedades y variables
        public VariableDigital<bool> _OH_10_50_RS_3_1_DE; public bool OH_10_50_RS_3_1_DE (){ return _OH_10_50_RS_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_10_50_RS_3_2_DE; public bool OH_10_50_RS_3_2_DE() { return _OH_10_50_RS_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_10_50_RS_3_3_DE; public bool OH_10_50_RS_3_3_DE() { return _OH_10_50_RS_3_3_DE.Valor; }
        public VariableDigital<bool> _OH_10_51_SW_2_DE; public bool OH_10_51_SW_2_DE() { return _OH_10_51_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_10_53_RS_2_1_DE; public bool OH_10_53_RS_3_1_DE() { return _OH_10_53_RS_2_1_DE.Valor; }
        public VariableDigital<bool> _OH_10_53_RS_2_2_DE; public bool OH_10_53_RS_3_2_DE() { return _OH_10_53_RS_2_2_DE.Valor; }
        public VariableDigital<bool> _OH_10_59_RS_3_1_DE; public bool OH_10_59_RS_3_1_DE() { return _OH_10_59_RS_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_10_59_RS_3_2_DE; public bool OH_10_59_RS_3_2_DE() { return _OH_10_59_RS_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_10_59_RS_3_3_DE; public bool OH_10_59_RS_3_3_DE() { return _OH_10_59_RS_3_3_DE.Valor; }

        private VariableDigital<bool> _OH_10_7_PHK_2_DS; public bool OH_10_7_PHK_2_DS { get => _OH_10_7_PHK_2_DS.Valor; set => _OH_10_7_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_8_PHK_2_DS; public bool OH_10_8_PHK_2_DS { get => _OH_10_8_PHK_2_DS.Valor; set => _OH_10_8_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_9_PHK_2_DS; public bool OH_10_9_PHK_2_DS { get => _OH_10_9_PHK_2_DS.Valor; set => _OH_10_9_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_10_PHK_2_DS; public bool OH_10_10_PHK_2_DS { get => _OH_10_10_PHK_2_DS.Valor; set => _OH_10_10_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_11_PHK_2_DS; public bool OH_10_11_PHK_2_DS { get => _OH_10_11_PHK_2_DS.Valor; set => _OH_10_11_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_12_PHK_2_DS; public bool OH_10_12_PHK_2_DS { get => _OH_10_12_PHK_2_DS.Valor; set => _OH_10_12_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_13_PHK_2_DS; public bool OH_10_13_PHK_2_DS { get => _OH_10_13_PHK_2_DS.Valor; set => _OH_10_13_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_14_PHK_2_DS; public bool OH_10_14_PHK_2_DS { get => _OH_10_14_PHK_2_DS.Valor; set => _OH_10_14_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_15_PHK_2_DS; public bool OH_10_15_PHK_2_DS { get => _OH_10_15_PHK_2_DS.Valor; set => _OH_10_15_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_16_PHK_2_DS; public bool OH_10_16_PHK_2_DS { get => _OH_10_16_PHK_2_DS.Valor; set => _OH_10_16_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_17_PHK_2_DS; public bool OH_10_17_PHK_2_DS { get => _OH_10_17_PHK_2_DS.Valor; set => _OH_10_17_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_18_PHK_2_DS; public bool OH_10_18_PHK_2_DS { get => _OH_10_18_PHK_2_DS.Valor; set => _OH_10_18_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_19_PHK_2_DS; public bool OH_10_19_PHK_2_DS { get => _OH_10_19_PHK_2_DS.Valor; set => _OH_10_19_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_20_PHK_2_DS; public bool OH_10_20_PHK_2_DS { get => _OH_10_20_PHK_2_DS.Valor; set => _OH_10_20_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_21_PHK_2_DS; public bool OH_10_21_PHK_2_DS { get => _OH_10_21_PHK_2_DS.Valor; set => _OH_10_21_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_22_PHK_2_DS; public bool OH_10_22_PHK_2_DS { get => _OH_10_22_PHK_2_DS.Valor; set => _OH_10_22_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_23_PHK_2_DS; public bool OH_10_23_PHK_2_DS { get => _OH_10_23_PHK_2_DS.Valor; set => _OH_10_23_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_24_PHK_2_DS; public bool OH_10_24_PHK_2_DS { get => _OH_10_24_PHK_2_DS.Valor; set => _OH_10_24_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_25_PHK_2_DS; public bool OH_10_25_PHK_2_DS { get => _OH_10_25_PHK_2_DS.Valor; set => _OH_10_25_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_26_PHK_2_DS; public bool OH_10_26_PHK_2_DS { get => _OH_10_26_PHK_2_DS.Valor; set => _OH_10_26_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_48_PHK_2_DS; public bool OH_10_48_PHK_2_DS { get => _OH_10_48_PHK_2_DS.Valor; set => _OH_10_48_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_52_PHK_2_DS; public bool OH_10_52_PHK_2_DS { get => _OH_10_52_PHK_2_DS.Valor; set => _OH_10_52_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_10_58_PHK_2_DS; public bool OH_10_58_PHK_2_DS { get => _OH_10_58_PHK_2_DS.Valor; set => _OH_10_58_PHK_2_DS.Valor = value; }

        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _OH_10_50_RS_3_1_DE = new VariableDigital<bool>() { Id = 150, Nombre = "OH_10_50_RS_3_1_DE" }; variablesLectura.Add(_OH_10_50_RS_3_1_DE);
            _OH_10_50_RS_3_2_DE = new VariableDigital<bool>() { Id = 151, Nombre = "OH_10_50_RS_3_2_DE" }; variablesLectura.Add(_OH_10_50_RS_3_2_DE);
            _OH_10_50_RS_3_3_DE = new VariableDigital<bool>() { Id = 152, Nombre = "OH_10_50_RS_3_3_DE" }; variablesLectura.Add(_OH_10_50_RS_3_3_DE);
            _OH_10_51_SW_2_DE = new VariableDigital<bool>() { Id = 153, Nombre = "OH_10_51_SW_2_DE" }; variablesLectura.Add(_OH_10_51_SW_2_DE);
            _OH_10_53_RS_2_1_DE = new VariableDigital<bool>() { Id = 154, Nombre = "OH_10_53_RS_3_1_DE" }; variablesLectura.Add(_OH_10_53_RS_2_1_DE);
            _OH_10_53_RS_2_2_DE = new VariableDigital<bool>() { Id = 155, Nombre = "OH_10_53_RS_3_2_DE" }; variablesLectura.Add(_OH_10_53_RS_2_2_DE);
            _OH_10_59_RS_3_1_DE = new VariableDigital<bool>() { Id = 156, Nombre = "OH_10_59_RS_3_1_DE" }; variablesLectura.Add(_OH_10_59_RS_3_1_DE);
            _OH_10_59_RS_3_2_DE = new VariableDigital<bool>() { Id = 157, Nombre = "OH_10_59_RS_3_2_DE" }; variablesLectura.Add(_OH_10_59_RS_3_2_DE);
            _OH_10_59_RS_3_3_DE = new VariableDigital<bool>() { Id = 158, Nombre = "OH_10_59_RS_3_3_DE" }; variablesLectura.Add(_OH_10_59_RS_3_3_DE);
        }

        private void InicializarVariablesEscritura()
        {
            _OH_10_7_PHK_2_DS = new VariableDigital<bool>() { Id = 2150, Nombre = "OH_10_7_PHK_2_DS" }; variablesEscritura.Add(_OH_10_7_PHK_2_DS);
            _OH_10_8_PHK_2_DS = new VariableDigital<bool>() { Id = 2151, Nombre = "OH_10_8_PHK_2_DS" }; variablesEscritura.Add(_OH_10_8_PHK_2_DS);
            _OH_10_9_PHK_2_DS = new VariableDigital<bool>() { Id = 2152, Nombre = "OH_10_9_PHK_2_DS" }; variablesEscritura.Add(_OH_10_9_PHK_2_DS);
            _OH_10_10_PHK_2_DS = new VariableDigital<bool>() { Id = 2153, Nombre = "OH_10_10_PHK_2_DS" }; variablesEscritura.Add(_OH_10_10_PHK_2_DS);
            _OH_10_11_PHK_2_DS = new VariableDigital<bool>() { Id = 2154, Nombre = "OH_10_11_PHK_2_DS" }; variablesEscritura.Add(_OH_10_11_PHK_2_DS);
            _OH_10_12_PHK_2_DS = new VariableDigital<bool>() { Id = 2155, Nombre = "OH_10_12_PHK_2_DS" }; variablesEscritura.Add(_OH_10_12_PHK_2_DS);
            _OH_10_13_PHK_2_DS = new VariableDigital<bool>() { Id = 2156, Nombre = "OH_10_13_PHK_2_DS" }; variablesEscritura.Add(_OH_10_13_PHK_2_DS);
            _OH_10_14_PHK_2_DS = new VariableDigital<bool>() { Id = 2157, Nombre = "OH_10_14_PHK_2_DS" }; variablesEscritura.Add(_OH_10_14_PHK_2_DS);
            _OH_10_15_PHK_2_DS = new VariableDigital<bool>() { Id = 2158, Nombre = "OH_10_15_PHK_2_DS" }; variablesEscritura.Add(_OH_10_15_PHK_2_DS);
            _OH_10_16_PHK_2_DS = new VariableDigital<bool>() { Id = 2159, Nombre = "OH_10_16_PHK_2_DS" }; variablesEscritura.Add(_OH_10_16_PHK_2_DS);
            _OH_10_17_PHK_2_DS = new VariableDigital<bool>() { Id = 2160, Nombre = "OH_10_17_PHK_2_DS" }; variablesEscritura.Add(_OH_10_17_PHK_2_DS);
            _OH_10_18_PHK_2_DS = new VariableDigital<bool>() { Id = 2161, Nombre = "OH_10_18_PHK_2_DS" }; variablesEscritura.Add(_OH_10_18_PHK_2_DS);
            _OH_10_19_PHK_2_DS = new VariableDigital<bool>() { Id = 2162, Nombre = "OH_10_19_PHK_2_DS" }; variablesEscritura.Add(_OH_10_19_PHK_2_DS);
            _OH_10_20_PHK_2_DS = new VariableDigital<bool>() { Id = 2163, Nombre = "OH_10_20_PHK_2_DS" }; variablesEscritura.Add(_OH_10_20_PHK_2_DS);
            _OH_10_21_PHK_2_DS = new VariableDigital<bool>() { Id = 2164, Nombre = "OH_10_21_PHK_2_DS" }; variablesEscritura.Add(_OH_10_21_PHK_2_DS);
            _OH_10_22_PHK_2_DS = new VariableDigital<bool>() { Id = 2165, Nombre = "OH_10_22_PHK_2_DS" }; variablesEscritura.Add(_OH_10_22_PHK_2_DS);
            _OH_10_23_PHK_2_DS = new VariableDigital<bool>() { Id = 2166, Nombre = "OH_10_23_PHK_2_DS" }; variablesEscritura.Add(_OH_10_23_PHK_2_DS);
            _OH_10_24_PHK_2_DS = new VariableDigital<bool>() { Id = 2167, Nombre = "OH_10_24_PHK_2_DS" }; variablesEscritura.Add(_OH_10_24_PHK_2_DS);
            _OH_10_25_PHK_2_DS = new VariableDigital<bool>() { Id = 2168, Nombre = "OH_10_25_PHK_2_DS" }; variablesEscritura.Add(_OH_10_25_PHK_2_DS);
            _OH_10_26_PHK_2_DS = new VariableDigital<bool>() { Id = 2169, Nombre = "OH_10_26_PHK_2_DS" }; variablesEscritura.Add(_OH_10_26_PHK_2_DS);
            _OH_10_48_PHK_2_DS = new VariableDigital<bool>() { Id = 2170, Nombre = "OH_10_48_PHK_2_DS" }; variablesEscritura.Add(_OH_10_48_PHK_2_DS);
            _OH_10_52_PHK_2_DS = new VariableDigital<bool>() { Id = 2171, Nombre = "OH_10_52_PHK_2_DS" }; variablesEscritura.Add(_OH_10_52_PHK_2_DS);
            _OH_10_58_PHK_2_DS = new VariableDigital<bool>() { Id = 2172, Nombre = "OH_10_58_PHK_2_DS" }; variablesEscritura.Add(_OH_10_58_PHK_2_DS);
        }
        #endregion MetodosPrivados
    }
}
