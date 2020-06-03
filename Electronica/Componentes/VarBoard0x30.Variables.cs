using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x30
    {
        #region Propiedades y variables
        public VariableDigital<bool> _CS_4_10_PHPL_2_DE; public bool CS_4_10_PHPL_2_DE() { return _CS_4_10_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_11_PHPL_2_DE; public bool CS_4_11_PHPL_2_DE() { return _CS_4_11_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_12_PHPL_2_DE; public bool CS_4_12_PHPL_2_DE() { return _CS_4_12_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_13_PHPL_2_DE; public bool CS_4_13_PHPL_2_DE() { return _CS_4_13_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_14_SW_2_DE; public bool CS_4_14_SW_2_DE() { return _CS_4_14_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_15_SW_2_DE; public bool CS_4_15_SW_2_DE() { return _CS_4_15_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_16_SW_2_DE; public bool CS_4_16_SW_2_DE() { return _CS_4_16_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_17_SW_2_DE; public bool CS_4_17_SW_2_DE() { return _CS_4_17_SW_2_DE.Valor; }
        public VariableDigital<bool> _CE_3_1_RS_5_1_DE; public bool CE_3_1_RS_5_1_DE() { return _CE_3_1_RS_5_1_DE.Valor; }
        public VariableDigital<bool> _CE_3_1_RS_5_2_DE; public bool CE_3_1_RS_5_2_DE() { return _CE_3_1_RS_5_2_DE.Valor; }
        public VariableDigital<bool> _CE_3_1_RS_5_3_DE; public bool CE_3_1_RS_5_3_DE() { return _CE_3_1_RS_5_3_DE.Valor; }
        public VariableDigital<bool> _CE_3_1_RS_5_4_DE; public bool CE_3_1_RS_5_4_DE() { return _CE_3_1_RS_5_4_DE.Valor; }
        public VariableDigital<bool> _CE_3_1_RS_5_5_DE; public bool CE_3_1_RS_5_5_DE() { return _CE_3_1_RS_5_5_DE.Valor; }
        public VariableDigital<bool> _CS_1_1_SW_3_1_DE; public bool CS_1_1_SW_3_1_DE() { return _CS_1_1_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _CS_1_1_SW_3_2_DE; public bool CS_1_1_SW_3_2_DE() { return _CS_1_1_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _CS_1_2_SW_2_DE; public bool CS_1_2_SW_2_DE() { return _CS_1_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_1_3_SW_2_DE; public bool CS_1_3_SW_2_DE() { return _CS_1_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _CE_3_2_PHK_2_DE; public bool CE_3_2_PHK_2_DE() { return _CE_3_2_PHK_2_DE.Valor; }

        public VariableDigital<bool> _CS_2_7_SW_2_DE; public bool CS_2_7_SW_2_DE() { return _CS_2_7_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_3_2_SW_2_DE; public bool CS_3_2_SW_2_DE() { return _CS_3_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_3_4_SW_3_1_DE; public bool CS_3_4_SW_3_1_DE() { return _CS_3_4_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _CS_3_4_SW_3_2_DE; public bool CS_3_4_SW_3_2_DE() { return _CS_3_4_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _CS_3_7_SW_2_DE; public bool CS_3_7_SW_2_DE() { return _CS_3_7_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_3_8_SW_2_DE; public bool CS_3_8_SW_2_DE() { return _CS_3_8_SW_2_DE.Valor; }
        public VariableDigital<bool> _CS_4_9_SW_3_1_DE; public bool CS_4_9_SW_3_1_DE() { return _CS_4_9_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _CS_4_9_SW_3_2_DE; public bool CS_4_9_SW_3_2_DE() { return _CS_4_9_SW_3_2_DE.Valor; }

        public VariableAnaloga _CS_2_1_PT_1_AE; public double CS_2_1_PT_1_AE { get => _CS_2_1_PT_1_AE.Valor; }
        public VariableAnaloga _CS_2_2_PT_1_AE; public double CS_2_2_PT_1_AE { get => _CS_2_2_PT_1_AE.Valor; }
        public VariableAnaloga _CS_2_4_PT_1_AE; public double CS_2_4_PT_1_AE { get => _CS_2_4_PT_1_AE.Valor; }
        public VariableAnaloga _CS_2_5_PT_1_AE; public double CS_2_5_PT_1_AE { get => _CS_2_5_PT_1_AE.Valor; }
        public VariableAnaloga _CS_2_6_PT_1_AE; public double CS_2_6_PT_1_AE { get => _CS_2_6_PT_1_AE.Valor; }


        public VariableDigital<bool> _CS_4_1_PHK_2_DS; public bool CS_4_1_PHK_2_DS { get => _CS_4_1_PHK_2_DS.Valor; set => _CS_4_1_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_2_PHK_2_DS; public bool CS_4_2_PHK_2_DS { get => _CS_4_2_PHK_2_DS.Valor; set => _CS_4_2_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_3_PHK_2_DS; public bool CS_4_3_PHK_2_DS { get => _CS_4_3_PHK_2_DS.Valor; set => _CS_4_3_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_4_PHK_2_DS; public bool CS_4_4_PHK_2_DS { get => _CS_4_4_PHK_2_DS.Valor; set => _CS_4_4_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_5_PH_2_DS; public bool CS_4_5_PH_2_DS { get => _CS_4_5_PH_2_DS.Valor; set => _CS_4_5_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_6_PH_2_DS; public bool CS_4_6_PH_2_DS { get => _CS_4_6_PH_2_DS.Valor; set => _CS_4_6_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_7_PH_2_DS; public bool CS_4_7_PH_2_DS { get => _CS_4_7_PH_2_DS.Valor; set => _CS_4_7_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_8_PH_2_DS; public bool CS_4_8_PH_2_DS { get => _CS_4_8_PH_2_DS.Valor; set => _CS_4_8_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_10_PHPL_2_LZ_DS; public bool CS_4_10_PHPL_2_LZ_DS { get => _CS_4_10_PHPL_2_LZ_DS.Valor; set => _CS_4_10_PHPL_2_LZ_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_10_PHPL_2_BB_DS; public bool CS_4_10_PHPL_2_BB_DS { get => _CS_4_10_PHPL_2_BB_DS.Valor; set => _CS_4_10_PHPL_2_BB_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_11_PHPL_2_LZ_DS; public bool CS_4_11_PHPL_2_LZ_DS { get => _CS_4_11_PHPL_2_LZ_DS.Valor; set => _CS_4_11_PHPL_2_LZ_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_11_PHPL_2_BB_DS; public bool CS_4_11_PHPL_2_BB_DS { get => _CS_4_11_PHPL_2_BB_DS.Valor; set => _CS_4_11_PHPL_2_BB_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_12_PHPL_2_LZ_DS; public bool CS_4_12_PHPL_2_LZ_DS { get => _CS_4_12_PHPL_2_LZ_DS.Valor; set => _CS_4_12_PHPL_2_LZ_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_12_PHPL_2_BB_DS; public bool CS_4_12_PHPL_2_BB_DS { get => _CS_4_12_PHPL_2_BB_DS.Valor; set => _CS_4_12_PHPL_2_BB_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_13_PHPL_2_LZ_DS; public bool CS_4_13_PHPL_2_LZ_DS { get => _CS_4_13_PHPL_2_LZ_DS.Valor; set => _CS_4_13_PHPL_2_LZ_DS.Valor = value; }
        public VariableDigital<bool> _CS_4_13_PHPL_2_BB_DS; public bool CS_4_13_PHPL_2_BB_DS { get => _CS_4_13_PHPL_2_BB_DS.Valor; set => _CS_4_13_PHPL_2_BB_DS.Valor = value; }
        public VariableDigital<bool> _CE_3_2_PHK_2_DS; public bool CE_3_2_PHK_2_DS { get => _CE_3_2_PHK_2_DS.Valor; set => _CE_3_2_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CE_3_3_PHK_2_DS; public bool CE_3_3_PHK_2_DS { get => _CE_3_3_PHK_2_DS.Valor; set => _CE_3_3_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CE_3_4_PHK_2_DS; public bool CE_3_4_PHK_2_DS { get => _CE_3_4_PHK_2_DS.Valor; set => _CE_3_4_PHK_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_3_5_PH_2_DS; public bool CS_3_5_PH_2_DS { get => _CS_3_5_PH_2_DS.Valor; set => _CS_3_5_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_3_6_PH_2_DS; public bool CS_3_6_PH_2_DS { get => _CS_3_6_PH_2_DS.Valor; set => _CS_3_6_PH_2_DS.Valor = value; }
        public VariableDigital<bool> _CS_3_3_PH_2_DS; public bool CS_3_3_PH_2_DS { get => _CS_3_3_PH_2_DS.Valor; set => _CS_3_3_PH_2_DS.Valor = value; }

        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _CS_4_10_PHPL_2_DE = new VariableDigital<bool>() { Id = 858, Nombre = "CS_4_10_PHPL_2_DE" }; variablesLectura.Add(_CS_4_10_PHPL_2_DE);
            _CS_4_11_PHPL_2_DE = new VariableDigital<bool>() { Id = 859, Nombre = "CS_4_11_PHPL_2_DE" }; variablesLectura.Add(_CS_4_11_PHPL_2_DE);
            _CS_4_12_PHPL_2_DE = new VariableDigital<bool>() { Id = 860, Nombre = "CS_4_12_PHPL_2_DE" }; variablesLectura.Add(_CS_4_12_PHPL_2_DE);
            _CS_4_13_PHPL_2_DE = new VariableDigital<bool>() { Id = 861, Nombre = "CS_4_13_PHPL_2_DE" }; variablesLectura.Add(_CS_4_13_PHPL_2_DE);
            _CS_4_14_SW_2_DE = new VariableDigital<bool>() { Id = 862, Nombre = "CS_4_14_SW_2_DE" }; variablesLectura.Add(_CS_4_14_SW_2_DE);
            _CS_4_15_SW_2_DE = new VariableDigital<bool>() { Id = 863, Nombre = "CS_4_15_SW_2_DE" }; variablesLectura.Add(_CS_4_15_SW_2_DE);
            _CS_4_16_SW_2_DE = new VariableDigital<bool>() { Id = 864, Nombre = "CS_4_16_SW_2_DE" }; variablesLectura.Add(_CS_4_16_SW_2_DE);
            _CS_4_17_SW_2_DE = new VariableDigital<bool>() { Id = 865, Nombre = "CS_4_17_SW_2_DE" }; variablesLectura.Add(_CS_4_17_SW_2_DE);
            _CE_3_1_RS_5_1_DE = new VariableDigital<bool>() { Id = 866, Nombre = "CE_3_1_RS_5_1_DE" }; variablesLectura.Add(_CE_3_1_RS_5_1_DE);
            _CE_3_1_RS_5_2_DE = new VariableDigital<bool>() { Id = 867, Nombre = "CE_3_1_RS_5_2_DE" }; variablesLectura.Add(_CE_3_1_RS_5_2_DE);
            _CE_3_1_RS_5_3_DE = new VariableDigital<bool>() { Id = 868, Nombre = "CE_3_1_RS_5_3_DE" }; variablesLectura.Add(_CE_3_1_RS_5_3_DE);
            _CE_3_1_RS_5_4_DE = new VariableDigital<bool>() { Id = 869, Nombre = "CE_3_1_RS_5_4_DE" }; variablesLectura.Add(_CE_3_1_RS_5_4_DE);
            _CE_3_1_RS_5_5_DE = new VariableDigital<bool>() { Id = 870, Nombre = "CE_3_1_RS_5_5_DE" }; variablesLectura.Add(_CE_3_1_RS_5_5_DE);
            _CS_1_1_SW_3_1_DE = new VariableDigital<bool>() { Id = 871, Nombre = "CS_1_1_SW_3_1_DE" }; variablesLectura.Add(_CS_1_1_SW_3_1_DE);
            _CS_1_1_SW_3_2_DE = new VariableDigital<bool>() { Id = 872, Nombre = "CS_1_1_SW_3_2_DE" }; variablesLectura.Add(_CS_1_1_SW_3_2_DE);
            _CS_1_2_SW_2_DE = new VariableDigital<bool>() { Id = 873, Nombre = "CS_1_2_SW_2_DE" }; variablesLectura.Add(_CS_1_2_SW_2_DE);
            _CS_1_3_SW_2_DE = new VariableDigital<bool>() { Id = 874, Nombre = "CS_1_3_SW_2_DE" }; variablesLectura.Add(_CS_1_3_SW_2_DE);
            _CE_3_2_PHK_2_DE = new VariableDigital<bool>() { Id = 875, Nombre = "CE_3_2_PHK_2_DE" }; variablesLectura.Add(_CE_3_2_PHK_2_DE);
            _CS_2_7_SW_2_DE = new VariableDigital<bool>() { Id = 850, Nombre = "CS_2_7_SW_2_DE" }; variablesLectura.Add(_CS_2_7_SW_2_DE);
            _CS_3_2_SW_2_DE = new VariableDigital<bool>() { Id = 851, Nombre = "CS_3_2_SW_2_DE" }; variablesLectura.Add(_CS_3_2_SW_2_DE);
            _CS_3_4_SW_3_1_DE = new VariableDigital<bool>() { Id = 852, Nombre = "CS_3_4_SW_3_1_DE" }; variablesLectura.Add(_CS_3_4_SW_3_1_DE);
            _CS_3_4_SW_3_2_DE = new VariableDigital<bool>() { Id = 853, Nombre = "CS_3_4_SW_3_2_DE" }; variablesLectura.Add(_CS_3_4_SW_3_2_DE);
            _CS_3_7_SW_2_DE = new VariableDigital<bool>() { Id = 854, Nombre = "CS_3_7_SW_2_DE" }; variablesLectura.Add(_CS_3_7_SW_2_DE);
            _CS_3_8_SW_2_DE = new VariableDigital<bool>() { Id = 855, Nombre = "CS_3_8_SW_2_DE" }; variablesLectura.Add(_CS_3_8_SW_2_DE);
            _CS_4_9_SW_3_1_DE = new VariableDigital<bool>() { Id = 856, Nombre = "CS_4_9_SW_3_1_DE" }; variablesLectura.Add(_CS_4_9_SW_3_1_DE);
            _CS_4_9_SW_3_2_DE = new VariableDigital<bool>() { Id = 857, Nombre = "CS_4_9_SW_3_2_DE" }; variablesLectura.Add(_CS_4_9_SW_3_2_DE);
            _CS_2_1_PT_1_AE = new VariableAnaloga(@"Calibracion\CS_3_6_PH_2_AE.xml", 1) { Id = 4240, Nombre = "CS_2_1_PT_1_AE" }; variablesLectura.Add(_CS_2_1_PT_1_AE);
            _CS_2_2_PT_1_AE = new VariableAnaloga(@"Calibracion\CS_3_3_PH_2_AE.xml", 1) { Id = 4241, Nombre = "CS_2_2_PT_1_AE" }; variablesLectura.Add(_CS_2_2_PT_1_AE);
            _CS_2_4_PT_1_AE = new VariableAnaloga(@"Calibracion\CS_2_7_SW_2_AE.xml", 1) { Id = 4242, Nombre = "CS_2_4_PT_1_AE" }; variablesLectura.Add(_CS_2_4_PT_1_AE);
            _CS_2_5_PT_1_AE = new VariableAnaloga(@"Calibracion\CS_3_2_SW_2_AE.xml", 1) { Id = 4243, Nombre = "CS_2_5_PT_1_AE" }; variablesLectura.Add(_CS_2_5_PT_1_AE);
            _CS_2_6_PT_1_AE = new VariableAnaloga(@"Calibracion\CS_4_9_SW_3_2_AE.xml", 1) { Id = 4244, Nombre = "CS_2_6_PT_1_AE" }; variablesLectura.Add(_CS_2_6_PT_1_AE);



        }

        private void InicializarVariablesEscritura()
        {
            _CS_4_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2850, Nombre = "CS_4_1_PHK_2_DS" }; variablesEscritura.Add(_CS_4_1_PHK_2_DS);
            _CS_4_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2851, Nombre = "CS_4_2_PHK_2_DS" }; variablesEscritura.Add(_CS_4_2_PHK_2_DS);
            _CS_4_3_PHK_2_DS = new VariableDigital<bool>() { Id = 2852, Nombre = "CS_4_3_PHK_2_DS" }; variablesEscritura.Add(_CS_4_3_PHK_2_DS);
            _CS_4_4_PHK_2_DS = new VariableDigital<bool>() { Id = 2853, Nombre = "CS_4_4_PHK_2_DS" }; variablesEscritura.Add(_CS_4_4_PHK_2_DS);
            _CS_4_5_PH_2_DS = new VariableDigital<bool>() { Id = 2854, Nombre = "CS_4_5_PH_2_DS" }; variablesEscritura.Add(_CS_4_5_PH_2_DS);
            _CS_4_6_PH_2_DS = new VariableDigital<bool>() { Id = 2855, Nombre = "CS_4_6_PH_2_DS" }; variablesEscritura.Add(_CS_4_6_PH_2_DS);
            _CS_4_7_PH_2_DS = new VariableDigital<bool>() { Id = 2856, Nombre = "CS_4_7_PH_2_DS" }; variablesEscritura.Add(_CS_4_7_PH_2_DS);
            _CS_4_8_PH_2_DS = new VariableDigital<bool>() { Id = 2857, Nombre = "CS_4_8_PH_2_DS" }; variablesEscritura.Add(_CS_4_8_PH_2_DS);
            _CS_4_10_PHPL_2_LZ_DS = new VariableDigital<bool>() { Id = 2858, Nombre = "CS_4_10_PHPL_2_LZ_DS" }; variablesEscritura.Add(_CS_4_10_PHPL_2_LZ_DS);
            _CS_4_10_PHPL_2_BB_DS = new VariableDigital<bool>() { Id = 2859, Nombre = "CS_4_10_PHPL_2_BB_DS" }; variablesEscritura.Add(_CS_4_10_PHPL_2_BB_DS);
            _CS_4_11_PHPL_2_LZ_DS = new VariableDigital<bool>() { Id = 2860, Nombre = "CS_4_11_PHPL_2_LZ_DS" }; variablesEscritura.Add(_CS_4_11_PHPL_2_LZ_DS);
            _CS_4_11_PHPL_2_BB_DS = new VariableDigital<bool>() { Id = 2861, Nombre = "CS_4_11_PHPL_2_BB_DS" }; variablesEscritura.Add(_CS_4_11_PHPL_2_BB_DS);
            _CS_4_12_PHPL_2_LZ_DS = new VariableDigital<bool>() { Id = 2862, Nombre = "CS_4_12_PHPL_2_LZ_DS" }; variablesEscritura.Add(_CS_4_12_PHPL_2_LZ_DS);
            _CS_4_12_PHPL_2_BB_DS = new VariableDigital<bool>() { Id = 2863, Nombre = "CS_4_12_PHPL_2_BB_DS" }; variablesEscritura.Add(_CS_4_12_PHPL_2_BB_DS);
            _CS_4_13_PHPL_2_LZ_DS = new VariableDigital<bool>() { Id = 2864, Nombre = "CS_4_13_PHPL_2_LZ_DS" }; variablesEscritura.Add(_CS_4_13_PHPL_2_LZ_DS);
            _CS_4_13_PHPL_2_BB_DS = new VariableDigital<bool>() { Id = 2865, Nombre = "CS_4_13_PHPL_2_BB_DS" }; variablesEscritura.Add(_CS_4_13_PHPL_2_BB_DS);
            _CE_3_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2866, Nombre = "CE_3_2_PHK_2_DS" }; variablesEscritura.Add(_CE_3_2_PHK_2_DS);
            _CE_3_3_PHK_2_DS = new VariableDigital<bool>() { Id = 2867, Nombre = "CE_3_3_PHK_2_DS" }; variablesEscritura.Add(_CE_3_3_PHK_2_DS);
            _CE_3_4_PHK_2_DS = new VariableDigital<bool>() { Id = 2868, Nombre = "CE_3_4_PHK_2_DS" }; variablesEscritura.Add(_CE_3_4_PHK_2_DS);
            _CS_3_5_PH_2_DS = new VariableDigital<bool>() { Id = 2869, Nombre = "CS_3_5_PH_2_DS" }; variablesEscritura.Add(_CS_3_5_PH_2_DS);
            _CS_3_6_PH_2_DS = new VariableDigital<bool>() { Id = 2870, Nombre = "CS_3_6_PH_2_DS" }; variablesEscritura.Add(_CS_3_6_PH_2_DS);
            _CS_3_3_PH_2_DS = new VariableDigital<bool>() { Id = 2871, Nombre = "CS_3_3_PH_2_DS" }; variablesEscritura.Add(_CS_3_3_PH_2_DS);

        }
        #endregion MetodosPrivados
    }
}
