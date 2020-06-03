﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SESION_PRACTICA.Datos;

namespace SESION_PRACTICA.Modelos
{
    public class ListadoEtiquetas : ObservableCollection<Mod_Etiqueta>
    {
       
    }

    public class Mod_Etiqueta
    {
        private int _id;
        private string _nombreetiqueta;
        private Mod_Instrumento _Instrumento;
        public int ID
        {
            get { return _id; }
            set { _id = value; }

        }

        public string Nombre_Etiqueta
        {
            get { return _nombreetiqueta; }
            set { _nombreetiqueta = value; }

        }

        public Mod_Instrumento Instrumento
        {
            get { return _Instrumento; }
            set { _Instrumento = value; }

        }

       

        public Mod_Etiqueta() { }

        public Mod_Etiqueta(int Id, string NombreEtiq, Mod_Instrumento Instrument)
        {
            ID = Id;
            Nombre_Etiqueta = NombreEtiq;
            Instrumento = Instrument;            
        }

    }
}
