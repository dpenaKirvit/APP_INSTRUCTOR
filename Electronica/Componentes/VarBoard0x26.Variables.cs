using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x26
    {
        #region Propiedades y variables
        public VariableDigital<bool> _OH_11_56_SW_2_DE; public bool OH_11_56_SW_2_DE (){ return _OH_11_56_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_11_57_RS_2_1_DE; public bool OH_11_57_RS_2_1_DE() { return _OH_11_57_RS_2_1_DE.Valor; }
        public VariableDigital<bool> _OH_11_57_RS_2_2_DE; public bool OH_11_57_RS_2_2_DE() { return _OH_11_57_RS_2_2_DE.Valor; }
        public VariableDigital<bool> _OH_11_59_SW_2_DE; public bool OH_11_59_SW_2_DE() { return _OH_11_59_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_1_SW_2_DE; public bool OH_12_1_SW_2_DE() { return _OH_12_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_2_SW_3_1_DE; public bool OH_12_2_SW_3_1_DE() { return _OH_12_2_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_12_2_SW_3_2_DE; public bool OH_12_2_SW_3_2_DE() { return _OH_12_2_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_3_SW_2_DE; public bool OH_12_3_SW_2_DE() { return _OH_12_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_4_PL_2_DE; public bool OH_12_4_PL_2_DE() { return _OH_12_4_PL_2_DE.Valor; }        
        public VariableDigital<bool> _OH_12_5_PL_2_DE; public bool OH_12_5_PL_2_DE() { return _OH_12_5_PL_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_6_SW_3_1_DE; public bool OH_12_6_SW_3_1_DE() { return _OH_12_6_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_12_6_SW_3_2_DE; public bool OH_12_6_SW_3_2_DE() { return _OH_12_6_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_7_PL_2_DE; public bool OH_12_7_PL_2_DE() { return _OH_12_7_PL_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_9_PL_2_DE; public bool OH_12_9_PL_2_DE() { return _OH_12_9_PL_2_DE.Valor; }
        public VariableDigital<bool> _OH_12_8_PL_2_DE; public bool OH_12_8_PL_2_DE() { return _OH_12_8_PL_2_DE.Valor; }

        private VariableDigital<bool> _OH_11_5_PHK_2_DS; public bool OH_11_5_PHK_2_DS { get => _OH_11_5_PHK_2_DS.Valor; set => _OH_11_5_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_11_PHK_2_DS; public bool OH_11_11_PHK_2_DS { get => _OH_11_11_PHK_2_DS.Valor; set => _OH_11_11_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_19_PHK_2_DS; public bool OH_11_19_PHK_2_DS { get => _OH_11_19_PHK_2_DS.Valor; set => _OH_11_19_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_27_PHK_2_DS; public bool OH_11_27_PHK_2_DS { get => _OH_11_27_PHK_2_DS.Valor; set => _OH_11_27_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_30_PHK_2_DS; public bool OH_11_30_PHK_2_DS { get => _OH_11_30_PHK_2_DS.Valor; set => _OH_11_30_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_34_PHK_2_DS; public bool OH_11_34_PHK_2_DS { get => _OH_11_34_PHK_2_DS.Valor; set => _OH_11_34_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_42_PHK_2_DS; public bool OH_11_42_PHK_2_DS { get => _OH_11_42_PHK_2_DS.Valor; set => _OH_11_42_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_52_PHK_2_DS; public bool OH_11_52_PHK_2_DS { get => _OH_11_52_PHK_2_DS.Valor; set => _OH_11_52_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_11_58_PHK_2_DS; public bool OH_11_58_PHK_2_DS { get => _OH_11_58_PHK_2_DS.Valor; set => _OH_11_58_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_4_PL_2_R_DS; public bool OH_12_4_PL_2_R_DS { get => _OH_12_4_PL_2_R_DS.Valor; set => _OH_12_4_PL_2_R_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_5_PL_2_R_DS; public bool OH_12_5_PL_2_R_DS { get => _OH_12_5_PL_2_R_DS.Valor; set => _OH_12_5_PL_2_R_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_7_PL_2_R_DS; public bool OH_12_7_PL_2_R_DS { get => _OH_12_7_PL_2_R_DS.Valor; set => _OH_12_7_PL_2_R_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_9_PL_2_R_DS; public bool OH_12_9_PL_2_R_DS { get => _OH_12_9_PL_2_R_DS.Valor; set => _OH_12_9_PL_2_R_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_8_PL_2_R_DS; public bool OH_12_8_PL_2_R_DS { get => _OH_12_8_PL_2_R_DS.Valor; set => _OH_12_8_PL_2_R_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_4_PL_2_F_DS; public bool OH_12_4_PL_2_F_DS { get => _OH_12_4_PL_2_F_DS.Valor; set => _OH_12_4_PL_2_F_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_5_PL_2_F_DS; public bool OH_12_5_PL_2_F_DS { get => _OH_12_5_PL_2_F_DS.Valor; set => _OH_12_5_PL_2_F_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_7_PL_2_F_DS; public bool OH_12_7_PL_2_F_DS { get => _OH_12_7_PL_2_F_DS.Valor; set => _OH_12_7_PL_2_F_DS.Valor = value; }
        private VariableDigital<bool> _OH_12_8_PL_2_F_DS; public bool OH_12_8_PL_2_F_DS { get => _OH_12_8_PL_2_F_DS.Valor; set => _OH_12_8_PL_2_F_DS.Valor = value; }
        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _OH_11_56_SW_2_DE = new VariableDigital<bool>() { Id = 250, Nombre = "OH_11_56_SW_2_DE" }; variablesLectura.Add(_OH_11_56_SW_2_DE);
            _OH_11_57_RS_2_1_DE = new VariableDigital<bool>() { Id = 251, Nombre = "OH_11_57_RS_2_1_DE" }; variablesLectura.Add(_OH_11_57_RS_2_1_DE);
            _OH_11_57_RS_2_2_DE = new VariableDigital<bool>() { Id = 252, Nombre = "OH_11_57_RS_2_2_DE" }; variablesLectura.Add(_OH_11_57_RS_2_2_DE);
            _OH_11_59_SW_2_DE = new VariableDigital<bool>() { Id = 253, Nombre = "OH_11_59_SW_2_DE" }; variablesLectura.Add(_OH_11_59_SW_2_DE);
            _OH_12_1_SW_2_DE = new VariableDigital<bool>() { Id = 254, Nombre = "OH_12_1_SW_2_DE" }; variablesLectura.Add(_OH_12_1_SW_2_DE);
            _OH_12_2_SW_3_1_DE = new VariableDigital<bool>() { Id = 255, Nombre = "OH_12_2_SW_3_1_DE" }; variablesLectura.Add(_OH_12_2_SW_3_1_DE);
            _OH_12_2_SW_3_2_DE = new VariableDigital<bool>() { Id = 256, Nombre = "OH_12_2_SW_3_2_DE" }; variablesLectura.Add(_OH_12_2_SW_3_2_DE);
            _OH_12_3_SW_2_DE = new VariableDigital<bool>() { Id = 257, Nombre = "OH_12_3_SW_2_DE" }; variablesLectura.Add(_OH_12_3_SW_2_DE);
            _OH_12_4_PL_2_DE = new VariableDigital<bool>() { Id = 258, Nombre = "OH_12_4_PL_2_DE" }; variablesLectura.Add(_OH_12_4_PL_2_DE);
            _OH_12_5_PL_2_DE = new VariableDigital<bool>() { Id = 259, Nombre = "OH_12_5_PL_2_DE" }; variablesLectura.Add(_OH_12_5_PL_2_DE);
            _OH_12_6_SW_3_1_DE = new VariableDigital<bool>() { Id = 260, Nombre = "OH_12_6_SW_3_1_DE" }; variablesLectura.Add(_OH_12_6_SW_3_1_DE);
            _OH_12_6_SW_3_2_DE = new VariableDigital<bool>() { Id = 261, Nombre = "OH_12_6_SW_3_2_DE" }; variablesLectura.Add(_OH_12_6_SW_3_2_DE);
            _OH_12_7_PL_2_DE = new VariableDigital<bool>() { Id = 262, Nombre = "OH_12_7_PL_2_DE" }; variablesLectura.Add(_OH_12_7_PL_2_DE);
            _OH_12_9_PL_2_DE = new VariableDigital<bool>() { Id = 263, Nombre = "OH_12_9_PL_2_DE" }; variablesLectura.Add(_OH_12_9_PL_2_DE);
            _OH_12_8_PL_2_DE = new VariableDigital<bool>() { Id = 264, Nombre = "OH_12_8_PL_2_DE" }; variablesLectura.Add(_OH_12_8_PL_2_DE);
        }

        private void InicializarVariablesEscritura()
        {
            _OH_11_5_PHK_2_DS = new VariableDigital<bool>() { Id = 2250, Nombre = "OH_11_5_PHK_2_DS" }; variablesEscritura.Add(_OH_11_5_PHK_2_DS);
            _OH_11_11_PHK_2_DS = new VariableDigital<bool>() { Id = 2251, Nombre = "OH_11_11_PHK_2_DS" }; variablesEscritura.Add(_OH_11_11_PHK_2_DS);
            _OH_11_19_PHK_2_DS = new VariableDigital<bool>() { Id = 2252, Nombre = "OH_11_19_PHK_2_DS" }; variablesEscritura.Add(_OH_11_19_PHK_2_DS);
            _OH_11_27_PHK_2_DS = new VariableDigital<bool>() { Id = 2253, Nombre = "OH_11_27_PHK_2_DS" }; variablesEscritura.Add(_OH_11_27_PHK_2_DS);
            _OH_11_30_PHK_2_DS = new VariableDigital<bool>() { Id = 2254, Nombre = "OH_11_30_PHK_2_DS" }; variablesEscritura.Add(_OH_11_30_PHK_2_DS);
            _OH_11_34_PHK_2_DS = new VariableDigital<bool>() { Id = 2255, Nombre = "OH_11_34_PHK_2_DS" }; variablesEscritura.Add(_OH_11_34_PHK_2_DS);
            _OH_11_42_PHK_2_DS = new VariableDigital<bool>() { Id = 2256, Nombre = "OH_11_42_PHK_2_DS" }; variablesEscritura.Add(_OH_11_42_PHK_2_DS);
            _OH_11_52_PHK_2_DS = new VariableDigital<bool>() { Id = 2257, Nombre = "OH_11_52_PHK_2_DS" }; variablesEscritura.Add(_OH_11_52_PHK_2_DS);
            _OH_11_58_PHK_2_DS = new VariableDigital<bool>() { Id = 2258, Nombre = "OH_11_58_PHK_2_DS" }; variablesEscritura.Add(_OH_11_58_PHK_2_DS);
            _OH_12_4_PL_2_R_DS = new VariableDigital<bool>() { Id = 2259, Nombre = "OH_12_4_PL_2_R_DS" }; variablesEscritura.Add(_OH_12_4_PL_2_R_DS);
            _OH_12_5_PL_2_R_DS = new VariableDigital<bool>() { Id = 2260, Nombre = "OH_12_5_PL_2_R_DS" }; variablesEscritura.Add(_OH_12_5_PL_2_R_DS);
            _OH_12_7_PL_2_R_DS = new VariableDigital<bool>() { Id = 2261, Nombre = "OH_12_7_PL_2_R_DS" }; variablesEscritura.Add(_OH_12_7_PL_2_R_DS);
            _OH_12_9_PL_2_R_DS = new VariableDigital<bool>() { Id = 2262, Nombre = "OH_12_9_PL_2_R_DS" }; variablesEscritura.Add(_OH_12_9_PL_2_R_DS);
            _OH_12_8_PL_2_R_DS = new VariableDigital<bool>() { Id = 2263, Nombre = "OH_12_8_PL_2_R_DS" }; variablesEscritura.Add(_OH_12_8_PL_2_R_DS);
            _OH_12_4_PL_2_F_DS = new VariableDigital<bool>() { Id = 2264, Nombre = "OH_12_4_PL_2_F_DS" }; variablesEscritura.Add(_OH_12_4_PL_2_F_DS);
            _OH_12_5_PL_2_F_DS = new VariableDigital<bool>() { Id = 2265, Nombre = "OH_12_5_PL_2_F_DS" }; variablesEscritura.Add(_OH_12_5_PL_2_F_DS);
            _OH_12_7_PL_2_F_DS = new VariableDigital<bool>() { Id = 2266, Nombre = "OH_12_7_PL_2_F_DS" }; variablesEscritura.Add(_OH_12_7_PL_2_F_DS);
            _OH_12_8_PL_2_F_DS = new VariableDigital<bool>() { Id = 2267, Nombre = "OH_12_8_PL_2_F_DS" }; variablesEscritura.Add(_OH_12_8_PL_2_F_DS);

        }
        #endregion MetodosPrivados
    }
}
