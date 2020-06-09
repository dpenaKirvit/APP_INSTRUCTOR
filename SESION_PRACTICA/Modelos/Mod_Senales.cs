using System.Collections.ObjectModel;

namespace SESION_PRACTICA.Modelos
{
    public class ListadoSenales : ObservableCollection<Mod_Senales>
    {

    }
    public class Mod_Senales
    {
        private string _idprotocolo;
        private string _nombresenal;
        private bool _valor;
        private string _tipo;
        private string _board;
  

        public string IDProtocolo
        {
            get { return _idprotocolo; }
            set { _idprotocolo = value; }

        }

        public string Board {
            get { return _board; }
            set { _board = value; }
        }

        public string NombreSenal
        {
            get { return _nombresenal; }
            set { _nombresenal = value; }

        }

        public bool Valor
        {
            get { return _valor; }
            set { _valor= value; }

        }

        public string Tipo{
            get { return _tipo; }
            set { _tipo = value; }
        }
        public Mod_Senales() { }

        public Mod_Senales(string IDPrt, string NombreSen, bool ValorSen,string TipoSen, string BoardElec) {
            IDProtocolo = IDPrt;
            NombreSenal = NombreSen;
            Valor = ValorSen;
            Tipo = TipoSen;
            Board = BoardElec;
        
        }
    }
}