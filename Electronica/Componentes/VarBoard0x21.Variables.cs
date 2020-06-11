using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x21
    {
        #region Propiedades y variables
        public VariableDigital<bool> _OH_1_1_SW_2_DE; public bool OH_1_1_SW_2_DE() { return _OH_1_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_1_2_SW_2_DE; public bool OH_1_2_SW_2_DE() { return _OH_1_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_1_3_SW_2_DE; public bool OH_1_3_SW_2_DE() { return _OH_1_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_1_4_SW_2_DE; public bool OH_1_4_SW_2_DE() { return _OH_1_4_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_2_2_SW_3_1_DE; public bool OH_2_2_SW_3_1_DE() { return _OH_2_2_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_2_2_SW_3_2_DE; public bool OH_2_2_SW_3_2_DE() { return _OH_2_2_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_3_1_SW_2_DE; public bool OH_3_1_SW_2_DE() { return _OH_3_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_3_2_SW_2_DE; public bool OH_3_2_SW_2_DE() { return _OH_3_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_3_3_SW_2_DE; public bool OH_3_3_SW_2_DE() { return _OH_3_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_4_SW_2_DE; public bool OH_6_4_SW_2_DE() { return _OH_6_4_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_5_RS_5_1_DE; public bool OH_6_5_RS_5_1_DE() { return _OH_6_5_RS_5_1_DE.Valor; }
        public VariableDigital<bool> _OH_6_5_RS_5_2_DE; public bool OH_6_5_RS_5_2_DE() { return _OH_6_5_RS_5_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_5_RS_5_3_DE; public bool OH_6_5_RS_5_3_DE() { return _OH_6_5_RS_5_3_DE.Valor; }
        public VariableDigital<bool> _OH_6_5_RS_5_4_DE; public bool OH_6_5_RS_5_4_DE() { return _OH_6_5_RS_5_4_DE.Valor; }
        public VariableDigital<bool> _OH_6_5_RS_5_5_DE; public bool OH_6_5_RS_5_5_DE() { return _OH_6_5_RS_5_5_DE.Valor; }
        public VariableDigital<bool> _OH_6_6_RS_4_1_DE; public bool OH_6_6_RS_4_1_DE() { return _OH_6_6_RS_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_6_6_RS_4_2_DE; public bool OH_6_6_RS_4_2_DE() { return _OH_6_6_RS_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_6_RS_4_3_DE; public bool OH_6_6_RS_4_3_DE() { return _OH_6_6_RS_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_6_6_RS_4_4_DE; public bool OH_6_6_RS_4_4_DE() { return _OH_6_6_RS_4_4_DE.Valor; }
        public VariableDigital<bool> _OH_6_7_SW_2_DE; public bool OH_6_7_SW_2_DE() { return _OH_6_7_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_10_SW_4_1_DE; public bool OH_6_10_SW_4_1_DE() { return _OH_6_10_SW_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_6_10_SW_4_2_DE; public bool OH_6_10_SW_4_2_DE() { return _OH_6_10_SW_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_10_SW_4_3_DE; public bool OH_6_10_SW_4_3_DE() { return _OH_6_10_SW_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_6_12_SW_2_DE; public bool OH_6_12_SW_2_DE() { return _OH_6_12_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_13_SW_3_1_DE; public bool OH_6_13_SW_3_1_DE() { return _OH_6_13_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_6_13_SW_3_2_DE; public bool OH_6_13_SW_3_2_DE() { return _OH_6_13_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_14_SW_2_DE; public bool OH_6_14_SW_2_DE() { return _OH_6_14_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_15_SW_2_DE; public bool OH_6_15_SW_2_DE() { return _OH_6_15_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_16_SW_4_1_DE; public bool OH_6_16_SW_4_1_DE() { return _OH_6_16_SW_4_1_DE.Valor; }
        public VariableDigital<bool> _OH_6_16_SW_4_2_DE; public bool OH_6_16_SW_4_2_DE() { return _OH_6_16_SW_4_2_DE.Valor; }
        public VariableDigital<bool> _OH_6_16_SW_4_3_DE; public bool OH_6_16_SW_4_3_DE() { return _OH_6_16_SW_4_3_DE.Valor; }
        public VariableDigital<bool> _OH_7_3_SW_2_DE; public bool OH_7_3_SW_2_DE() { return _OH_7_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_7_4_SW_3_1_DE; public bool OH_7_4_SW_3_1_DE() { return _OH_7_4_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_7_4_SW_3_2_DE; public bool OH_7_4_SW_3_2_DE() { return _OH_7_4_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_5_1_SW_3_1_DE; public bool OH_5_1_SW_3_1_DE() { return _OH_5_1_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _OH_5_1_SW_3_2_DE; public bool OH_5_1_SW_3_2_DE() { return _OH_5_1_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _OH_5_2_SW_2_DE; public bool OH_5_2_SW_2_DE() { return _OH_5_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _OH_5_3_SW_2_DE; public bool OH_5_3_SW_2_DE() { return _OH_5_3_SW_2_DE.Valor; }
        
        public VariableAnaloga _OH_6_1_PT_1_AE; public double OH_6_1_PT_1_AE { get => _OH_6_1_PT_1_AE.Valor; }
        public VariableAnaloga _OH_6_11_PT_1_AE; public double OH_6_11_PT_1_AE { get => _OH_6_11_PT_1_AE.Valor; }
        public VariableAnaloga _OH_6_17_PT_1_AE; public double OH_6_17_PT_1_AE { get => _OH_6_17_PT_1_AE.Valor; }

        public VariableEncoder _OH_6_3_PT_1_ENC; public VariableEncoder OH_6_3_PT_1_ENC { get => _OH_6_3_PT_1_ENC; }

        private VariableDigital<bool> _OH_2_1_PH_2_M_G_DS; public bool OH_2_1_PH_2_M_G_DS { get => _OH_2_1_PH_2_M_G_DS.Valor; set => _OH_2_1_PH_2_M_G_DS.Valor = value; }
        private VariableDigital<bool> _OH_2_3_PH_2_M_G_DS; public bool OH_2_3_PH_2_M_G_DS { get => _OH_2_3_PH_2_M_G_DS.Valor; set => _OH_2_3_PH_2_M_G_DS.Valor = value; }
        private VariableDigital<bool> _OH_2_4_PH_2_M_G_DS; public bool OH_2_4_PH_2_M_G_DS { get => _OH_2_4_PH_2_M_G_DS.Valor; set => _OH_2_4_PH_2_M_G_DS.Valor = value; }
        private VariableDigital<bool> _OH_2_5_PH_2_M_G_DS; public bool OH_2_5_PH_2_M_G_DS { get => _OH_2_5_PH_2_M_G_DS.Valor; set => _OH_2_5_PH_2_M_G_DS.Valor = value; }
        private VariableDigital<bool> _OH_7_5_PH_2_DS; public bool OH_7_5_PH_2_DS { get => _OH_7_5_PH_2_DS.Valor; set => _OH_7_5_PH_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_7_6_PH_2_DS; public bool OH_7_6_PH_2_DS { get => _OH_7_6_PH_2_DS.Valor; set => _OH_7_6_PH_2_DS.Valor = value; }
        private VariableDigital<bool> _OH_7_7_PH_2_DS; public bool OH_7_7_PH_2_DS { get => _OH_7_7_PH_2_DS.Valor; set => _OH_7_7_PH_2_DS.Valor = value; }

        private VariableAnaloga _OH_6_2_MN_1_AS; public double OH_6_2_MN_1_AS { get => _OH_6_2_MN_1_AS.Valor; set => _OH_6_2_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_6_8_MN_1_AS; public double OH_6_8_MN_1_AS { get => _OH_6_8_MN_1_AS.Valor; set => _OH_6_8_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_6_9_MN_1_AS; public double OH_6_9_MN_1_AS { get => _OH_6_9_MN_1_AS.Valor; set => _OH_6_9_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_10_MN_1_AS; public double OH_8_10_MN_1_AS { get => _OH_8_10_MN_1_AS.Valor; set => _OH_8_10_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_23_MN_1_AS; public double OH_8_23_MN_1_AS { get => _OH_8_23_MN_1_AS.Valor; set => _OH_8_23_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_24_MN_1_AS; public double OH_8_24_MN_1_AS { get => _OH_8_24_MN_1_AS.Valor; set => _OH_8_24_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_29_MN_1_AS; public double OH_8_29_MN_1_AS { get => _OH_8_29_MN_1_AS.Valor; set => _OH_8_29_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_30_MN_1_AS; public double OH_8_30_MN_1_AS { get => _OH_8_30_MN_1_AS.Valor; set => _OH_8_30_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_31_MN_1_AS; public double OH_8_31_MN_1_AS { get => _OH_8_31_MN_1_AS.Valor; set => _OH_8_31_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_33_MN_1_AS; public double OH_8_33_MN_1_AS { get => _OH_8_33_MN_1_AS.Valor; set => _OH_8_33_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_34_MN_1_AS; public double OH_8_34_MN_1_AS { get => _OH_8_34_MN_1_AS.Valor; set => _OH_8_34_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_8_35_MN_1_AS; public double OH_8_35_MN_1_AS { get => _OH_8_35_MN_1_AS.Valor; set => _OH_8_35_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_5_5_MN_1_AS; public double OH_5_5_MN_1_AS { get => _OH_5_5_MN_1_AS.Valor; set => _OH_5_5_MN_1_AS.Valor = value; }
        

        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _OH_1_1_SW_2_DE = new VariableDigital<bool>() { Id = 0, Nombre = "OH_1_1_SW_2_DE" }; variablesLectura.Add(_OH_1_1_SW_2_DE);
            _OH_1_2_SW_2_DE = new VariableDigital<bool>() { Id = 1, Nombre = "OH_1_2_SW_2_DE" }; variablesLectura.Add(_OH_1_2_SW_2_DE);
            _OH_1_3_SW_2_DE = new VariableDigital<bool>() { Id = 2, Nombre = "OH_1_3_SW_2_DE" }; variablesLectura.Add(_OH_1_3_SW_2_DE);
            _OH_1_4_SW_2_DE = new VariableDigital<bool>() { Id = 3, Nombre = "OH_1_4_SW_2_DE" }; variablesLectura.Add(_OH_1_4_SW_2_DE);
            _OH_2_2_SW_3_1_DE = new VariableDigital<bool>() { Id = 4, Nombre = "OH_2_2_SW_3_1_DE" }; variablesLectura.Add(_OH_2_2_SW_3_1_DE);
            _OH_2_2_SW_3_2_DE = new VariableDigital<bool>() { Id = 5, Nombre = "OH_2_2_SW_3_2_DE" }; variablesLectura.Add(_OH_2_2_SW_3_2_DE);
            _OH_3_1_SW_2_DE = new VariableDigital<bool>() { Id = 6, Nombre = "OH_3_1_SW_2_DE" }; variablesLectura.Add(_OH_3_1_SW_2_DE);
            _OH_3_2_SW_2_DE = new VariableDigital<bool>() { Id = 7, Nombre = "OH_3_2_SW_2_DE" }; variablesLectura.Add(_OH_3_2_SW_2_DE);
            _OH_3_3_SW_2_DE = new VariableDigital<bool>() { Id = 8, Nombre = "OH_3_3_SW_2_DE" }; variablesLectura.Add(_OH_3_3_SW_2_DE);
            _OH_6_4_SW_2_DE = new VariableDigital<bool>() { Id = 9, Nombre = "OH_6_4_SW_2_DE" }; variablesLectura.Add(_OH_6_4_SW_2_DE);
            _OH_6_5_RS_5_1_DE = new VariableDigital<bool>() { Id = 10, Nombre = "OH_6_5_RS_5_1_DE" }; variablesLectura.Add(_OH_6_5_RS_5_1_DE);
            _OH_6_5_RS_5_2_DE = new VariableDigital<bool>() { Id = 11, Nombre = "OH_6_5_RS_5_2_DE" }; variablesLectura.Add(_OH_6_5_RS_5_2_DE);
            _OH_6_5_RS_5_3_DE = new VariableDigital<bool>() { Id = 12, Nombre = "OH_6_5_RS_5_3_DE" }; variablesLectura.Add(_OH_6_5_RS_5_3_DE);
            _OH_6_5_RS_5_4_DE = new VariableDigital<bool>() { Id = 13, Nombre = "OH_6_5_RS_5_4_DE" }; variablesLectura.Add(_OH_6_5_RS_5_4_DE);
            _OH_6_5_RS_5_5_DE = new VariableDigital<bool>() { Id = 14, Nombre = "OH_6_5_RS_5_5_DE" }; variablesLectura.Add(_OH_6_5_RS_5_5_DE);
            _OH_6_6_RS_4_1_DE = new VariableDigital<bool>() { Id = 15, Nombre = "OH_6_6_RS_4_1_DE" }; variablesLectura.Add(_OH_6_6_RS_4_1_DE);
            _OH_6_6_RS_4_2_DE = new VariableDigital<bool>() { Id = 16, Nombre = "OH_6_6_RS_4_2_DE" }; variablesLectura.Add(_OH_6_6_RS_4_2_DE);
            _OH_6_6_RS_4_3_DE = new VariableDigital<bool>() { Id = 17, Nombre = "OH_6_6_RS_4_3_DE" }; variablesLectura.Add(_OH_6_6_RS_4_3_DE);
            _OH_6_6_RS_4_4_DE = new VariableDigital<bool>() { Id = 18, Nombre = "OH_6_6_RS_4_4_DE" }; variablesLectura.Add(_OH_6_6_RS_4_4_DE);
            _OH_6_7_SW_2_DE = new VariableDigital<bool>() { Id = 19, Nombre = "OH_6_7_SW_2_DE" }; variablesLectura.Add(_OH_6_7_SW_2_DE);
            _OH_6_10_SW_4_1_DE = new VariableDigital<bool>() { Id = 20, Nombre = "OH_6_10_SW_4_1_DE" }; variablesLectura.Add(_OH_6_10_SW_4_1_DE);
            _OH_6_10_SW_4_2_DE = new VariableDigital<bool>() { Id = 21, Nombre = "OH_6_10_SW_4_2_DE" }; variablesLectura.Add(_OH_6_10_SW_4_2_DE);
            _OH_6_10_SW_4_3_DE = new VariableDigital<bool>() { Id = 22, Nombre = "OH_6_10_SW_4_3_DE" }; variablesLectura.Add(_OH_6_10_SW_4_3_DE);
            _OH_6_12_SW_2_DE = new VariableDigital<bool>() { Id = 23, Nombre = "OH_6_12_SW_2_DE" }; variablesLectura.Add(_OH_6_12_SW_2_DE);
            _OH_6_13_SW_3_1_DE = new VariableDigital<bool>() { Id = 24, Nombre = "OH_6_13_SW_3_1_DE" }; variablesLectura.Add(_OH_6_13_SW_3_1_DE);
            _OH_6_13_SW_3_2_DE = new VariableDigital<bool>() { Id = 25, Nombre = "OH_6_13_SW_3_2_DE" }; variablesLectura.Add(_OH_6_13_SW_3_2_DE);
            _OH_6_14_SW_2_DE = new VariableDigital<bool>() { Id = 26, Nombre = "OH_6_14_SW_2_DE" }; variablesLectura.Add(_OH_6_14_SW_2_DE);
            _OH_6_15_SW_2_DE = new VariableDigital<bool>() { Id = 27, Nombre = "OH_6_15_SW_2_DE" }; variablesLectura.Add(_OH_6_15_SW_2_DE);
            _OH_6_16_SW_4_1_DE = new VariableDigital<bool>() { Id = 28, Nombre = "OH_6_16_SW_4_1_DE" }; variablesLectura.Add(_OH_6_16_SW_4_1_DE);
            _OH_6_16_SW_4_2_DE = new VariableDigital<bool>() { Id = 29, Nombre = "OH_6_16_SW_4_2_DE" }; variablesLectura.Add(_OH_6_16_SW_4_2_DE);
            _OH_6_16_SW_4_3_DE = new VariableDigital<bool>() { Id = 30, Nombre = "OH_6_16_SW_4_3_DE" }; variablesLectura.Add(_OH_6_16_SW_4_3_DE);
            _OH_7_3_SW_2_DE = new VariableDigital<bool>() { Id = 31, Nombre = "OH_7_3_SW_2_DE" }; variablesLectura.Add(_OH_7_3_SW_2_DE);
            _OH_7_4_SW_3_1_DE = new VariableDigital<bool>() { Id = 32, Nombre = "OH_7_4_SW_3_1_DE" }; variablesLectura.Add(_OH_7_4_SW_3_1_DE);
            _OH_7_4_SW_3_2_DE = new VariableDigital<bool>() { Id = 33, Nombre = "OH_7_4_SW_3_2_DE" }; variablesLectura.Add(_OH_7_4_SW_3_2_DE);
            _OH_5_1_SW_3_1_DE = new VariableDigital<bool>() { Id = 34, Nombre = "OH_5_1_SW_3_1_DE" }; variablesLectura.Add(_OH_5_1_SW_3_1_DE);
            _OH_5_1_SW_3_2_DE = new VariableDigital<bool>() { Id = 35, Nombre = "OH_5_1_SW_3_2_DE" }; variablesLectura.Add(_OH_5_1_SW_3_2_DE);
            _OH_5_2_SW_2_DE = new VariableDigital<bool>() { Id = 36, Nombre = "OH_5_2_SW_2_DE" }; variablesLectura.Add(_OH_5_2_SW_2_DE);
            _OH_5_3_SW_2_DE = new VariableDigital<bool>() { Id = 37, Nombre = "OH_5_3_SW_2_DE" }; variablesLectura.Add(_OH_5_3_SW_2_DE);

            _OH_6_1_PT_1_AE = new VariableAnaloga(@"Calibracion\OH_6_1_PT_1_AE.xml", 1) { Id = 4000, Nombre = "OH_6_1_PT_1_AE" }; variablesLectura.Add(_OH_6_1_PT_1_AE);
            _OH_6_11_PT_1_AE = new VariableAnaloga(@"Calibracion\OH_6_11_PT_1_AE.xml", 1) { Id = 4001, Nombre = "OH_6_11_PT_1_AE" }; variablesLectura.Add(_OH_6_11_PT_1_AE);
            _OH_6_17_PT_1_AE = new VariableAnaloga(@"Calibracion\OH_6_17_PT_1_AE.xml", 1) { Id = 4002, Nombre = "OH_6_17_PT_1_AE" }; variablesLectura.Add(_OH_6_17_PT_1_AE);

            _OH_6_3_PT_1_ENC = new VariableEncoder() { Id = 3500, Nombre = "OH_6_3_PT_1_ENC" }; variablesLectura.Add(_OH_6_3_PT_1_ENC);
        }

        private void InicializarVariablesEscritura()
        {
            _OH_2_1_PH_2_M_G_DS = new VariableDigital<bool>() { Id = 2000, Nombre = "OH_2_1_PH_2_M_G_DS" }; variablesEscritura.Add(_OH_2_1_PH_2_M_G_DS);
            _OH_2_3_PH_2_M_G_DS = new VariableDigital<bool>() { Id = 2001, Nombre = "OH_2_3_PH_2_M_G_DS" }; variablesEscritura.Add(_OH_2_3_PH_2_M_G_DS);
            _OH_2_4_PH_2_M_G_DS = new VariableDigital<bool>() { Id = 2002, Nombre = "OH_2_4_PH_2_M_G_DS" }; variablesEscritura.Add(_OH_2_4_PH_2_M_G_DS);
            _OH_2_5_PH_2_M_G_DS = new VariableDigital<bool>() { Id = 2003, Nombre = "OH_2_5_PH_2_M_G_DS" }; variablesEscritura.Add(_OH_2_5_PH_2_M_G_DS);
            _OH_7_5_PH_2_DS = new VariableDigital<bool>() { Id = 2004, Nombre = "OH_7_5_PH_2_DS" }; variablesEscritura.Add(_OH_7_5_PH_2_DS);
            _OH_7_6_PH_2_DS = new VariableDigital<bool>() { Id = 2005, Nombre = "OH_7_6_PH_2_DS" }; variablesEscritura.Add(_OH_7_6_PH_2_DS);
            _OH_7_7_PH_2_DS = new VariableDigital<bool>() { Id = 2006, Nombre = "OH_7_7_PH_2_DS" }; variablesEscritura.Add(_OH_7_7_PH_2_DS);

            _OH_6_2_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_6_2_MN_1_AS.xml", 1) { Id = 6000, Nombre = "OH_6_2_MN_1_AS" }; variablesEscritura.Add(_OH_6_2_MN_1_AS);
            _OH_6_8_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_6_8_MN_1_AS.xml", 1) { Id = 6001, Nombre = "OH_6_8_MN_1_AS" }; variablesEscritura.Add(_OH_6_8_MN_1_AS);
            _OH_6_9_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_6_9_MN_1_AS.xml", 1) { Id = 6002, Nombre = "OH_6_9_MN_1_AS" }; variablesEscritura.Add(_OH_6_9_MN_1_AS);
            _OH_8_10_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_10_MN_1_AS.xml", 1) { Id = 6003, Nombre = "OH_8_10_MN_1_AS" }; variablesEscritura.Add(_OH_8_10_MN_1_AS);
            _OH_8_23_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_23_MN_1_AS.xml", 1) { Id = 6004, Nombre = "OH_8_23_MN_1_AS" }; variablesEscritura.Add(_OH_8_23_MN_1_AS);
            _OH_8_24_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_24_MN_1_AS.xml", 1) { Id = 6005, Nombre = "OH_8_24_MN_1_AS" }; variablesEscritura.Add(_OH_8_24_MN_1_AS);
            _OH_8_29_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_29_MN_1_AS.xml", 1) { Id = 6006, Nombre = "OH_8_29_MN_1_AS" }; variablesEscritura.Add(_OH_8_29_MN_1_AS);
            _OH_8_30_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_30_MN_1_AS.xml", 1) { Id = 6007, Nombre = "OH_8_30_MN_1_AS" }; variablesEscritura.Add(_OH_8_30_MN_1_AS);
            _OH_8_31_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_31_MN_1_AS.xml", 1) { Id = 6008, Nombre = "OH_8_31_MN_1_AS" }; variablesEscritura.Add(_OH_8_31_MN_1_AS);
            _OH_8_33_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_33_MN_1_AS.xml", 1) { Id = 6009, Nombre = "OH_8_33_MN_1_AS" }; variablesEscritura.Add(_OH_8_33_MN_1_AS);
            _OH_8_34_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_34_MN_1_AS.xml", 1) { Id = 6010, Nombre = "OH_8_34_MN_1_AS" }; variablesEscritura.Add(_OH_8_34_MN_1_AS);
            _OH_8_35_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_8_35_MN_1_AS.xml", 1) { Id = 6011, Nombre = "OH_8_35_MN_1_AS" }; variablesEscritura.Add(_OH_8_35_MN_1_AS);
            _OH_5_5_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_5_5_MN_1_AS.xml", 1) { Id = 6012, Nombre = "OH_5_5_MN_1_AS" }; variablesEscritura.Add(_OH_5_5_MN_1_AS);
            

        }
        #endregion MetodosPrivados
    }
}
