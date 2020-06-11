using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Electronica.Componentes;
using Electronica.Simulacion;
using Microsoft.EntityFrameworkCore.Internal;
using SESION_PRACTICA.Datos;
using SESION_PRACTICA.Modelos;

namespace SESION_PRACTICA.Logica
{
    public delegate void Error(string error, Dispositivo dispositivo);

    public enum Dispositivo
    {
        Omegas,
        FSX
    }
    public class DriverElectronica
    {
        public event Error err;
        private ProcesoOmegas datosOmegas;
        private Thread procesoPrincipal;
        private Thread procesoOmegas;
        private bool procesar;
        private ListadoInstrumentos _Instrumentos;
        private ListadoEtiquetas _Etiquetas;
        private Queue<Mod_Reaccion> _Reacciones;

        private List<string> BoardOscilantes;
        private List<string> SenalesOscilantes;
        private List<double> Valor_FinalOscilar;




        System.Diagnostics.Stopwatch timer;

        public bool EstaOmegas
        {
            get { return (datosOmegas.EstaConectado && datosOmegas.EstaConectado2 && datosOmegas.EstaConectado3); }
        }

        public DriverElectronica()
        {
            datosOmegas = new ProcesoOmegas();

        }




        public void Iniciar(ListadoInstrumentos Instrumentos, ListadoEtiquetas Etiquetas)
        {

            try
            {
                _Instrumentos = Instrumentos;
                _Etiquetas = Etiquetas;
                procesar = false;
                _Reacciones = new Queue<Mod_Reaccion> { };
                timer = new System.Diagnostics.Stopwatch();
                BoardOscilantes = new List<string> { };
                SenalesOscilantes = new List<string> { };
                Valor_FinalOscilar = new List<double> { };
                if (EstaOmegas)
                {
                    datosOmegas.Abrir();
                    procesoOmegas = new Thread(new ThreadStart(ProcesarOmegas));
                    procesar = true;
                    procesoOmegas.Start();
                    Console.WriteLine("Iniciar procesamiento Epsilon");
                }
                if (procesar)
                {
                    procesoPrincipal = new Thread(new ThreadStart(ProcesoPrincipal));
                    procesoPrincipal.Start();
                    Console.WriteLine("Inicia procesamiento Driver");

                }
                else
                {
                    Console.WriteLine("Electrónica No conectada");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Cerrar()
        {
            procesar = false;
            datosOmegas.Cerrar();
        }
        public void DetectarDispositivos()
        {
            datosOmegas.Detectar();
            datosOmegas.Detectar2();
            datosOmegas.Detectar3();
        }

        public ListadoInstrumentos GetListadoDeInstrumentos()
        {
            return _Instrumentos;
        }

        public string GetEtiquetaActual_In(string Nombre_Instrumento)
        {
            if (_Instrumentos.Any(x => x.Nombre == Nombre_Instrumento))
            {
                string EtiquetaActual_In = _Instrumentos.FirstOrDefault(x => x.Nombre.Equals(Nombre_Instrumento)).Etiqueta_Actual_In;
                Console.WriteLine(Nombre_Instrumento + " Etiqueta In: " + EtiquetaActual_In);
                return EtiquetaActual_In;
            }
            return "NULL";
        }

        public string GetEtiquetaActual_Out(string Nombre_Instrumento)
        {
            if (_Instrumentos.Any(x => x.Nombre == Nombre_Instrumento))
            {
                string EtiquetaActual_Out = _Instrumentos.FirstOrDefault(x => x.Nombre.Equals(Nombre_Instrumento)).Etiqueta_Actual_Out;
                Console.WriteLine(Nombre_Instrumento + " Etiqueta Out: " + EtiquetaActual_Out);
                return EtiquetaActual_Out;
            }
            return "NULL";
        }

        public string GetValorInstrumentoAnalogo(string Nombre_Instrumento)
        {
            if (_Instrumentos.Any(x => x.Nombre == Nombre_Instrumento))
            {
                string ValorActualAn = _Instrumentos.FirstOrDefault(x => x.Nombre.Equals(Nombre_Instrumento)).Valor_Analogo_In;
                Console.WriteLine(Nombre_Instrumento + " Valor Análogo In: " + ValorActualAn);
                return ValorActualAn;
            }
            return "NULL";
            
        }

        public void NuevaReaccion(string Nombre_Instrumento, string EtiquetaNueva, float valorInicial, float valorFinal, float tiempoInicio, float duracion, bool oscila)
        {
            if (_Instrumentos.Any(x => x.Nombre == Nombre_Instrumento))
            {
                _Reacciones.Enqueue(new Mod_Reaccion(Nombre_Instrumento, EtiquetaNueva, tiempoInicio, duracion, valorInicial, valorFinal, oscila));
            }         
            
        }



        private void EscribirSenal(string board, string nombre, bool valorAEscribir, double valorAEscribirAn)
        {
            switch (board)
            {
                case "33":
                    switch (nombre)
                    {
                        case "OH_6_2_MN_1_AS":
                            datosOmegas.Board0x21.OH_6_2_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_6_8_MN_1_AS":
                            datosOmegas.Board0x21.OH_6_8_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_6_9_MN_1_AS":
                            datosOmegas.Board0x21.OH_6_9_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_10_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_10_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_23_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_23_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_24_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_24_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_29_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_29_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_30_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_30_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_31_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_31_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_33_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_33_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_34_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_34_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_8_35_MN_1_AS":
                            datosOmegas.Board0x21.OH_8_35_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_5_5_MN_1_AS":
                            datosOmegas.Board0x21.OH_5_5_MN_1_AS = valorAEscribirAn;
                            break;

                        case "OH_2_1_PH_2_M_G_DS":
                            datosOmegas.Board0x21.OH_2_1_PH_2_M_G_DS = valorAEscribir;
                            break;
                        case "OH_2_3_PH_2_M_G_DS":
                            datosOmegas.Board0x21.OH_2_3_PH_2_M_G_DS = valorAEscribir;
                            break;
                        case "OH_2_4_PH_2_M_G_DS":
                            datosOmegas.Board0x21.OH_2_3_PH_2_M_G_DS = valorAEscribir;
                            break;
                        case "OH_2_5_PH_2_M_G_DS":
                            datosOmegas.Board0x21.OH_2_3_PH_2_M_G_DS = valorAEscribir;
                            break;
                        case "OH_7_5_PH_2_DS":
                            datosOmegas.Board0x21.OH_7_5_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_7_6_PH_2_DS":
                            datosOmegas.Board0x21.OH_7_6_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_7_7_PH_2_DS":
                            datosOmegas.Board0x21.OH_7_7_PH_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "34":
                    switch (nombre)
                    {
                        case "OH_8_12_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_12_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_8_36_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_36_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_8_37_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_37_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_8_38_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_38_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_8_40_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_40_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_8_41_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_41_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_8_42_PH_2_DS":
                            datosOmegas.Board0x22.OH_8_42_PH_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "35":
                    switch (nombre)
                    {
                        case "OH_10_29_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_29_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_32_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_32_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_35_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_35_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_38_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_38_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_40_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_40_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_42_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_42_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_43_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_43_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_47_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_47_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_54_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_54_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_55_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_55_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_56_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_56_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_10_57_MN_1_AS":
                            datosOmegas.Board0x23.OH_10_57_MN_1_AS = valorAEscribirAn;
                            break;
                    }
                    break;
                case "36":
                    switch (nombre)
                    {
                        case "OH_10_7_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_7_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_8_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_8_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_9_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_9_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_10_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_10_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_11_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_11_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_12_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_12_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_13_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_13_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_14_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_14_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_15_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_15_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_16_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_16_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_17_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_17_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_18_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_18_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_19_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_19_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_20_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_20_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_21_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_21_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_22_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_22_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_23_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_23_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_24_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_24_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_25_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_24_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_26_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_26_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_48_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_48_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_52_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_52_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_10_58_PHK_2_DS":
                            datosOmegas.Board0x24.OH_10_58_PHK_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "37":
                    switch (nombre)
                    {
                        case "OH_11_3_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_3_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_9_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_9_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_15_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_15_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_22_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_22_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_29_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_29_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_31_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_31_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_36_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_36_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_44_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_44_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_49_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_49_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_11_55_MN_1_AS":
                            datosOmegas.Board0x25.OH_11_55_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_17_1_Brujula_86_AS":
                            datosOmegas.Board0x25.OH_17_1_Brujula_86_AS = valorAEscribirAn;
                            break;

                    }
                    break;
                case "38":
                    switch (nombre)
                    {
                        case "OH_11_5_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_5_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_11_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_11_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_19_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_19_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_27_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_27_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_30_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_30_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_34_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_30_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_42_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_42_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_52_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_52_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_11_58_PHK_2_DS":
                            datosOmegas.Board0x26.OH_11_58_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_12_4_PL_2_R_DS":
                            datosOmegas.Board0x26.OH_12_4_PL_2_R_DS = valorAEscribir;
                            break;
                        case "OH_12_5_PL_2_R_DS":
                            datosOmegas.Board0x26.OH_12_5_PL_2_R_DS = valorAEscribir;
                            break;
                        case "OH_12_7_PL_2_R_DS":
                            datosOmegas.Board0x26.OH_12_7_PL_2_R_DS = valorAEscribir;
                            break;
                        case "OH_12_9_PL_2_R_DS":
                            datosOmegas.Board0x26.OH_12_9_PL_2_R_DS = valorAEscribir;
                            break;
                        case "OH_12_8_PL_2_R_DS":
                            datosOmegas.Board0x26.OH_12_8_PL_2_R_DS = valorAEscribir;
                            break;
                        case "OH_12_4_PL_2_F_DS":
                            datosOmegas.Board0x26.OH_12_4_PL_2_F_DS = valorAEscribir;
                            break;
                        case "OH_12_5_PL_2_F_DS":
                            datosOmegas.Board0x26.OH_12_5_PL_2_F_DS = valorAEscribir;
                            break;
                        case "OH_12_7_PL_2_F_DS":
                            datosOmegas.Board0x26.OH_12_7_PL_2_F_DS = valorAEscribir;
                            break;
                        case "OH_12_8_PL_2_F_DS":
                            datosOmegas.Board0x26.OH_12_7_PL_2_F_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "39":
                    switch (nombre)
                    {
                        case "OH_14_7_PHK_2_DS":
                            datosOmegas.Board0x27.OH_14_7_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_14_8_PHK_2_DS":
                            datosOmegas.Board0x27.OH_14_8_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_14_9_PHK_2_DS":
                            datosOmegas.Board0x27.OH_14_9_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_14_10_PHK_2_DS":
                            datosOmegas.Board0x27.OH_14_10_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_14_11_PHK_2_DS":
                            datosOmegas.Board0x27.OH_14_11_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_14_12_PHK_2_DS":
                            datosOmegas.Board0x27.OH_14_12_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_15_1_PH_2_DS":
                            datosOmegas.Board0x27.OH_15_1_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_15_4_PH_2_DS":
                            datosOmegas.Board0x27.OH_15_4_PH_2_DS = valorAEscribir;
                            break;
                        case "OH_16_1_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_2_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_3_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_3_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_4_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_4_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_5_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_5_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_6_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_6_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_7_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_7_PHK_2_DS = valorAEscribir;
                            break;
                        case "OH_16_8_PHK_2_DS":
                            datosOmegas.Board0x27.OH_16_8_PHK_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "40":
                    switch (nombre)
                    {
                        case "FC_2_6_PHK_2_DS":
                            datosOmegas.Board0x28.FC_2_6_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_2_6_PHK_2_2_DS":
                            datosOmegas.Board0x28.FC_2_6_PHK_2_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "41":
                    switch (nombre)
                    {
                        case "FC_7_2_PHK_2_DS":
                            datosOmegas.Board0x29.FC_7_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_9_23_PHK_2_DS":
                            datosOmegas.Board0x29.FC_9_23_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_12_1_PHK_2_DS":
                            datosOmegas.Board0x29.FC_12_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_12_2_PHK_2_DS":
                            datosOmegas.Board0x29.FC_12_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_12_3_PHK_2_DS":
                            datosOmegas.Board0x29.FC_12_3_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_12_4_PHK_2_DS":
                            datosOmegas.Board0x29.FC_12_4_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_13_23_PHK_2_DS":
                            datosOmegas.Board0x29.FC_13_23_PHK_2_DS = valorAEscribir;
                            break;
                        case "FC_6_1_PHPL_2_DS":
                            datosOmegas.Board0x29.FC_6_1_PHPL_2_DS = valorAEscribir;
                            break;
                        case "FC_6_2_PHPL_2_DS":
                            datosOmegas.Board0x29.FC_6_2_PHPL_2_DS = valorAEscribir;
                            break;
                        case "FC_6_3_PHPL_2_DS":
                            datosOmegas.Board0x29.FC_6_3_PHPL_2_DS = valorAEscribir;
                            break;
                        case "FC_6_4_PHPL_2_DS":
                            datosOmegas.Board0x29.FC_6_4_PHPL_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "46":
                    switch (nombre)
                    {
                        case "CI_8_1_MN_1_AS":
                            datosOmegas.Board0x2E.CI_8_1_MN_1_AS = valorAEscribirAn;
                            break;
                        case "PS_1_5_MN_1_AS":
                            datosOmegas.Board0x2E.PS_1_5_MN_1_AS = valorAEscribirAn;
                            break;
                        case "CS_1_5_MN_1_AS":
                            datosOmegas.Board0x2E.CS_1_5_MN_1_AS = valorAEscribirAn;
                            break;
                        case "PI_8_1_MN_1_AS":
                            datosOmegas.Board0x2E.PI_8_1_MN_1_AS = valorAEscribirAn;
                            break;
                        case "EI_5_1_MN_1_AS":
                            datosOmegas.Board0x2E.EI_5_1_MN_1_AS = valorAEscribirAn;
                            break;
                        case "OH_9_1_MN_1_AS":
                            datosOmegas.Board0x2E.OH_9_1_MN_1_AS = valorAEscribirAn;
                            break;
                        case "PI_3_1_PHK_2_DS":
                            datosOmegas.Board0x2E.PI_3_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "PI_3_2_PHK_2_DS":
                            datosOmegas.Board0x2E.PI_3_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "PI_5_1_LK_DS":
                            datosOmegas.Board0x2E.PI_5_1_LK_DS = valorAEscribir;
                            break;
                        case "PI_5_2_LK_DS":
                            datosOmegas.Board0x2E.PI_5_2_LK_DS = valorAEscribir;
                            break;
                        case "EI_3_1_PHK_2_DS":
                            datosOmegas.Board0x2E.EI_3_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "EI_3_2_PHK_2_DS":
                            datosOmegas.Board0x2E.EI_3_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_2_2_LK_DS":
                            datosOmegas.Board0x2E.CI_2_2_LK_DS = valorAEscribir;
                            break;
                        case "CI_2_3_LK_DS":
                            datosOmegas.Board0x2E.CI_2_3_LK_DS = valorAEscribir;
                            break;
                        case "CI_2_4_LK_DS":
                            datosOmegas.Board0x2E.CI_2_4_LK_DS = valorAEscribir;
                            break;
                        case "CI_2_5_LK_DS":
                            datosOmegas.Board0x2E.CI_2_5_LK_DS = valorAEscribir;
                            break;
                        case "CI_3_1_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_3_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_3_2_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_3_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_8_2_LK_DS":
                            datosOmegas.Board0x2E.CI_8_2_LK_DS = valorAEscribir;
                            break;
                        case "CI_9_4_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_4_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_9_5_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_5_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_9_6_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_6_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_9_7_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_7_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_9_8_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_8_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_9_14_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_14_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_9_15_PHK_2_DS":
                            datosOmegas.Board0x2E.CI_9_15_PHK_2_DS = valorAEscribir;
                            break;
                        case "CI_11_1_IN_1_DS":
                            datosOmegas.Board0x2E.CI_11_1_IN_1_DS = valorAEscribir;
                            break;
                        case "CI_11_1_IN_2_DS":
                            datosOmegas.Board0x2E.CI_11_1_IN_2_DS = valorAEscribir;
                            break;
                        case "CI_11_1_IN_3_DS":
                            datosOmegas.Board0x2E.CI_11_1_IN_3_DS = valorAEscribir;
                            break;
                        case "CI_11_2_IN_1_DS":
                            datosOmegas.Board0x2E.CI_11_2_IN_1_DS = valorAEscribir;
                            break;
                        case "CI_11_2_IN_2_DS":
                            datosOmegas.Board0x2E.CI_11_2_IN_2_DS = valorAEscribir;
                            break;
                        case "CI_11_2_IN_3_DS":
                            datosOmegas.Board0x2E.CI_11_2_IN_3_DS = valorAEscribir;
                            break;
                        case "CI_11_3_IN_1_DS":
                            datosOmegas.Board0x2E.CI_11_3_IN_1_DS = valorAEscribir;
                            break;
                        case "CI_11_3_IN_2_DS":
                            datosOmegas.Board0x2E.CI_11_3_IN_2_DS = valorAEscribir;
                            break;
                        case "CI_11_3_IN_3_DS":
                            datosOmegas.Board0x2E.CI_11_3_IN_3_DS = valorAEscribir;
                            break;
                        case "PI_6_1_PHK_2_DS":
                            datosOmegas.Board0x2E.PI_6_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "PI_6_2_PHK_2_DS":
                            datosOmegas.Board0x2E.PI_6_2_PHK_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "47":
                    switch (nombre)
                    {

                        case "PS_3_3_PH_2_DS":
                            datosOmegas.Board0x2F.PS_3_3_PH_2_DS = valorAEscribir;
                            break;
                        case "PS_3_4_PH_2_DS":
                            datosOmegas.Board0x2F.PS_3_4_PH_2_DS = valorAEscribir;
                            break;
                        case "PS_3_6_PH_2_DS":
                            datosOmegas.Board0x2F.PS_3_6_PH_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "48":
                    switch (nombre)
                    {
                        case "CS_4_1_PHK_2_DS":
                            datosOmegas.Board0x30.CS_4_1_PHK_2_DS = valorAEscribir;
                            break;
                        case "CS_4_2_PHK_2_DS":
                            datosOmegas.Board0x30.CS_4_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "CS_4_3_PHK_2_DS":
                            datosOmegas.Board0x30.CS_4_3_PHK_2_DS = valorAEscribir;
                            break;
                        case "CS_4_4_PHK_2_DS":
                            datosOmegas.Board0x30.CS_4_4_PHK_2_DS = valorAEscribir;
                            break;
                        case "CS_4_5_PH_2_DS":
                            datosOmegas.Board0x30.CS_4_5_PH_2_DS = valorAEscribir;
                            break;
                        case "CS_4_6_PH_2_DS":
                            datosOmegas.Board0x30.CS_4_6_PH_2_DS = valorAEscribir;
                            break;
                        case "CS_4_7_PH_2_DS":
                            datosOmegas.Board0x30.CS_4_7_PH_2_DS = valorAEscribir;
                            break;
                        case "CS_4_8_PH_2_DS":
                            datosOmegas.Board0x30.CS_4_8_PH_2_DS = valorAEscribir;
                            break;
                        case "CS_4_10_PHPL_2_LZ_DS":
                            datosOmegas.Board0x30.CS_4_10_PHPL_2_LZ_DS = valorAEscribir;
                            break;
                        case "CS_4_10_PHPL_2_BB_DS":
                            datosOmegas.Board0x30.CS_4_10_PHPL_2_BB_DS = valorAEscribir;
                            break;
                        case "CS_4_11_PHPL_2_LZ_DS":
                            datosOmegas.Board0x30.CS_4_11_PHPL_2_LZ_DS = valorAEscribir;
                            break;
                        case "CS_4_11_PHPL_2_BB_DS":
                            datosOmegas.Board0x30.CS_4_11_PHPL_2_BB_DS = valorAEscribir;
                            break;
                        case "CS_4_12_PHPL_2_LZ_DS":
                            datosOmegas.Board0x30.CS_4_12_PHPL_2_LZ_DS = valorAEscribir;
                            break;
                        case "CS_4_12_PHPL_2_BB_DS":
                            datosOmegas.Board0x30.CS_4_12_PHPL_2_BB_DS = valorAEscribir;
                            break;
                        case "CS_4_13_PHPL_2_LZ_DS":
                            datosOmegas.Board0x30.CS_4_13_PHPL_2_LZ_DS = valorAEscribir;
                            break;
                        case "CS_4_13_PHPL_2_BB_DS":
                            datosOmegas.Board0x30.CS_4_13_PHPL_2_BB_DS = valorAEscribir;
                            break;
                        case "CE_3_2_PHK_2_DS":
                            datosOmegas.Board0x30.CE_3_2_PHK_2_DS = valorAEscribir;
                            break;
                        case "CE_3_3_PHK_2_DS":
                            datosOmegas.Board0x30.CE_3_3_PHK_2_DS = valorAEscribir;
                            break;
                        case "CE_3_4_PHK_2_DS":
                            datosOmegas.Board0x30.CE_3_4_PHK_2_DS = valorAEscribir;
                            break;
                        case "CS_3_5_PH_2_DS":
                            datosOmegas.Board0x30.CS_3_5_PH_2_DS = valorAEscribir;
                            break;
                        case "CS_3_6_PH_2_DS":
                            datosOmegas.Board0x30.CS_3_6_PH_2_DS = valorAEscribir;
                            break;
                        case "CS_3_3_PH_2_DS":
                            datosOmegas.Board0x30.CS_3_3_PH_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                case "56":
                    switch (nombre)
                    {
                        case "PB_1_1_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_1_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_2_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_2_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_3_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_3_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_4_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_4_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_5_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_5_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_6_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_6_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_7_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_7_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_8_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_8_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_9_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_9_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_10_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_10_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_11_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_11_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_12_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_12_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_13_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_13_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_14_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_14_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_15_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_15_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_16_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_16_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_17_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_17_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_18_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_18_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_19_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_19_CC_2_DS = valorAEscribir;
                            break;
                        case "PB_1_20_CC_2_DS":
                            datosOmegas.Board0x38.PB_1_20_CC_2_DS = valorAEscribir;
                            break;
                    }
                    break;
                    //  EIDS
                    //case "80":
                    //    switch (nombre)
                    //    { 
                    //    }
                    //    break;
            }
        }



        private void ActualizarEtiquetaDig(Electronica.Simulacion.VariableDigital<bool> variableDigital, ListadoInstrumentos _instrumentos)
        {
            var CodSenal = variableDigital.Id.ToString();
            var PosInstrumento = _instrumentos.Select(x => x.Senales.FirstOrDefault(z => z.IDProtocolo.Equals(CodSenal))).ToList().FindIndex(x => x != null);
            var Nombre_Instrumento = _instrumentos.Select(x => x.Nombre).ElementAt(PosInstrumento).ToString();
            var Instrumento_Actual = _instrumentos.ElementAt(PosInstrumento);

            _Instrumentos.ElementAt(PosInstrumento).Senales.FirstOrDefault(x => x.IDProtocolo == CodSenal).Valor = variableDigital.Valor;
            Actualizar_Etiqueta(_Etiquetas, Instrumento_Actual);
        }

        private void ActualizarValorAn(VariableAnaloga variableAnaloga, ListadoInstrumentos _instrumentos)
        {
            var CodSenal = variableAnaloga.Id.ToString();
            var PosInstrumento = _instrumentos.Select(x => x.Senales.FirstOrDefault(z => z.IDProtocolo.Equals(CodSenal))).ToList().FindIndex(x => x != null);
            var Nombre_Instrumento = _instrumentos.Select(x => x.Nombre).ElementAt(PosInstrumento).ToString();
            var Instrumento_Actual = _instrumentos.ElementAt(PosInstrumento);
            var SenalAsociadaIn = Instrumento_Actual.Senales.FirstOrDefault(x => x.Tipo != "1").NombreSenal;
            var Board = Instrumento_Actual.Senales.FirstOrDefault(x => x.Tipo != "1").Board;
            _Instrumentos.ElementAt(PosInstrumento).Valor_Analogo_In = LeerSenalAnalogaEntrada(SenalAsociadaIn, Board);

        }

        private void Actualizar_Etiqueta(ListadoEtiquetas ListaEtiquetas, Mod_Instrumento InstrumentoActual)
        {
            if (InstrumentoActual.Tipo != 0)
            {
                var EtiquetasXInstrumento = ListaEtiquetas.Where(x => x.Instrumento.Equals(InstrumentoActual)).ToList();
                var Nombre_Etiqueta_In = "";
                var Nombre_Etiqueta_Out = "";
                foreach (var item in EtiquetasXInstrumento)
                {
                    if (item != null)
                    {
                        var ValoresAsociados = item.ValorLabel.Select(x => x != "0").ToArray();


                        var Valores_Senales_Entrada = InstrumentoActual.Senales.Where(x => x.Tipo != "1").Select(x => x.Valor).ToArray();
                        var Valores_Senales_Salida = InstrumentoActual.Senales.Where(f => f.Tipo != "0").Select(x => x.Valor).ToArray();

                        var IdAsociados_In = item.Id_Senales.Where(x => x.Tipo != "1").Select(x => x.IDProtocolo).ToArray();
                        var IdAsociados_Out = item.Id_Senales.Where(x => x.Tipo != "0").Select(x => x.IDProtocolo).ToArray();

                        var IdSenales_In = InstrumentoActual.Senales.Where(x => x.Tipo != "1").Select(o => o.IDProtocolo).ToArray();
                        var IdSenales_Out = InstrumentoActual.Senales.Where(x => x.Tipo != "0").Select(o => o.IDProtocolo).ToArray();

                        if (ValoresAsociados.SequenceEqual(Valores_Senales_Entrada) && (IdAsociados_In.SequenceEqual(IdSenales_In)) && (IdAsociados_In != null))
                        {
                            Nombre_Etiqueta_In = item.Nombre_Etiqueta;
                        }

                        if ((ValoresAsociados.SequenceEqual(Valores_Senales_Salida)) && (IdAsociados_Out.SequenceEqual(IdSenales_Out)) && (IdAsociados_Out != null))
                        {
                            Nombre_Etiqueta_Out = item.Nombre_Etiqueta;
                        }

                    }
                }
                if (Nombre_Etiqueta_In != "" || Nombre_Etiqueta_Out != "")
                {
                    InstrumentoActual.Etiqueta_Actual_In = Nombre_Etiqueta_In;
                    InstrumentoActual.Etiqueta_Actual_Out = Nombre_Etiqueta_Out;
                }
                else
                {
                    InstrumentoActual.Etiqueta_Actual_In = "NULL";
                    InstrumentoActual.Etiqueta_Actual_Out = "NULL";
                }
            }

        }

        private string LeerSenalAnalogaEntrada(string senalAsociadaIn, string board)
        {

            switch (board)
            {
                case "33":
                    switch (senalAsociadaIn)
                    {
                        case "OH_6_1_PT_1_AE":
                            return datosOmegas.Board0x21._OH_6_1_PT_1_AE.Valor.ToString();

                        case "OH_6_11_PT_1_AE":
                            return datosOmegas.Board0x21._OH_6_11_PT_1_AE.Valor.ToString();

                        case "OH_6_17_PT_1_AE":
                            return datosOmegas.Board0x21._OH_6_17_PT_1_AE.Valor.ToString();
                    }
                    break;
                case "35":
                    switch (senalAsociadaIn)
                    {
                        case "OH_10_6_PT_1_AE":
                            return datosOmegas.Board0x23._OH_10_6_PT_1_AE.Valor.ToString();
                    }

                    break;
                case "41":
                    switch (senalAsociadaIn)
                    {
                        case "FC_11_1_L_55_AE":
                            return datosOmegas.Board0x29._FC_11_1_L_55_AE.Valor.ToString();

                    }
                    break;
            }
            return "";
        }

        private async Task DelayMethod(int delaytime)
        {
            Task delay = Task.Delay(delaytime);
            await delay;

        }
        private void ProcesoPrincipal()
        {

            #region CodigoOSC
            //IntPtr OscObj = new IntPtr();
            //byte[] DataReceive = new byte[10];
            //GCHandle handle = GCHandle.Alloc(OscObj, GCHandleType.Pinned);
            //GCHandle handle2 = GCHandle.Alloc(DataReceive, GCHandleType.Pinned);

            //List<Actions> actionlist = instructorRef.getActions();
            //LabelSignals labsignal = null;
            //OscObj = CreateOsc("192.168.0.62", 8282, 7878);
            #endregion
            while (procesar)
            {
                try
                {
                    if (_Reacciones.Any())
                    {
                        var grupoTiempoInicio = _Reacciones.GroupBy(x => x.Tiempo_Inicio).OrderBy(x => x.Key).ToList();
                        var ListaDeDelays = grupoTiempoInicio.Select(x => x.Key).ToArray();
                        int TiempoDeEsperaReal = 0;
                        foreach (var grupoReacciones in grupoTiempoInicio)
                        {
                            var indexGrupoReacciones = grupoTiempoInicio.IndexOf((grupoReacciones));
                            if (indexGrupoReacciones == 0)
                            {
                                TiempoDeEsperaReal = (int)grupoReacciones.Key * 1000;
                            }
                            else
                            {
                                TiempoDeEsperaReal = (int)((grupoReacciones.Key * 1000) - ListaDeDelays[indexGrupoReacciones - 1] * 1000);
                            }

                            Task delay = DelayMethod(TiempoDeEsperaReal);
                            delay.Wait();

                            foreach (Mod_Reaccion Reaccion_Nueva in grupoReacciones)
                            {

                                /* Buscar _Instrumentos el insturmento segun del nombre*/
                                var InstrumentoActual = _Instrumentos.FirstOrDefault(x => x.Nombre.Equals(Reaccion_Nueva.Nombre_Instrumento));
                                if (InstrumentoActual != null)
                                {
                                    /* Verificar si es analogo o digital*/
                                    int EsDigital = InstrumentoActual.Tipo != 0 ? 1 : 2;
                                    switch (EsDigital)
                                    {
                                        /* Si es digital */
                                        case 1:
                                            /*Verificar etiqueta Nueva*/
                                            var ListaEtiquetasXInstrumento = _Etiquetas.Where(X => X.Instrumento.Equals(InstrumentoActual));
                                            var EtiquetaAEscribir = ListaEtiquetasXInstrumento.FirstOrDefault(X => X.Nombre_Etiqueta.Equals(Reaccion_Nueva.Etiqueta_Nueva));
                                            /*Buscar señales asociadas y valores asociados*/
                                            var SenalesAsociadas = EtiquetaAEscribir.Id_Senales;
                                            var ValoresAsociados = EtiquetaAEscribir.ValorLabel;
                                            var posicionInstrumento = _Instrumentos.IndexOf(InstrumentoActual);
                                            /*Escribir señales en la electrónica*/
                                            /*Si oscila*/
                                            if (!Reaccion_Nueva.Oscila)
                                            {
                                                for (int i = 0; i < SenalesAsociadas.Length; i++)
                                                {
                                                    string Board = SenalesAsociadas[i].Board;
                                                    string Nombre = SenalesAsociadas[i].NombreSenal;
                                                    bool ValorAEscribir = ValoresAsociados[i] != "0";
                                                    EscribirSenal(Board, Nombre, ValorAEscribir, 0);
                                                    _Instrumentos.FirstOrDefault(x => x.Nombre.Equals(Reaccion_Nueva.Nombre_Instrumento)).Senales.FirstOrDefault(x => x.NombreSenal.Equals(Nombre)).Valor = ValorAEscribir;
                                                    _Instrumentos.FirstOrDefault(x => x.Nombre.Equals(Reaccion_Nueva.Nombre_Instrumento)).Etiqueta_Actual_Out = Reaccion_Nueva.Etiqueta_Nueva;
                                                    if (SenalesOscilantes.Contains(Nombre))
                                                    {
                                                        BoardOscilantes.RemoveAt(SenalesOscilantes.IndexOf(Nombre));
                                                        SenalesOscilantes.RemoveAt(SenalesOscilantes.IndexOf(Nombre));
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                for (int i = 0; i < SenalesAsociadas.Length; i++)
                                                {
                                                    BoardOscilantes.Add(SenalesAsociadas[i].Board);
                                                    SenalesOscilantes.Add(SenalesAsociadas[i].NombreSenal);
                                                    Valor_FinalOscilar.Add(0);
                                                }
                                            }
                                            break;
                                        case 2:
                                            var SenalAsociada = InstrumentoActual.Senales;
                                            if (!Reaccion_Nueva.Oscila)
                                            {
                                                for (int i = 0; i < SenalAsociada.Length; i++)
                                                {
                                                    string Board = SenalAsociada[i].Board;
                                                    string NombreSenal = SenalAsociada[i].NombreSenal;
                                                    double valor_InicialAEscribir = Reaccion_Nueva.Valor_Inicial;
                                                    double valor_FinalAEscribir = Reaccion_Nueva.Valor_Final;
                                                    EscribirSenal(Board, NombreSenal, false, valor_InicialAEscribir);
                                                    Task delayMotor = DelayMethod(5000);
                                                    delayMotor.Wait();
                                                    EscribirSenal(Board, NombreSenal, false, valor_FinalAEscribir);
                                                    if (SenalesOscilantes.Contains(NombreSenal))
                                                    {
                                                        BoardOscilantes.RemoveAt(SenalesOscilantes.IndexOf(NombreSenal));
                                                        SenalesOscilantes.RemoveAt(SenalesOscilantes.IndexOf(NombreSenal));
                                                    }

                                                }

                                            }
                                            else
                                            {
                                                for (int i = 0; i < SenalAsociada.Length; i++)
                                                {
                                                    BoardOscilantes.Add(SenalAsociada[i].Board);
                                                    SenalesOscilantes.Add(SenalAsociada[i].NombreSenal);
                                                    Valor_FinalOscilar.Add(Reaccion_Nueva.Valor_Final);
                                                }

                                            }
                                            break;
                                    }
                                }

                            }

                        }
                        _Reacciones.Clear()

                        //Verificar el tiempo de reacción agrupar el queue por tiempo de reacción

                       ;
                    }
                    foreach (string item in BoardOscilantes)
                    {
                        if (SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)).Contains("_AS"))
                        {
                            var Valor_Oscilar = (Valor_FinalOscilar.ElementAt(BoardOscilantes.IndexOf(item))) + (Valor_FinalOscilar.ElementAt(BoardOscilantes.IndexOf(item))) * 0.5;
                            EscribirSenal(item, SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)), true, Valor_Oscilar);
                            Console.WriteLine("Senal Escrita " + Valor_Oscilar.ToString() + " " + SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)));
                            Task delayMotor1 = DelayMethod(1000);
                            delayMotor1.Wait();
                            Valor_Oscilar = (Valor_FinalOscilar.ElementAt(BoardOscilantes.IndexOf(item))) - (Valor_FinalOscilar.ElementAt(BoardOscilantes.IndexOf(item))) * 0.5;
                            EscribirSenal(item, SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)), true, Valor_Oscilar);
                            Console.WriteLine("Senal Escrita " + Valor_Oscilar.ToString() + " " + SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)));
                        }
                        else
                        {

                            EscribirSenal(item, SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)), true, 0);
                            Console.WriteLine("Senal Escrita " + true.ToString() + " " + SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)));
                            Task delayOsc = DelayMethod(100);
                            delayOsc.Wait();
                            EscribirSenal(item, SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)), false, 0);
                            Console.WriteLine("Senal Escrita " + false.ToString() + " " + SenalesOscilantes.ElementAt(BoardOscilantes.IndexOf(item)));
                            Task delayOsc2 = DelayMethod(100);
                            delayOsc2.Wait();

                        }
                    }


                    if (datosOmegas.Board0x21._OH_6_1_PT_1_AE.erase)
                    {
                        ActualizarValorAn(datosOmegas.Board0x21._OH_6_1_PT_1_AE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_1_PT_1_AE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_17_PT_1_AE.erase)
                    {
                        ActualizarValorAn(datosOmegas.Board0x21._OH_6_17_PT_1_AE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_17_PT_1_AE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_11_PT_1_AE.erase)
                    {
                        ActualizarValorAn(datosOmegas.Board0x21._OH_6_11_PT_1_AE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_11_PT_1_AE.erase = false;
                    }

                    if (datosOmegas.Board0x23._OH_10_6_PT_1_AE.erase)
                    {
                        ActualizarValorAn(datosOmegas.Board0x23._OH_10_6_PT_1_AE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_6_PT_1_AE.erase = false;
                    }

                    if (datosOmegas.Board0x29._FC_11_1_L_55_AE.erase)
                    {
                        ActualizarValorAn(datosOmegas.Board0x29._FC_11_1_L_55_AE, _Instrumentos);
                        datosOmegas.Board0x29._FC_11_1_L_55_AE.erase = false;
                    }




                    #region Senales_Overhead



                    if (datosOmegas.Board0x21._OH_1_1_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_1_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_1_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_1_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_1_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_1_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_1_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_1_4_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_1_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_2_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_2_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_3_1_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_3_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_3_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_3_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_3_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_3_3_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_6_4_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_5_RS_5_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_5_RS_5_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_5_RS_5_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_5_RS_5_4_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_5_RS_5_5_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_6_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_6_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_6_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_6_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_6_7_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_7_SW_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_10_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_10_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_10_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_12_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_10_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_13_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_13_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_14_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_15_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_16_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_16_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_6_16_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_7_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_7_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_7_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_7_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_5_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_5_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.erase = false;


                    }
                    if (datosOmegas.Board0x21._OH_5_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_5_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x21._OH_5_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_3_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x22._OH_8_1_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_1_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_1_PH_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_3_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_5_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_6_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_6_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_6_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_7_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_7_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_8_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_9_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_9_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_11_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_11_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_13_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_13_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_14_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_15_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_16_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_16_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x22._OH_8_17_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_17_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_17_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_18_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_18_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_18_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_19_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_19_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_19_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_20_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_20_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_20_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_21_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_21_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_21_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_22_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_22_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_22_SW_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_25_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_25_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_26_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_26_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_26_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_27_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_28_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_28_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_32_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_32_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_32_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_39_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x22._OH_8_39_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_39_SW_2_DE.erase = false;
                    }
                    //// BOARD 23
                    if (datosOmegas.Board0x23._OH_10_1_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_1_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_1_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x23._OH_10_3_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_3_SW_2_DE.erase = false;

                    }


                    if (datosOmegas.Board0x23._OH_10_4_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_4_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x23._OH_10_5_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_5_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x23._OH_10_27_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_27_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_27_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_28_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_28_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_28_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_28_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_30_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_28_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_30_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_31_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_31_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_31_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_31_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_33_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_33_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_33_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_34_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_34_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_34_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_34_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_36_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_36_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_36_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_37_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_37_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_37_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_37_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_39_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_39_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_39_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_41_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_41_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_41_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_41_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_44_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_44_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_44_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_5_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_6_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_45_RS_7_7_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_46_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_46_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_46_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_49_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x23._OH_10_49_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.erase = false;
                    }
                    ////   BOARD 24
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_50_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_50_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_50_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_51_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_51_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_51_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_53_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_53_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_59_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_59_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x24._OH_10_59_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.erase = false;
                    }


                    //// BOARD 25
                    if (datosOmegas.Board0x25._OH_11_1_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_2_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_4_SW_2_DE.erase)
                    {
                        //============INSTRUMENTOS OH 11====================



                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_6_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_6_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_7_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_7_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_7_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_8_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_10_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_10_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_12_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_12_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_13_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_13_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_13_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_14_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_16_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_17_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_17_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_18_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_18_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_20_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_20_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_20_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_21_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_21_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_21_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_23_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_23_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_23_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_24_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_24_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_24_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_25_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_25_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_26_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_26_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_26_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_28_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_28_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_28_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_32_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_32_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_33_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_33_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_33_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_35_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_35_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_35_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_37_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_37_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_37_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_38_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_38_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_38_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_39_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_39_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_40_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_40_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_41_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_41_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_41_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_43_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_43_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_43_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_45_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_45_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_45_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_45_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_46_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_47_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_47_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_47_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_48_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_48_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_48_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_50_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_50_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_50_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_51_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_51_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_53_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_53_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_53_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_54_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x25._OH_11_54_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_54_SW_2_DE.erase = false;
                    }
                    ////BOARD 26
                    if (datosOmegas.Board0x26._OH_11_56_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_11_56_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_56_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_11_57_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_11_57_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_59_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_11_59_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_59_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_1_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_3_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x26._OH_12_4_PL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_4_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_4_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_5_PL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_5_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_5_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_6_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_6_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_7_PL_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_7_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_7_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_8_PL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_8_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_8_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_9_PL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x26._OH_12_9_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_9_PL_2_DE.erase = false;
                    }


                    ////      BOARD 0X27
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_1_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_1_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_1_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_2_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_2_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_2_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_3_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_3_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_3_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_4_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_4_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_13_4_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_1_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_14_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_14_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_14_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_4_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_14_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_5_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_14_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_6_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_14_6_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_6_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_15_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_15_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_3_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_15_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_15_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_9_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_9_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_9_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_10_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_10_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_11_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_11_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_12_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_12_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_13_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_13_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_14_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_15_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_16_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_16_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x27._OH_17_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase = false;
                    }

                    #endregion
                    #region Senales_Frontal

                    #region Pilot_and_copilot



                    if (datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._PI_3_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._PI_6_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._PI_6_2_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._PI_11_PL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._PI_11_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_11_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._EI_3_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._EI_3_2_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_2_1_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_2_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_2_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_3_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_8_3_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_8_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_8_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_1_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_9_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_9_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_9_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_10_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_10_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_11_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_11_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_12_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_12_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_13_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_13_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_16_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_9_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_1_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_4_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_5_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_10_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_11_4_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2E._CI_11_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_11_4_SW_2_DE.erase = false;
                    }



                    #endregion

                    #region Pilot_Side_Shelf


                    if (datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_1_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PS_3_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_5_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_5_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_3_8_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_3_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_8_SW_2_DE.erase = false;

                    }


                    if (datosOmegas.Board0x2F._PE_2_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PE_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PE_2_SW_3_1_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PE_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PE_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PE_2_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_1_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_1_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x2F._PS_1_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_3_SW_2_DE.erase = false;
                    }




                    #endregion

                    #region Copilot_Side_Shelf

                    if (datosOmegas.Board0x30._CS_2_7_SW_2_DE.erase)
                    {


                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_2_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_2_7_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x30._CS_3_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_3_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_3_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_3_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_7_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_3_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_7_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_8_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_3_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_9_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_9_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_10_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_11_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_12_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_13_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_14_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_15_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_16_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_17_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_4_17_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_17_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_1_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_1_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_1_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_3_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x30._CS_1_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_3_SW_2_DE.erase = false;
                    }

                    #endregion

                    #region circuit br


                    if (datosOmegas.Board0x38._PB_1_1_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_1_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_1_CC_2_DE.erase = false;
                        Console.WriteLine(datosOmegas.Board0x38._PB_1_1_CC_2_DE.Nombre);
                    }
                    if (datosOmegas.Board0x38._PB_1_2_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_2_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_2_CC_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x38._PB_1_3_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_3_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_3_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_4_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_4_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_4_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_5_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_5_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_5_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_6_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_6_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_6_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_7_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_7_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_7_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_8_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_8_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_8_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_9_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_9_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_9_CC_2_DE.erase = false;
                    }



                    if (datosOmegas.Board0x38._PB_1_10_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_10_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_10_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_11_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_11_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_11_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_12_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_12_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_12_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_13_CC_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_13_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_13_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_14_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_14_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_14_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_15_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_15_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_15_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_16_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_16_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_16_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_17_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_17_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_17_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_18_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_18_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_18_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_19_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_19_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_19_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_20_CC_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x38._PB_1_20_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_20_CC_2_DE.erase = false;
                    }

                    #endregion




                    #endregion
                    #region Pedestal
                    if (datosOmegas.Board0x28._FC_2_1_SW_2_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_3_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_3_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x28._FC_2_5_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_6_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_2_6_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_6_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_1_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_1_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_1_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_1_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_1_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_1_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_2_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_2_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_2_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_2_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_2_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_2_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_3_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_3_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_3_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_3_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_3_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_3_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_4_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_4_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_4_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_4_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_4_4_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_4_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_1_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_1_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_1_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_1_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_1_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_1_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_2_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_2_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_2_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_2_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_2_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_2_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_3_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_3_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_3_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_3_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_3_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_3_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_4_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_4_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_4_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_4_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_3_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x28._FC_18_4_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_4_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.erase)
                    {

                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_2_SW_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_3_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_3_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_5_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_5_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_6_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_5_6_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_6_1_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_6_2_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_6_3_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_6_4_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_7_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_7_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_3_PH_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_7_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_7_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_9_23_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_9_23_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_9_23_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_1_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_12_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_2_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_12_2_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_3_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_12_3_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_3_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_4_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_12_4_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_4_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_13_23_PHK_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_13_23_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_13_23_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_17_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_17_1_SW_3_2_DE.erase)
                    {
                        ActualizarEtiquetaDig(datosOmegas.Board0x29._FC_17_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_17_1_SW_3_2_DE.erase = false;
                    }



                    #endregion
                }
                catch
                {
                }


            }


        }



        private void ProcesarOmegas()
        {
            while (procesar)
            {
                try
                {
                    datosOmegas.Procesar();
                    datosOmegas.Procesar2();
                    datosOmegas.Procesar3();
                    Thread.Sleep(10);
                    datosOmegas.Escribir();
                    datosOmegas.Escribir2();
                    datosOmegas.Escribir3();
                }
                catch (Exception ex)
                {
                    ProcesarError(ex.Message, Dispositivo.Omegas);
                }
            }
        }

        private void ProcesarError(string error, Dispositivo disp)
        {
            if (err != null)
            {
                this.err(error, disp);
            }
        }






    }
}
