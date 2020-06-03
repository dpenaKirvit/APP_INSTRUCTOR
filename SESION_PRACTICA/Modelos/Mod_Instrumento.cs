using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using SESION_PRACTICA.Datos;

namespace SESION_PRACTICA.Modelos
{

    public class ListadoInstrumentos : ObservableCollection<Mod_Instrumento>
    {

    }

    public class Mod_Instrumento
    {
        private int _id;
        private string _nombre_instrumento;
        private Mod_Senales[] _senales;
     
        
        public int ID {
            get { return _id; }
            set { _id = value; }
        
        }

        public string Nombre
        {
            get { return _nombre_instrumento; }
            set { _nombre_instrumento = value; }

        }

        public Mod_Senales [] Senales
        {
            get { return _senales; }
            set { _senales = value; }

        }

        
        public string EtiquetaActual() {
            return "La etiqueta";
        }

        public Mod_Instrumento() { }

        public Mod_Instrumento(int Id, string NombreIns, Mod_Senales[]Senales_Ele) {
            ID = Id;
            Nombre = NombreIns;
            Senales = Senales_Ele;
            
        }

    }
}
