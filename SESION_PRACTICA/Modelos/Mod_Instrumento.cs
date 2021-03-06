﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int _tipo;
        private string _etiqueta_Actual_in;
        private string _etiqueta_Actual_out;
        private string _valor_analogo_in;



        public int ID
        {
            get { return _id; }
            set { _id = value; }

        }

        public string Valor_Analogo_In {
            get { return _valor_analogo_in; }
            set { _valor_analogo_in = value; }
        }

        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }

        }

        public string Nombre
        {
            get { return _nombre_instrumento; }
            set { _nombre_instrumento = value; }

        }

        public Mod_Senales[] Senales
        {
            get { return _senales; }
            set { _senales = value; }

        }

        public string Etiqueta_Actual_In{
            get { return _etiqueta_Actual_in; }
            set { _etiqueta_Actual_in = value; }
        }
        public string Etiqueta_Actual_Out
        {
            get { return _etiqueta_Actual_out; }
            set { _etiqueta_Actual_out = value; }
        }


        public Mod_Instrumento() { }

        public Mod_Instrumento(int Id, string NombreIns, Mod_Senales[] Senales_Ele, int TipoDoA, string valorAnalogoIn)
        {
            ID = Id;
            Nombre = NombreIns;
            Senales = Senales_Ele;
            Tipo = TipoDoA;
            Valor_Analogo_In = valorAnalogoIn;

        }

    }
}
