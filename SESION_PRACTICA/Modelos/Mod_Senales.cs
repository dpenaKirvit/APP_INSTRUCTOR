namespace SESION_PRACTICA.Modelos
{
    public class Mod_Senales
    {
        private string _idprotocolo;
        private string _nombresenal;
        private string _valor;

        public string IDProtocolo
        {
            get { return _idprotocolo; }
            set { _idprotocolo = value; }

        }

        public string NombreSenal
        {
            get { return _nombresenal; }
            set { _nombresenal = value; }

        }

        public string Valor
        {
            get { return _valor; }
            set { _valor= value; }

        }

        public Mod_Senales() { }
        public Mod_Senales(string IDPrt, string NombreSen, string ValorSen) {
            IDProtocolo = IDPrt;
            NombreSenal = NombreSen;
            Valor = ValorSen;
        
        }
    }
}