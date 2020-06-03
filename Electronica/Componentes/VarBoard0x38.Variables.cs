using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x38
    {
        #region Propiedades y variables
        public VariableDigital<bool> _PB_1_1_CC_2_DE; public bool PB_1_1_CC_2_DE() { return _PB_1_1_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_2_CC_2_DE; public bool PB_1_2_CC_2_DE() { return _PB_1_2_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_3_CC_2_DE; public bool PB_1_3_CC_2_DE() { return _PB_1_3_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_4_CC_2_DE; public bool PB_1_4_CC_2_DE() { return _PB_1_4_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_5_CC_2_DE; public bool PB_1_5_CC_2_DE() { return _PB_1_5_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_6_CC_2_DE; public bool PB_1_6_CC_2_DE() { return _PB_1_6_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_7_CC_2_DE; public bool PB_1_7_CC_2_DE() { return _PB_1_7_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_8_CC_2_DE; public bool PB_1_8_CC_2_DE() { return _PB_1_8_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_9_CC_2_DE; public bool PB_1_9_CC_2_DE() { return _PB_1_9_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_10_CC_2_DE; public bool PB_1_10_CC_2_DE() { return _PB_1_10_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_11_CC_2_DE; public bool PB_1_11_CC_2_DE() { return _PB_1_11_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_12_CC_2_DE; public bool PB_1_12_CC_2_DE() { return _PB_1_12_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_13_CC_2_DE; public bool PB_1_13_CC_2_DE() { return _PB_1_13_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_14_CC_2_DE; public bool PB_1_14_CC_2_DE() { return _PB_1_14_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_15_CC_2_DE; public bool PB_1_15_CC_2_DE() { return _PB_1_15_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_16_CC_2_DE; public bool PB_1_16_CC_2_DE() { return _PB_1_16_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_17_CC_2_DE; public bool PB_1_17_CC_2_DE() { return _PB_1_17_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_18_CC_2_DE; public bool PB_1_18_CC_2_DE() { return _PB_1_18_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_19_CC_2_DE; public bool PB_1_19_CC_2_DE() { return _PB_1_19_CC_2_DE.Valor; }
        public VariableDigital<bool> _PB_1_20_CC_2_DE; public bool PB_1_20_CC_2_DE() { return _PB_1_20_CC_2_DE.Valor; }

        private VariableDigital<bool> _PB_1_1_CC_2_DS; public bool PB_1_1_CC_2_DS { get => _PB_1_1_CC_2_DS.Valor; set => _PB_1_1_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_2_CC_2_DS; public bool PB_1_2_CC_2_DS { get => _PB_1_2_CC_2_DS.Valor; set => _PB_1_2_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_3_CC_2_DS; public bool PB_1_3_CC_2_DS { get => _PB_1_3_CC_2_DS.Valor; set => _PB_1_3_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_4_CC_2_DS; public bool PB_1_4_CC_2_DS { get => _PB_1_4_CC_2_DS.Valor; set => _PB_1_4_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_5_CC_2_DS; public bool PB_1_5_CC_2_DS { get => _PB_1_5_CC_2_DS.Valor; set => _PB_1_5_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_6_CC_2_DS; public bool PB_1_6_CC_2_DS { get => _PB_1_6_CC_2_DS.Valor; set => _PB_1_6_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_7_CC_2_DS; public bool PB_1_7_CC_2_DS { get => _PB_1_7_CC_2_DS.Valor; set => _PB_1_7_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_8_CC_2_DS; public bool PB_1_8_CC_2_DS { get => _PB_1_8_CC_2_DS.Valor; set => _PB_1_8_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_9_CC_2_DS; public bool PB_1_9_CC_2_DS { get => _PB_1_9_CC_2_DS.Valor; set => _PB_1_9_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_10_CC_2_DS; public bool PB_1_10_CC_2_DS { get => _PB_1_10_CC_2_DS.Valor; set => _PB_1_10_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_11_CC_2_DS; public bool PB_1_11_CC_2_DS { get => _PB_1_11_CC_2_DS.Valor; set => _PB_1_11_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_12_CC_2_DS; public bool PB_1_12_CC_2_DS { get => _PB_1_12_CC_2_DS.Valor; set => _PB_1_12_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_13_CC_2_DS; public bool PB_1_13_CC_2_DS { get => _PB_1_13_CC_2_DS.Valor; set => _PB_1_13_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_14_CC_2_DS; public bool PB_1_14_CC_2_DS { get => _PB_1_14_CC_2_DS.Valor; set => _PB_1_14_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_15_CC_2_DS; public bool PB_1_15_CC_2_DS { get => _PB_1_15_CC_2_DS.Valor; set => _PB_1_15_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_16_CC_2_DS; public bool PB_1_16_CC_2_DS { get => _PB_1_16_CC_2_DS.Valor; set => _PB_1_16_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_17_CC_2_DS; public bool PB_1_17_CC_2_DS { get => _PB_1_17_CC_2_DS.Valor; set => _PB_1_17_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_18_CC_2_DS; public bool PB_1_18_CC_2_DS { get => _PB_1_18_CC_2_DS.Valor; set => _PB_1_18_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_19_CC_2_DS; public bool PB_1_19_CC_2_DS { get => _PB_1_19_CC_2_DS.Valor; set => _PB_1_19_CC_2_DS.Valor = value; }
        private VariableDigital<bool> _PB_1_20_CC_2_DS; public bool PB_1_20_CC_2_DS { get => _PB_1_20_CC_2_DS.Valor; set => _PB_1_20_CC_2_DS.Valor = value; }


        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _PB_1_1_CC_2_DE = new VariableDigital<bool>() { Id = 1250, Nombre = "PB_1_1_CC_2_DE" }; variablesLectura.Add(_PB_1_1_CC_2_DE);
            _PB_1_2_CC_2_DE = new VariableDigital<bool>() { Id = 1251, Nombre = "PB_1_2_CC_2_DE" }; variablesLectura.Add(_PB_1_2_CC_2_DE);
            _PB_1_3_CC_2_DE = new VariableDigital<bool>() { Id = 1252, Nombre = "PB_1_3_CC_2_DE" }; variablesLectura.Add(_PB_1_3_CC_2_DE);
            _PB_1_4_CC_2_DE = new VariableDigital<bool>() { Id = 1253, Nombre = "PB_1_4_CC_2_DE" }; variablesLectura.Add(_PB_1_4_CC_2_DE);
            _PB_1_5_CC_2_DE = new VariableDigital<bool>() { Id = 1254, Nombre = "PB_1_5_CC_2_DE" }; variablesLectura.Add(_PB_1_5_CC_2_DE);
            _PB_1_6_CC_2_DE = new VariableDigital<bool>() { Id = 1255, Nombre = "PB_1_6_CC_2_DE" }; variablesLectura.Add(_PB_1_6_CC_2_DE);
            _PB_1_7_CC_2_DE = new VariableDigital<bool>() { Id = 1256, Nombre = "PB_1_7_CC_2_DE" }; variablesLectura.Add(_PB_1_7_CC_2_DE);
            _PB_1_8_CC_2_DE = new VariableDigital<bool>() { Id = 1257, Nombre = "PB_1_8_CC_2_DE" }; variablesLectura.Add(_PB_1_8_CC_2_DE);
            _PB_1_9_CC_2_DE = new VariableDigital<bool>() { Id = 1258, Nombre = "PB_1_9_CC_2_DE" }; variablesLectura.Add(_PB_1_9_CC_2_DE);
            _PB_1_10_CC_2_DE = new VariableDigital<bool>() { Id = 1259, Nombre = "PB_1_10_CC_2_DE" }; variablesLectura.Add(_PB_1_10_CC_2_DE);
            _PB_1_11_CC_2_DE = new VariableDigital<bool>() { Id = 1260, Nombre = "PB_1_11_CC_2_DE" }; variablesLectura.Add(_PB_1_11_CC_2_DE);
            _PB_1_12_CC_2_DE = new VariableDigital<bool>() { Id = 1261, Nombre = "PB_1_12_CC_2_DE" }; variablesLectura.Add(_PB_1_12_CC_2_DE);
            _PB_1_13_CC_2_DE = new VariableDigital<bool>() { Id = 1262, Nombre = "PB_1_13_CC_2_DE" }; variablesLectura.Add(_PB_1_13_CC_2_DE);
            _PB_1_14_CC_2_DE = new VariableDigital<bool>() { Id = 1263, Nombre = "PB_1_14_CC_2_DE" }; variablesLectura.Add(_PB_1_14_CC_2_DE);
            _PB_1_15_CC_2_DE = new VariableDigital<bool>() { Id = 1264, Nombre = "PB_1_15_CC_2_DE" }; variablesLectura.Add(_PB_1_15_CC_2_DE);
            _PB_1_16_CC_2_DE = new VariableDigital<bool>() { Id = 1265, Nombre = "PB_1_16_CC_2_DE" }; variablesLectura.Add(_PB_1_16_CC_2_DE);
            _PB_1_17_CC_2_DE = new VariableDigital<bool>() { Id = 1266, Nombre = "PB_1_17_CC_2_DE" }; variablesLectura.Add(_PB_1_17_CC_2_DE);
            _PB_1_18_CC_2_DE = new VariableDigital<bool>() { Id = 1267, Nombre = "PB_1_18_CC_2_DE" }; variablesLectura.Add(_PB_1_18_CC_2_DE);
            _PB_1_19_CC_2_DE = new VariableDigital<bool>() { Id = 1268, Nombre = "PB_1_19_CC_2_DE" }; variablesLectura.Add(_PB_1_19_CC_2_DE);
            _PB_1_20_CC_2_DE = new VariableDigital<bool>() { Id = 1269, Nombre = "PB_1_20_CC_2_DE" }; variablesLectura.Add(_PB_1_20_CC_2_DE);

        }

        private void InicializarVariablesEscritura()
        {
            _PB_1_1_CC_2_DS = new VariableDigital<bool>() { Id = 3250, Nombre = "PB_1_1_CC_2_DS" }; variablesEscritura.Add(_PB_1_1_CC_2_DS);
            _PB_1_2_CC_2_DS = new VariableDigital<bool>() { Id = 3251, Nombre = "PB_1_2_CC_2_DS" }; variablesEscritura.Add(_PB_1_2_CC_2_DS);
            _PB_1_3_CC_2_DS = new VariableDigital<bool>() { Id = 3252, Nombre = "PB_1_3_CC_2_DS" }; variablesEscritura.Add(_PB_1_3_CC_2_DS);
            _PB_1_4_CC_2_DS = new VariableDigital<bool>() { Id = 3253, Nombre = "PB_1_4_CC_2_DS" }; variablesEscritura.Add(_PB_1_4_CC_2_DS);
            _PB_1_5_CC_2_DS = new VariableDigital<bool>() { Id = 3254, Nombre = "PB_1_5_CC_2_DS" }; variablesEscritura.Add(_PB_1_5_CC_2_DS);
            _PB_1_6_CC_2_DS = new VariableDigital<bool>() { Id = 3255, Nombre = "PB_1_6_CC_2_DS" }; variablesEscritura.Add(_PB_1_6_CC_2_DS);
            _PB_1_7_CC_2_DS = new VariableDigital<bool>() { Id = 3256, Nombre = "PB_1_7_CC_2_DS" }; variablesEscritura.Add(_PB_1_7_CC_2_DS);
            _PB_1_8_CC_2_DS = new VariableDigital<bool>() { Id = 3257, Nombre = "PB_1_8_CC_2_DS" }; variablesEscritura.Add(_PB_1_8_CC_2_DS);
            _PB_1_9_CC_2_DS = new VariableDigital<bool>() { Id = 3258, Nombre = "PB_1_9_CC_2_DS" }; variablesEscritura.Add(_PB_1_9_CC_2_DS);
            _PB_1_10_CC_2_DS = new VariableDigital<bool>() { Id = 3259, Nombre = "PB_1_10_CC_2_DS" }; variablesEscritura.Add(_PB_1_10_CC_2_DS);
            _PB_1_11_CC_2_DS = new VariableDigital<bool>() { Id = 3260, Nombre = "PB_1_11_CC_2_DS" }; variablesEscritura.Add(_PB_1_11_CC_2_DS);
            _PB_1_12_CC_2_DS = new VariableDigital<bool>() { Id = 3261, Nombre = "PB_1_12_CC_2_DS" }; variablesEscritura.Add(_PB_1_12_CC_2_DS);
            _PB_1_13_CC_2_DS = new VariableDigital<bool>() { Id = 3262, Nombre = "PB_1_13_CC_2_DS" }; variablesEscritura.Add(_PB_1_13_CC_2_DS);
            _PB_1_14_CC_2_DS = new VariableDigital<bool>() { Id = 3263, Nombre = "PB_1_14_CC_2_DS" }; variablesEscritura.Add(_PB_1_14_CC_2_DS);
            _PB_1_15_CC_2_DS = new VariableDigital<bool>() { Id = 3264, Nombre = "PB_1_15_CC_2_DS" }; variablesEscritura.Add(_PB_1_15_CC_2_DS);
            _PB_1_16_CC_2_DS = new VariableDigital<bool>() { Id = 3265, Nombre = "PB_1_16_CC_2_DS" }; variablesEscritura.Add(_PB_1_16_CC_2_DS);
            _PB_1_17_CC_2_DS = new VariableDigital<bool>() { Id = 3266, Nombre = "PB_1_17_CC_2_DS" }; variablesEscritura.Add(_PB_1_17_CC_2_DS);
            _PB_1_18_CC_2_DS = new VariableDigital<bool>() { Id = 3267, Nombre = "PB_1_18_CC_2_DS" }; variablesEscritura.Add(_PB_1_18_CC_2_DS);
            _PB_1_19_CC_2_DS = new VariableDigital<bool>() { Id = 3268, Nombre = "PB_1_19_CC_2_DS" }; variablesEscritura.Add(_PB_1_19_CC_2_DS);
            _PB_1_20_CC_2_DS = new VariableDigital<bool>() { Id = 3269, Nombre = "PB_1_20_CC_2_DS" }; variablesEscritura.Add(_PB_1_20_CC_2_DS);

        }
        #endregion MetodosPrivados
    }
}
