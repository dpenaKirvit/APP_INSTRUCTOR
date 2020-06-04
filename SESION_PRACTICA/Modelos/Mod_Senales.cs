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

        public bool Valor
        {
            get { return _valor; }
            set { _valor= value; }

        }

        public Mod_Senales() { }

        public Mod_Senales(string IDPrt, string NombreSen, bool ValorSen) {
            IDProtocolo = IDPrt;
            NombreSenal = NombreSen;
            Valor = ValorSen;
        
        }
    }
}