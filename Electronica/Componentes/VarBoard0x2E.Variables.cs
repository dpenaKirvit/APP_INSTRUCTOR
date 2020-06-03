using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x2E
    {
        #region Propiedades y variables
        public VariableDigital<bool> _PI_3_1_PHK_2_DE; public bool PI_3_1_PHK_2_DE() { return _PI_3_1_PHK_2_DE.Valor; }
        public VariableDigital<bool> _PI_6_1_PHK_2_DE; public bool PI_6_1_PHK_2_DE() { return _PI_6_1_PHK_2_DE.Valor; }
        public VariableDigital<bool> _PI_6_2_PHK_2_DE; public bool PI_6_2_PHK_2_DE() { return _PI_6_2_PHK_2_DE.Valor; }
        public VariableDigital<bool> _PI_11_PL_2_DE; public bool PI_11_PL_2_DE() { return _PI_11_PL_2_DE.Valor; }
        public VariableDigital<bool> _EI_3_1_PHK_2_DE; public bool EI_3_1_PHK_2_DE() { return _EI_3_1_PHK_2_DE.Valor; }
        public VariableDigital<bool> _EI_3_2_PHK_2_DE; public bool EI_3_2_PHK_2_DE() { return _EI_3_2_PHK_2_DE.Valor; }
        public VariableDigital<bool> _CI_2_1_SW_2_DE; public bool CI_2_1_SW_2_DE() { return _CI_2_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_3_1_PHK_2_DE; public bool CI_3_1_PHK_2_DE() { return _CI_3_1_PHK_2_DE.Valor; }
        public VariableDigital<bool> _CI_8_3_PH_2_DE; public bool CI_8_3_PH_2_DE() { return _CI_8_3_PH_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_1_SW_2_DE; public bool CI_9_1_SW_2_DE() { return _CI_9_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_2_SW_2_DE; public bool CI_9_2_SW_2_DE() { return _CI_9_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_3_SW_2_DE; public bool CI_9_3_SW_2_DE() { return _CI_9_3_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_9_SW_2_DE; public bool CI_9_9_SW_2_DE() { return _CI_9_9_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_10_SW_2_DE; public bool CI_9_10_SW_2_DE() { return _CI_9_10_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_11_SW_2_DE; public bool CI_9_11_SW_2_DE() { return _CI_9_11_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_12_SW_2_DE; public bool CI_9_12_SW_2_DE() { return _CI_9_12_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_13_SW_2_DE; public bool CI_9_13_SW_2_DE() { return _CI_9_13_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_9_16_SW_2_DE; public bool CI_9_16_SW_2_DE() { return _CI_9_16_SW_2_DE.Valor; }

        public VariableDigital<bool> _CI_10_1_SW_2_DE; public bool CI_10_1_SW_2_DE() { return _CI_10_1_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_10_2_SW_3_1_DE; public bool CI_10_2_SW_3_1_DE() { return _CI_10_2_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _CI_10_2_SW_3_2_DE; public bool CI_10_2_SW_3_2_DE() { return _CI_10_2_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _CI_10_3_SW_3_1_DE; public bool CI_10_3_SW_3_1_DE() { return _CI_10_3_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _CI_10_3_SW_3_2_DE; public bool CI_10_3_SW_3_2_DE() { return _CI_10_3_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _CI_10_4_SW_2_DE; public bool CI_10_4_SW_2_DE() { return _CI_10_4_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_10_5_SW_2_DE; public bool CI_10_5_SW_2_DE() { return _CI_10_5_SW_2_DE.Valor; }
        public VariableDigital<bool> _CI_11_4_SW_2_DE; public bool CI_11_4_SW_2_DE() { return _CI_11_4_SW_2_DE.Valor; }



        

         private VariableDigital<bool> _PI_3_1_PHK_2_DS; public bool PI_3_1_PHK_2_DS { get => _PI_3_1_PHK_2_DS.Valor; set => _PI_3_1_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _PI_3_2_PHK_2_DS; public bool PI_3_2_PHK_2_DS { get => _PI_3_2_PHK_2_DS.Valor; set => _PI_3_2_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _PI_5_1_LK_DS; public bool PI_5_1_LK_DS { get => _PI_5_1_LK_DS.Valor; set => _PI_5_1_LK_DS.Valor = value; }
        private VariableDigital<bool> _PI_5_2_LK_DS; public bool PI_5_2_LK_DS { get => _PI_5_2_LK_DS.Valor; set => _PI_5_2_LK_DS.Valor = value; }
        private VariableDigital<bool> _EI_3_1_PHK_2_DS; public bool EI_3_1_PHK_2_DS { get => _EI_3_1_PHK_2_DS.Valor; set => _EI_3_1_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _EI_3_2_PHK_2_DS; public bool EI_3_2_PHK_2_DS { get => _EI_3_2_PHK_2_DS.Valor; set => _EI_3_2_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_2_2_LK_DS; public bool CI_2_2_LK_DS { get => _CI_2_2_LK_DS.Valor; set => _CI_2_2_LK_DS.Valor = value; }
        private VariableDigital<bool> _CI_2_3_LK_DS; public bool CI_2_3_LK_DS { get => _CI_2_3_LK_DS.Valor; set => _CI_2_3_LK_DS.Valor = value; }
        private VariableDigital<bool> _CI_2_4_LK_DS; public bool CI_2_4_LK_DS { get => _CI_2_4_LK_DS.Valor; set => _CI_2_4_LK_DS.Valor = value; }
        private VariableDigital<bool> _CI_2_5_LK_DS; public bool CI_2_5_LK_DS { get => _CI_2_5_LK_DS.Valor; set => _CI_2_5_LK_DS.Valor = value; }
        private VariableDigital<bool> _CI_3_1_PHK_2_DS; public bool CI_3_1_PHK_2_DS { get => _CI_3_1_PHK_2_DS.Valor; set => _CI_3_1_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_3_2_PHK_2_DS; public bool CI_3_2_PHK_2_DS { get => _CI_3_2_PHK_2_DS.Valor; set => _CI_3_2_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_8_2_LK_DS; public bool CI_8_2_LK_DS { get => _CI_8_2_LK_DS.Valor; set => _CI_8_2_LK_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_4_PHK_2_DS; public bool CI_9_4_PHK_2_DS { get => _CI_9_4_PHK_2_DS.Valor; set => _CI_9_4_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_5_PHK_2_DS; public bool CI_9_5_PHK_2_DS { get => _CI_9_5_PHK_2_DS.Valor; set => _CI_9_5_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_6_PHK_2_DS; public bool CI_9_6_PHK_2_DS { get => _CI_9_6_PHK_2_DS.Valor; set => _CI_9_6_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_7_PHK_2_DS; public bool CI_9_7_PHK_2_DS { get => _CI_9_7_PHK_2_DS.Valor; set => _CI_9_7_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_8_PHK_2_DS; public bool CI_9_8_PHK_2_DS { get => _CI_9_8_PHK_2_DS.Valor; set => _CI_9_8_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_14_PHK_2_DS; public bool CI_9_14_PHK_2_DS { get => _CI_9_14_PHK_2_DS.Valor; set => _CI_9_14_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_9_15_PHK_2_DS; public bool CI_9_15_PHK_2_DS { get => _CI_9_15_PHK_2_DS.Valor; set => _CI_9_15_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_1_IN_1_DS; public bool CI_11_1_IN_1_DS { get => _CI_11_1_IN_1_DS.Valor; set => _CI_11_1_IN_1_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_1_IN_2_DS; public bool CI_11_1_IN_2_DS { get => _CI_11_1_IN_2_DS.Valor; set => _CI_11_1_IN_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_1_IN_3_DS; public bool CI_11_1_IN_3_DS { get => _CI_11_1_IN_3_DS.Valor; set => _CI_11_1_IN_3_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_2_IN_1_DS; public bool CI_11_2_IN_1_DS { get => _CI_11_2_IN_1_DS.Valor; set => _CI_11_2_IN_1_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_2_IN_2_DS; public bool CI_11_2_IN_2_DS { get => _CI_11_2_IN_2_DS.Valor; set => _CI_11_2_IN_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_2_IN_3_DS; public bool CI_11_2_IN_3_DS { get => _CI_11_2_IN_3_DS.Valor; set => _CI_11_2_IN_3_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_3_IN_1_DS; public bool CI_11_3_IN_1_DS { get => _CI_11_3_IN_1_DS.Valor; set => _CI_11_3_IN_1_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_3_IN_2_DS; public bool CI_11_3_IN_2_DS { get => _CI_11_3_IN_2_DS.Valor; set => _CI_11_3_IN_2_DS.Valor = value; }
        private VariableDigital<bool> _CI_11_3_IN_3_DS; public bool CI_11_3_IN_3_DS { get => _CI_11_3_IN_3_DS.Valor; set => _CI_11_3_IN_3_DS.Valor = value; }
        private VariableDigital<bool> _PI_6_1_PHK_2_DS; public bool PI_6_1_PHK_2_DS { get => _PI_6_1_PHK_2_DS.Valor; set => _PI_6_1_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _PI_6_2_PHK_2_DS; public bool PI_6_2_PHK_2_DS { get => _PI_6_2_PHK_2_DS.Valor; set => _PI_6_2_PHK_2_DS.Valor = value; }


        private VariableAnaloga _CI_8_1_MN_1_AS; public double CI_8_1_MN_1_AS { get => _CI_8_1_MN_1_AS.Valor; set => _CI_8_1_MN_1_AS.Valor = value; }
        private VariableAnaloga _PS_1_5_MN_1_AS; public double PS_1_5_MN_1_AS { get => _PS_1_5_MN_1_AS.Valor; set => _PS_1_5_MN_1_AS.Valor = value; }
        private VariableAnaloga _CS_1_5_MN_1_AS; public double CS_1_5_MN_1_AS { get => _CS_1_5_MN_1_AS.Valor; set => _CS_1_5_MN_1_AS.Valor = value; }
        private VariableAnaloga _PI_8_1_MN_1_AS; public double PI_8_1_MN_1_AS { get => _PI_8_1_MN_1_AS.Valor; set => _PI_8_1_MN_1_AS.Valor = value; }
        private VariableAnaloga _EI_5_1_MN_1_AS; public double EI_5_1_MN_1_AS { get => _EI_5_1_MN_1_AS.Valor; set => _EI_5_1_MN_1_AS.Valor = value; }
        private VariableAnaloga _OH_9_1_MN_1_AS; public double OH_9_1_MN_1_AS { get => _OH_9_1_MN_1_AS.Valor; set => _OH_9_1_MN_1_AS.Valor = value; }




        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            
            _PI_3_1_PHK_2_DE = new VariableDigital<bool>() { Id = 750, Nombre = "PI_3_1_PHK_2_DE" }; variablesLectura.Add(_PI_3_1_PHK_2_DE);
            _PI_6_1_PHK_2_DE = new VariableDigital<bool>() { Id = 751, Nombre = "PI_6_1_PHK_2_DE" }; variablesLectura.Add(_PI_6_1_PHK_2_DE);
            _PI_6_2_PHK_2_DE = new VariableDigital<bool>() { Id = 752, Nombre = "PI_6_2_PHK_2_DE" }; variablesLectura.Add(_PI_6_2_PHK_2_DE);
            _PI_11_PL_2_DE = new VariableDigital<bool>() { Id = 753, Nombre = "PI_11_PL_2_DE" }; variablesLectura.Add(_PI_11_PL_2_DE);
            _EI_3_1_PHK_2_DE = new VariableDigital<bool>() { Id = 754, Nombre = "EI_3_1_PHK_2_DE" }; variablesLectura.Add(_EI_3_1_PHK_2_DE);
            _EI_3_2_PHK_2_DE = new VariableDigital<bool>() { Id = 755, Nombre = "EI_3_2_PHK_2_DE" }; variablesLectura.Add(_EI_3_2_PHK_2_DE);
            _CI_2_1_SW_2_DE = new VariableDigital<bool>() { Id = 756, Nombre = "CI_2_1_SW_2_DE" }; variablesLectura.Add(_CI_2_1_SW_2_DE);
            _CI_3_1_PHK_2_DE = new VariableDigital<bool>() { Id = 757, Nombre = "CI_3_1_PHK_2_DE" }; variablesLectura.Add(_CI_3_1_PHK_2_DE);
            _CI_8_3_PH_2_DE = new VariableDigital<bool>() { Id = 758, Nombre = "CI_8_3_PH_2_DE" }; variablesLectura.Add(_CI_8_3_PH_2_DE);
            _CI_9_1_SW_2_DE = new VariableDigital<bool>() { Id = 759, Nombre = "CI_9_1_SW_2_DE" }; variablesLectura.Add(_CI_9_1_SW_2_DE);
            _CI_9_2_SW_2_DE = new VariableDigital<bool>() { Id = 760, Nombre = "CI_9_2_SW_2_DE" }; variablesLectura.Add(_CI_9_2_SW_2_DE);
            _CI_9_3_SW_2_DE = new VariableDigital<bool>() { Id = 761, Nombre = "CI_9_3_SW_2_DE" }; variablesLectura.Add(_CI_9_3_SW_2_DE);
            _CI_9_9_SW_2_DE = new VariableDigital<bool>() { Id = 762, Nombre = "CI_9_9_SW_2_DE" }; variablesLectura.Add(_CI_9_9_SW_2_DE);
            _CI_9_10_SW_2_DE = new VariableDigital<bool>() { Id = 763, Nombre = "CI_9_10_SW_2_DE" }; variablesLectura.Add(_CI_9_10_SW_2_DE);
            _CI_9_11_SW_2_DE = new VariableDigital<bool>() { Id = 764, Nombre = "CI_9_11_SW_2_DE" }; variablesLectura.Add(_CI_9_11_SW_2_DE);
            _CI_9_12_SW_2_DE = new VariableDigital<bool>() { Id = 765, Nombre = "CI_9_12_SW_2_DE" }; variablesLectura.Add(_CI_9_12_SW_2_DE);
            _CI_9_13_SW_2_DE = new VariableDigital<bool>() { Id = 766, Nombre = "CI_9_13_SW_2_DE" }; variablesLectura.Add(_CI_9_13_SW_2_DE);
            _CI_9_16_SW_2_DE = new VariableDigital<bool>() { Id = 767, Nombre = "CI_9_16_SW_2_DE" }; variablesLectura.Add(_CI_9_16_SW_2_DE);
            _CI_10_1_SW_2_DE = new VariableDigital<bool>() { Id = 768, Nombre = "CI_10_1_SW_2_DE" }; variablesLectura.Add(_CI_10_1_SW_2_DE);
            _CI_10_2_SW_3_1_DE = new VariableDigital<bool>() { Id = 769, Nombre = "CI_10_2_SW_3_1_DE" }; variablesLectura.Add(_CI_10_2_SW_3_1_DE);
            _CI_10_2_SW_3_2_DE = new VariableDigital<bool>() { Id = 770, Nombre = "CI_10_2_SW_3_2_DE" }; variablesLectura.Add(_CI_10_2_SW_3_2_DE);
            _CI_10_3_SW_3_1_DE = new VariableDigital<bool>() { Id = 771, Nombre = "CI_10_3_SW_3_1_DE" }; variablesLectura.Add(_CI_10_3_SW_3_1_DE);
            _CI_10_3_SW_3_2_DE = new VariableDigital<bool>() { Id = 772, Nombre = "CI_10_3_SW_3_2_DE" }; variablesLectura.Add(_CI_10_3_SW_3_2_DE);
            _CI_10_4_SW_2_DE = new VariableDigital<bool>() { Id = 773, Nombre = "CI_10_4_SW_2_DE" }; variablesLectura.Add(_CI_10_4_SW_2_DE);
            _CI_10_5_SW_2_DE = new VariableDigital<bool>() { Id = 774, Nombre = "CI_10_5_SW_2_DE" }; variablesLectura.Add(_CI_10_5_SW_2_DE);
            _CI_11_4_SW_2_DE = new VariableDigital<bool>() { Id = 775, Nombre = "CI_11_4_SW_2_DE" }; variablesLectura.Add(_CI_11_4_SW_2_DE);



        }

        private void InicializarVariablesEscritura()
        {
            _PI_3_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2750, Nombre = "PI_3_1_PHK_2_DS" }; variablesEscritura.Add(_PI_3_1_PHK_2_DS);
            _PI_3_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2751, Nombre = "PI_3_2_PHK_2_DS" }; variablesEscritura.Add(_PI_3_2_PHK_2_DS);
            _PI_5_1_LK_DS = new VariableDigital<bool>() { Id = 2752, Nombre = "PI_5_1_LK_DS" }; variablesEscritura.Add(_PI_5_1_LK_DS);
            _PI_5_2_LK_DS = new VariableDigital<bool>() { Id = 2753, Nombre = "PI_5_2_LK_DS" }; variablesEscritura.Add(_PI_5_2_LK_DS);
            _EI_3_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2754, Nombre = "EI_3_1_PHK_2_DS" }; variablesEscritura.Add(_EI_3_1_PHK_2_DS);
            _EI_3_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2755, Nombre = "EI_3_2_PHK_2_DS" }; variablesEscritura.Add(_EI_3_2_PHK_2_DS);
            _CI_2_2_LK_DS = new VariableDigital<bool>() { Id = 2756, Nombre = "CI_2_2_LK_DS" }; variablesEscritura.Add(_CI_2_2_LK_DS);
            _CI_2_3_LK_DS = new VariableDigital<bool>() { Id = 2757, Nombre = "CI_2_3_LK_DS" }; variablesEscritura.Add(_CI_2_3_LK_DS);
            _CI_2_4_LK_DS = new VariableDigital<bool>() { Id = 2758, Nombre = "CI_2_4_LK_DS" }; variablesEscritura.Add(_CI_2_4_LK_DS);
            _CI_2_5_LK_DS = new VariableDigital<bool>() { Id = 2759, Nombre = "CI_2_5_LK_DS" }; variablesEscritura.Add(_CI_2_5_LK_DS);
            _CI_3_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2760, Nombre = "CI_3_1_PHK_2_DS" }; variablesEscritura.Add(_CI_3_1_PHK_2_DS);
            _CI_3_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2761, Nombre = "CI_3_2_PHK_2_DS" }; variablesEscritura.Add(_CI_3_2_PHK_2_DS);
            _CI_8_2_LK_DS = new VariableDigital<bool>() { Id = 2762, Nombre = "CI_8_2_LK_DS" }; variablesEscritura.Add(_CI_8_2_LK_DS);
            _CI_9_4_PHK_2_DS = new VariableDigital<bool>() { Id = 2763, Nombre = "CI_9_4_PHK_2_DS" }; variablesEscritura.Add(_CI_9_4_PHK_2_DS);
            _CI_9_5_PHK_2_DS = new VariableDigital<bool>() { Id = 2764, Nombre = "CI_9_5_PHK_2_DS" }; variablesEscritura.Add(_CI_9_5_PHK_2_DS);
            _CI_9_6_PHK_2_DS = new VariableDigital<bool>() { Id = 2765, Nombre = "CI_9_6_PHK_2_DS" }; variablesEscritura.Add(_CI_9_6_PHK_2_DS);
            _CI_9_7_PHK_2_DS = new VariableDigital<bool>() { Id = 2766, Nombre = "CI_9_7_PHK_2_DS" }; variablesEscritura.Add(_CI_9_7_PHK_2_DS);
            _CI_9_8_PHK_2_DS = new VariableDigital<bool>() { Id = 2767, Nombre = "CI_9_8_PHK_2_DS" }; variablesEscritura.Add(_CI_9_8_PHK_2_DS);
            _CI_9_14_PHK_2_DS = new VariableDigital<bool>() { Id = 2768, Nombre = "CI_9_14_PHK_2_DS" }; variablesEscritura.Add(_CI_9_14_PHK_2_DS);
            _CI_9_15_PHK_2_DS = new VariableDigital<bool>() { Id = 2769, Nombre = "CI_9_15_PHK_2_DS" }; variablesEscritura.Add(_CI_9_15_PHK_2_DS);
            _CI_11_1_IN_1_DS = new VariableDigital<bool>() { Id = 2770, Nombre = "CI_11_1_IN_1_DS" }; variablesEscritura.Add(_CI_11_1_IN_1_DS);
            _CI_11_1_IN_2_DS = new VariableDigital<bool>() { Id = 2771, Nombre = "CI_11_1_IN_2_DS" }; variablesEscritura.Add(_CI_11_1_IN_2_DS);
            _CI_11_1_IN_3_DS = new VariableDigital<bool>() { Id = 2772, Nombre = "CI_11_1_IN_3_DS" }; variablesEscritura.Add(_CI_11_1_IN_3_DS);
            _CI_11_2_IN_1_DS = new VariableDigital<bool>() { Id = 2773, Nombre = "CI_11_2_IN_1_DS" }; variablesEscritura.Add(_CI_11_2_IN_1_DS);
            _CI_11_2_IN_2_DS = new VariableDigital<bool>() { Id = 2774, Nombre = "CI_11_2_IN_2_DS" }; variablesEscritura.Add(_CI_11_2_IN_2_DS);
            _CI_11_2_IN_3_DS = new VariableDigital<bool>() { Id = 2775, Nombre = "CI_11_2_IN_3_DS" }; variablesEscritura.Add(_CI_11_2_IN_3_DS);
            _CI_11_3_IN_1_DS = new VariableDigital<bool>() { Id = 2776, Nombre = "CI_11_3_IN_1_DS" }; variablesEscritura.Add(_CI_11_3_IN_1_DS);
            _CI_11_3_IN_2_DS = new VariableDigital<bool>() { Id = 2777, Nombre = "CI_11_3_IN_2_DS" }; variablesEscritura.Add(_CI_11_3_IN_2_DS);
            _CI_11_3_IN_3_DS = new VariableDigital<bool>() { Id = 2778, Nombre = "CI_11_3_IN_3_DS" }; variablesEscritura.Add(_CI_11_3_IN_3_DS);
            _PI_6_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2779, Nombre = "PI_6_1_PHK_2_DS" }; variablesEscritura.Add(_PI_6_1_PHK_2_DS);
            _PI_6_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2780, Nombre = "PI_6_2_PHK_2_DS" }; variablesEscritura.Add(_PI_6_2_PHK_2_DS);

            _CI_8_1_MN_1_AS = new VariableAnaloga(@"Calibracion\CI_8_1_MN_1_AS.xml", 1) { Id = 6500, Nombre = "CI_8_1_MN_1_AS" }; variablesEscritura.Add(_CI_8_1_MN_1_AS);
            _PS_1_5_MN_1_AS = new VariableAnaloga(@"Calibracion\PS_1_5_MN_1_AS.xml", 1) { Id = 6501, Nombre = "PS_1_5_MN_1_AS" }; variablesEscritura.Add(_PS_1_5_MN_1_AS);
            _CS_1_5_MN_1_AS = new VariableAnaloga(@"Calibracion\CS_1_5_MN_1_AS.xml", 1) { Id = 6502, Nombre = "CS_1_5_MN_1_AS" }; variablesEscritura.Add(_CS_1_5_MN_1_AS);
            _PI_8_1_MN_1_AS = new VariableAnaloga(@"Calibracion\PI_8_1_MN_1_AS.xml", 1) { Id = 6503, Nombre = "PI_8_1_MN_1_AS" }; variablesEscritura.Add(_PI_8_1_MN_1_AS);
            _EI_5_1_MN_1_AS = new VariableAnaloga(@"Calibracion\EI_5_1_MN_1_AS.xml", 1) { Id = 6504, Nombre = "EI_5_1_MN_1_AS" }; variablesEscritura.Add(_EI_5_1_MN_1_AS);
            _OH_9_1_MN_1_AS = new VariableAnaloga(@"Calibracion\OH_9_1_MN_1_AS.xml", 1) { Id = 6013, Nombre = "OH_9_1_MN_1_AS" }; variablesEscritura.Add(_OH_9_1_MN_1_AS);
        }
        #endregion MetodosPrivados
    }
}
