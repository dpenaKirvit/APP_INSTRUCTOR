using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SESION_PRACTICA.Modelos
{

    public class ListadoReacciones : ObservableCollection<Mod_Reaccion>
    {

    }
    public class Mod_Reaccion
    {
        private string _nombre_Instrumento;
        private string _etiqueta_nueva;
        private float _valor_inicial;
        private float _valor_final;
        private bool _oscila;
        private float _duracion;
        private float _tiempo_inicio;


        public string Nombre_Instrumento {
            get { return _nombre_Instrumento; }
            set { _nombre_Instrumento = value; }

        }

        public string Etiqueta_Nueva
        {
            get { return _etiqueta_nueva; }
            set { _etiqueta_nueva = value; }

        }

        public float Valor_Inicial {
            get { return _valor_inicial; }
            set { _valor_inicial = value; }

        }

        public float Valor_Final {
            get { return _valor_final; }
            set { _valor_final = value; }
        }

        public bool Oscila {
            get { return _oscila; }
            set { _oscila = value; }

        }

        public float Duracion {
            get { return _duracion; }
            set { _duracion = value; }
        }

        public float Tiempo_Inicio {
            get { return _tiempo_inicio; }
            set { _tiempo_inicio = value; }
        }

        public Mod_Reaccion() { }
        public Mod_Reaccion(string NombreIns, string EtiqNueva, float TiempoInicio, float T_Duracion, float Vr_Inicio, float Vr_Fin, bool Oscile) {
            Nombre_Instrumento = NombreIns;
            Etiqueta_Nueva = EtiqNueva;
            Tiempo_Inicio = TiempoInicio;
            Duracion = T_Duracion;
            Valor_Inicial = Vr_Inicio;
            Valor_Final = Vr_Fin;
            Oscila = Oscile;
        }

        ~Mod_Reaccion() { 
        
        
        }

    }
}
