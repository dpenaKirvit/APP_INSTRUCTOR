using Electronica.Simulacion;

namespace Electronica.Componentes
{
    public partial class VarBoard0x29
    {
        #region Propiedades y variables

        public VariableDigital<bool> _FC_5_1_SW_3_1_DE; public bool FC_5_1_SW_3_1_DE() { return _FC_5_1_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_5_1_SW_3_2_DE; public bool FC_5_1_SW_3_2_DE() { return _FC_5_1_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_5_2_SW_2_DE; public bool FC_5_2_SW_2_DE() { return _FC_5_2_SW_2_DE.Valor; }
        public VariableDigital<bool> _FC_5_3_SW_3_1_DE; public bool FC_5_3_SW_3_1_DE() { return _FC_5_3_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_5_3_SW_3_2_DE; public bool FC_5_3_SW_3_2_DE() { return _FC_5_3_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_5_4_SW_3_1_DE; public bool FC_5_4_SW_3_1_DE() { return _FC_5_4_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_5_4_SW_3_2_DE; public bool FC_5_4_SW_3_2_DE() { return _FC_5_4_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_5_5_SW_3_1_DE; public bool FC_5_5_SW_3_1_DE() { return _FC_5_5_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_5_5_SW_3_2_DE; public bool FC_5_5_SW_3_2_DE() { return _FC_5_5_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_5_6_SW_3_1_DE; public bool FC_5_6_SW_3_1_DE() { return _FC_5_6_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_5_6_SW_3_2_DE; public bool FC_5_6_SW_3_2_DE() { return _FC_5_6_SW_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_6_1_PHPL_2_DE; public bool FC_6_1_PHPL_2_DE() { return _FC_6_1_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _FC_6_2_PHPL_2_DE; public bool FC_6_2_PHPL_2_DE() { return _FC_6_2_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _FC_6_3_PHPL_2_DE; public bool FC_6_3_PHPL_2_DE() { return _FC_6_3_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _FC_6_4_PHPL_2_DE; public bool FC_6_4_PHPL_2_DE() { return _FC_6_4_PHPL_2_DE.Valor; }
        public VariableDigital<bool> _FC_7_1_SW_3_1_DE; public bool FC_7_1_SW_3_1_DE() { return _FC_7_1_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_7_1_SW_3_2_DE; public bool FC_7_1_SW_3_2_DE() { return _FC_7_1_SW_3_2_DE.Valor; }
        //public VariableDigital<bool> _DISPONIBLE_DE; public bool DISPONIBLE_DE() { return _DISPONIBLE_DE.Valor; }
        public VariableDigital<bool> _FC_7_3_PH_2_DE; public bool FC_7_3_PH_2_DE() { return _FC_7_3_PH_2_DE.Valor; }
        public VariableDigital<bool> _FC_9_23_PHK_2_DE; public bool FC_9_23_PHK_2_DE() { return _FC_9_23_PHK_2_DE.Valor; }
      //  public VariableDigital<bool> _DISPONIBLE_DE; public bool DISPONIBLE_DE() { return _DISPONIBLE_DE.Valor; }
        public VariableDigital<bool> _FC_12_1_PHK_2_DE; public bool FC_12_1_PHK_2_DE() { return _FC_12_1_PHK_2_DE.Valor; }
        public VariableDigital<bool> _FC_12_2_PHK_2_DE; public bool FC_12_2_PHK_2_DE() { return _FC_12_2_PHK_2_DE.Valor; }
        public VariableDigital<bool> _FC_12_3_PHK_2_DE; public bool FC_12_3_PHK_2_DE() { return _FC_12_3_PHK_2_DE.Valor; }
        public VariableDigital<bool> _FC_12_4_PHK_2_DE; public bool FC_12_4_PHK_2_DE() { return _FC_12_4_PHK_2_DE.Valor; }
        public VariableDigital<bool> _FC_13_23_PHK_2_DE; public bool FC_13_23_PHK_2_DE() { return _FC_13_23_PHK_2_DE.Valor; }
        public VariableDigital<bool> _FC_16_1_SW_5_1_DE; public bool FC_16_1_SW_5_1_DE() { return _FC_16_1_SW_5_1_DE.Valor; }
        public VariableDigital<bool> _FC_16_1_SW_5_2_DE; public bool FC_16_1_SW_5_2_DE() { return _FC_16_1_SW_5_2_DE.Valor; }
        public VariableDigital<bool> _FC_16_1_SW_5_3_DE; public bool FC_16_1_SW_5_3_DE() { return _FC_16_1_SW_5_3_DE.Valor; }
        public VariableDigital<bool> _FC_16_1_SW_5_4_DE; public bool FC_16_1_SW_5_4_DE() { return _FC_16_1_SW_5_4_DE.Valor; }
        public VariableDigital<bool> _FC_16_2_L_3_1_DE; public bool FC_16_2_L_3_1_DE() { return _FC_16_2_L_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_16_2_L_3_2_DE; public bool FC_16_2_L_3_2_DE() { return _FC_16_2_L_3_2_DE.Valor; }
        public VariableDigital<bool> _FC_17_1_SW_3_1_DE; public bool FC_17_1_SW_3_1_DE() { return _FC_17_1_SW_3_1_DE.Valor; }
        public VariableDigital<bool> _FC_17_1_SW_3_2_DE; public bool FC_17_1_SW_3_2_DE() { return _FC_17_1_SW_3_2_DE.Valor; }


        public VariableAnaloga _FC_11_1_L_55_AE; public double FC_11_1_L_55_AE { get => _FC_11_1_L_55_AE.Valor; }


        private VariableDigital<bool> _FC_7_2_PHK_2_DS; public bool FC_7_2_PHK_2_DS { get => _FC_7_2_PHK_2_DS.Valor; set => _FC_7_2_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_9_23_PHK_2_DS; public bool FC_9_23_PHK_2_DS { get => _FC_9_23_PHK_2_DS.Valor; set => _FC_9_23_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_12_1_PHK_2_DS; public bool FC_12_1_PHK_2_DS { get => _FC_12_1_PHK_2_DS.Valor; set => _FC_12_1_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_12_2_PHK_2_DS; public bool FC_12_2_PHK_2_DS { get => _FC_12_2_PHK_2_DS.Valor; set => _FC_12_2_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_12_3_PHK_2_DS; public bool FC_12_3_PHK_2_DS { get => _FC_12_3_PHK_2_DS.Valor; set => _FC_12_3_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_12_4_PHK_2_DS; public bool FC_12_4_PHK_2_DS { get => _FC_12_4_PHK_2_DS.Valor; set => _FC_12_4_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_13_23_PHK_2_DS; public bool FC_13_23_PHK_2_DS { get => _FC_13_23_PHK_2_DS.Valor; set => _FC_13_23_PHK_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_6_1_PHPL_2_DS; public bool FC_6_1_PHPL_2_DS { get => _FC_6_1_PHPL_2_DS.Valor; set => _FC_6_1_PHPL_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_6_2_PHPL_2_DS; public bool FC_6_2_PHPL_2_DS { get => _FC_6_2_PHPL_2_DS.Valor; set => _FC_6_2_PHPL_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_6_3_PHPL_2_DS; public bool FC_6_3_PHPL_2_DS { get => _FC_6_3_PHPL_2_DS.Valor; set => _FC_6_3_PHPL_2_DS.Valor = value; }
        private VariableDigital<bool> _FC_6_4_PHPL_2_DS; public bool FC_6_4_PHPL_2_DS { get => _FC_6_4_PHPL_2_DS.Valor; set => _FC_6_4_PHPL_2_DS.Valor = value; }


        #endregion

        #region MetodosPrivados
        private void InicializarVariablesLectura()
        {
            _FC_5_1_SW_3_1_DE = new VariableDigital<bool>() { Id = 400, Nombre = "FC_5_1_SW_3_1_DE" }; variablesLectura.Add(_FC_5_1_SW_3_1_DE);
            _FC_5_1_SW_3_2_DE = new VariableDigital<bool>() { Id = 401, Nombre = "FC_5_1_SW_3_2_DE" }; variablesLectura.Add(_FC_5_1_SW_3_2_DE);
            _FC_5_2_SW_2_DE = new VariableDigital<bool>() { Id = 402, Nombre = "FC_5_2_SW_2_DE" }; variablesLectura.Add(_FC_5_2_SW_2_DE);
            _FC_5_3_SW_3_1_DE = new VariableDigital<bool>() { Id = 403, Nombre = "FC_5_3_SW_3_1_DE" }; variablesLectura.Add(_FC_5_3_SW_3_1_DE);
            _FC_5_3_SW_3_2_DE = new VariableDigital<bool>() { Id = 404, Nombre = "FC_5_3_SW_3_2_DE" }; variablesLectura.Add(_FC_5_3_SW_3_2_DE);
            _FC_5_4_SW_3_1_DE = new VariableDigital<bool>() { Id = 405, Nombre = "FC_5_4_SW_3_1_DE" }; variablesLectura.Add(_FC_5_4_SW_3_1_DE);
            _FC_5_4_SW_3_2_DE = new VariableDigital<bool>() { Id = 406, Nombre = "FC_5_4_SW_3_2_DE" }; variablesLectura.Add(_FC_5_4_SW_3_2_DE);
            _FC_5_5_SW_3_1_DE = new VariableDigital<bool>() { Id = 407, Nombre = "FC_5_5_SW_3_1_DE" }; variablesLectura.Add(_FC_5_5_SW_3_1_DE);
            _FC_5_5_SW_3_2_DE = new VariableDigital<bool>() { Id = 408, Nombre = "FC_5_5_SW_3_2_DE" }; variablesLectura.Add(_FC_5_5_SW_3_2_DE);
            _FC_5_6_SW_3_1_DE = new VariableDigital<bool>() { Id = 409, Nombre = "FC_5_6_SW_3_1_DE" }; variablesLectura.Add(_FC_5_6_SW_3_1_DE);
            _FC_5_6_SW_3_2_DE = new VariableDigital<bool>() { Id = 410, Nombre = "FC_5_6_SW_3_2_DE" }; variablesLectura.Add(_FC_5_6_SW_3_2_DE);
            _FC_6_1_PHPL_2_DE = new VariableDigital<bool>() { Id = 411, Nombre = "FC_6_1_PHPL_2_DE" }; variablesLectura.Add(_FC_6_1_PHPL_2_DE);
            _FC_6_2_PHPL_2_DE = new VariableDigital<bool>() { Id = 412, Nombre = "FC_6_2_PHPL_2_DE" }; variablesLectura.Add(_FC_6_2_PHPL_2_DE);
            _FC_6_3_PHPL_2_DE = new VariableDigital<bool>() { Id = 413, Nombre = "FC_6_3_PHPL_2_DE" }; variablesLectura.Add(_FC_6_3_PHPL_2_DE);
            _FC_6_4_PHPL_2_DE = new VariableDigital<bool>() { Id = 414, Nombre = "FC_6_4_PHPL_2_DE" }; variablesLectura.Add(_FC_6_4_PHPL_2_DE);
            _FC_7_1_SW_3_1_DE = new VariableDigital<bool>() { Id = 415, Nombre = "FC_7_1_SW_3_1_DE" }; variablesLectura.Add(_FC_7_1_SW_3_1_DE);
            _FC_7_1_SW_3_2_DE = new VariableDigital<bool>() { Id = 416, Nombre = "FC_7_1_SW_3_2_DE" }; variablesLectura.Add(_FC_7_1_SW_3_2_DE);
          //  _DISPONIBLE_DE = new VariableDigital<bool>() { Id = 417, Nombre = "DISPONIBLE_DE" }; variablesLectura.Add(_DISPONIBLE_DE);
            _FC_7_3_PH_2_DE = new VariableDigital<bool>() { Id = 418, Nombre = "FC_7_3_PH_2_DE" }; variablesLectura.Add(_FC_7_3_PH_2_DE);
            _FC_9_23_PHK_2_DE = new VariableDigital<bool>() { Id = 419, Nombre = "FC_9_23_PHK_2_DE" }; variablesLectura.Add(_FC_9_23_PHK_2_DE);
         //  _DISPONIBLE_DE = new VariableDigital<bool>() { Id = 420, Nombre = "DISPONIBLE_DE" }; variablesLectura.Add(_DISPONIBLE_DE);
            _FC_12_1_PHK_2_DE = new VariableDigital<bool>() { Id = 421, Nombre = "FC_12_1_PHK_2_DE" }; variablesLectura.Add(_FC_12_1_PHK_2_DE);
            _FC_12_2_PHK_2_DE = new VariableDigital<bool>() { Id = 422, Nombre = "FC_12_2_PHK_2_DE" }; variablesLectura.Add(_FC_12_2_PHK_2_DE);
            _FC_12_3_PHK_2_DE = new VariableDigital<bool>() { Id = 423, Nombre = "FC_12_3_PHK_2_DE" }; variablesLectura.Add(_FC_12_3_PHK_2_DE);
            _FC_12_4_PHK_2_DE = new VariableDigital<bool>() { Id = 424, Nombre = "FC_12_4_PHK_2_DE" }; variablesLectura.Add(_FC_12_4_PHK_2_DE);
            _FC_13_23_PHK_2_DE = new VariableDigital<bool>() { Id = 425, Nombre = "FC_13_23_PHK_2_DE" }; variablesLectura.Add(_FC_13_23_PHK_2_DE);
            _FC_16_1_SW_5_1_DE = new VariableDigital<bool>() { Id = 426, Nombre = "FC_16_1_SW_5_1_DE" }; variablesLectura.Add(_FC_16_1_SW_5_1_DE);
            _FC_16_1_SW_5_2_DE = new VariableDigital<bool>() { Id = 427, Nombre = "FC_16_1_SW_5_2_DE" }; variablesLectura.Add(_FC_16_1_SW_5_2_DE);
            _FC_16_1_SW_5_3_DE = new VariableDigital<bool>() { Id = 428, Nombre = "FC_16_1_SW_5_3_DE" }; variablesLectura.Add(_FC_16_1_SW_5_3_DE);
            _FC_16_1_SW_5_4_DE = new VariableDigital<bool>() { Id = 429, Nombre = "FC_16_1_SW_5_4_DE" }; variablesLectura.Add(_FC_16_1_SW_5_4_DE);
            _FC_16_2_L_3_1_DE = new VariableDigital<bool>() { Id = 430, Nombre = "FC_16_2_L_3_1_DE" }; variablesLectura.Add(_FC_16_2_L_3_1_DE);
            _FC_16_2_L_3_2_DE = new VariableDigital<bool>() { Id = 431, Nombre = "FC_16_2_L_3_2_DE" }; variablesLectura.Add(_FC_16_2_L_3_2_DE);
            _FC_17_1_SW_3_1_DE = new VariableDigital<bool>() { Id = 432, Nombre = "FC_17_1_SW_3_1_DE" }; variablesLectura.Add(_FC_17_1_SW_3_1_DE);
            _FC_17_1_SW_3_2_DE = new VariableDigital<bool>() { Id = 433, Nombre = "FC_17_1_SW_3_2_DE" }; variablesLectura.Add(_FC_17_1_SW_3_2_DE);
            _FC_11_1_L_55_AE = new VariableAnaloga(@"Calibracion\FC_16_2_L_3_1_AE.xml", 1) { Id = 4080, Nombre = "FC_11_1_L_55_AE" }; variablesLectura.Add(_FC_11_1_L_55_AE);


        }

        private void InicializarVariablesEscritura()
        {
            _FC_7_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2400, Nombre = "FC_7_2_PHK_2_DS" }; variablesEscritura.Add(_FC_7_2_PHK_2_DS);
            _FC_9_23_PHK_2_DS = new VariableDigital<bool>() { Id = 2401, Nombre = "FC_9_23_PHK_2_DS" }; variablesEscritura.Add(_FC_9_23_PHK_2_DS);
            _FC_12_1_PHK_2_DS = new VariableDigital<bool>() { Id = 2402, Nombre = "FC_12_1_PHK_2_DS" }; variablesEscritura.Add(_FC_12_1_PHK_2_DS);
            _FC_12_2_PHK_2_DS = new VariableDigital<bool>() { Id = 2403, Nombre = "FC_12_2_PHK_2_DS" }; variablesEscritura.Add(_FC_12_2_PHK_2_DS);
            _FC_12_3_PHK_2_DS = new VariableDigital<bool>() { Id = 2404, Nombre = "FC_12_3_PHK_2_DS" }; variablesEscritura.Add(_FC_12_3_PHK_2_DS);
            _FC_12_4_PHK_2_DS = new VariableDigital<bool>() { Id = 2405, Nombre = "FC_12_4_PHK_2_DS" }; variablesEscritura.Add(_FC_12_4_PHK_2_DS);
            _FC_13_23_PHK_2_DS = new VariableDigital<bool>() { Id = 2406, Nombre = "FC_13_23_PHK_2_DS" }; variablesEscritura.Add(_FC_13_23_PHK_2_DS);
            _FC_6_1_PHPL_2_DS = new VariableDigital<bool>() { Id = 2407, Nombre = "FC_6_1_PHPL_2_DS" }; variablesEscritura.Add(_FC_6_1_PHPL_2_DS);
            _FC_6_2_PHPL_2_DS = new VariableDigital<bool>() { Id = 2408, Nombre = "FC_6_2_PHPL_2_DS" }; variablesEscritura.Add(_FC_6_2_PHPL_2_DS);
            _FC_6_3_PHPL_2_DS = new VariableDigital<bool>() { Id = 2409, Nombre = "FC_6_3_PHPL_2_DS" }; variablesEscritura.Add(_FC_6_3_PHPL_2_DS);
            _FC_6_4_PHPL_2_DS = new VariableDigital<bool>() { Id = 2410, Nombre = "FC_6_4_PHPL_2_DS" }; variablesEscritura.Add(_FC_6_4_PHPL_2_DS);


        }
        #endregion MetodosPrivados
    }
}
