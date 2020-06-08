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
using Microsoft.EntityFrameworkCore.Internal;
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
        System.Diagnostics.Stopwatch timer;

        public bool EstaOmegas
        {
            get { return (datosOmegas.EstaConectado && datosOmegas.EstaConectado2 && datosOmegas.EstaConectado3); }
        }

        public DriverElectronica()
        {
            datosOmegas = new ProcesoOmegas();
            
        }




        public void Iniciar(ListadoInstrumentos Instrumentos, ListadoEtiquetas Etiquetas) {

            try
            {
                _Instrumentos = Instrumentos;
                _Etiquetas = Etiquetas;
                procesar = false;
                timer = new System.Diagnostics.Stopwatch();
                if (datosOmegas.EstaConectado)
                {

                    Console.WriteLine("Electrónica conectada");
                    datosOmegas.Abrir();
                    procesoOmegas = new Thread(new ThreadStart(ProcesarOmegas));
                    procesar = true;
                    procesoOmegas.Start();
                    Console.WriteLine("Inicia el procesamiento de señales");
                }
                if (procesar)
                {
                    procesoPrincipal = new Thread(new ThreadStart(ProcesoPrincipal));
                    procesoPrincipal.Start();
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

        public string GetEtiquetaActual(int Id_Instrumento) {
            string NombreInstrumento = _Instrumentos.FirstOrDefault(y => y.ID.Equals(Id_Instrumento)).Nombre;
            string EtiquetaActual = _Instrumentos.FirstOrDefault(x => x.ID.Equals(Id_Instrumento)).Etiqueta_Actual;
            Console.WriteLine(NombreInstrumento + " Eitqueta: " + EtiquetaActual);
            return EtiquetaActual;                
        }

       
        private void HallarInstrumento (Electronica.Simulacion.VariableDigital<bool> variableDigital, ListadoInstrumentos _instrumentos)
        {
            var CodSenal = variableDigital.Id.ToString();
            var PosInstrumento = _instrumentos.Select(x => x.Senales.FirstOrDefault(z => z.IDProtocolo.Equals(CodSenal))).ToList().FindIndex(x => x != null);
            var Nombre_Instrumento = _instrumentos.Select(x => x.Nombre).ElementAt(PosInstrumento).ToString();
            var Instrumento_Actual = _instrumentos.ElementAt(PosInstrumento);
            _Instrumentos.ElementAt(PosInstrumento).Senales.FirstOrDefault(x => x.IDProtocolo == CodSenal).Valor = variableDigital.Valor;
            var Etiqueta = Actualizar_Etiqueta(_Etiquetas, Instrumento_Actual);           
        }

        private string Actualizar_Etiqueta(ListadoEtiquetas ListaEtiquetas, Mod_Instrumento InstrumentoActual) {

            var EtiquetasXInstrumento = ListaEtiquetas.Where(x => x.Instrumento.Equals(InstrumentoActual)).ToList();
            var Nombre_Etiqueta = "";
            foreach (var item in EtiquetasXInstrumento)
            {
                if (item != null)
                {                    
                    var ValoresAsociados = item.ValorLabel.Select(x =>( x != "0")).ToArray();
                    var Valores_Senales = InstrumentoActual.Senales.Where(x => x.Tipo != "1").Select(y => y.Valor).ToArray(); ;
                  if (ValoresAsociados.SequenceEqual(Valores_Senales))
                    {
                        Nombre_Etiqueta = item.Nombre_Etiqueta;
                    }
                }

            }
            if (Nombre_Etiqueta != "")
            {
                InstrumentoActual.Etiqueta_Actual= Nombre_Etiqueta;
                return Nombre_Etiqueta;
            }
            InstrumentoActual.Etiqueta_Actual = "NULL";
            return "No hay etiqueta asociada";
        }

        private void ProcesoPrincipal() {

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
                    #region Senales_Overhead

                    if (datosOmegas.Board0x21._OH_1_1_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_1_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_1_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_1_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_1_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_1_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_1_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_3_SW_2_DE.erase = false; 
                    }
                    if (datosOmegas.Board0x21._OH_1_4_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_1_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_1_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.erase)
                    {
                       
                        HallarInstrumento(datosOmegas.Board0x21._OH_2_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.erase = false;
                      
                    }
                    if (datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_2_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_3_1_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_3_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_3_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_3_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_3_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_3_3_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_6_4_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_4_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_5_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_6_7_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_7_SW_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_12_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_13_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_13_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_14_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_15_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_16_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_16_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_6_16_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_7_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_7_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_7_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_7_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_5_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_5_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.erase = false;


                    }
                    if (datosOmegas.Board0x21._OH_5_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_5_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x21._OH_5_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x21._OH_5_3_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x22._OH_8_1_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_1_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_1_PH_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.erase = false; 
                    }
                    if (datosOmegas.Board0x22._OH_8_3_PH_2_DE.erase)
                    {
                       HallarInstrumento(datosOmegas.Board0x22._OH_8_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_5_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_6_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_6_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_6_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_7_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_7_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_8_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_9_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_9_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_11_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_11_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_13_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_13_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_14_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_15_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_16_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_16_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x22._OH_8_17_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_17_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_17_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_18_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_18_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_18_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_19_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_19_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_19_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_20_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_20_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_20_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_21_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_21_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_21_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_22_SW_2_DE.erase)
                    {
                                               
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_22_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_22_SW_2_DE.erase = false;
                       
                    }
                    if (datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_25_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_25_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_26_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_26_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_26_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_27_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_28_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_28_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_32_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_32_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_32_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_39_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x22._OH_8_39_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x22._OH_8_39_SW_2_DE.erase = false;
                    }
                    //// BOARD 23
                    if (datosOmegas.Board0x23._OH_10_1_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_1_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_1_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x23._OH_10_3_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x23._OH_10_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_3_SW_2_DE.erase = false;

                    }


                    if (datosOmegas.Board0x23._OH_10_4_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x23._OH_10_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_4_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x23._OH_10_5_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_5_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x23._OH_10_27_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_27_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_27_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_30_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_30_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_33_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_33_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_33_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_36_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x23._OH_10_36_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_36_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_39_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_39_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_39_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x23._OH_10_44_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_44_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_44_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_4_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_5_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_6_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_7_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_46_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_46_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x23._OH_10_46_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_49_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x23._OH_10_49_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.erase = false;
                    }
                    ////   BOARD 24
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_50_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_50_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_50_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_51_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_51_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_51_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_53_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_53_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_59_RS_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_59_RS_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x24._OH_10_59_RS_3_3_DE, _Instrumentos);
                        datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.erase = false;
                    }


                    //// BOARD 25
                    if (datosOmegas.Board0x25._OH_11_1_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x25._OH_11_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_2_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x25._OH_11_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_4_SW_2_DE.erase)
                    {
                        //============INSTRUMENTOS OH 11====================



                        HallarInstrumento(datosOmegas.Board0x25._OH_11_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_6_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_6_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_7_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_7_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_7_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_8_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_10_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_10_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_12_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_12_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_13_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_13_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_13_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_14_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_16_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_17_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_17_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_18_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_18_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_20_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_20_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_20_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_21_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_21_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_21_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_23_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x25._OH_11_23_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_23_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_24_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_24_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_24_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_25_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_25_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_26_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_26_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_26_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_28_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_28_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_28_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_32_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_32_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_33_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_33_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_33_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_35_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_35_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_35_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_37_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_37_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_37_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_38_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_38_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_38_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_39_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_39_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_40_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_40_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_41_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_41_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_41_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_43_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x25._OH_11_43_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_43_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_45_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_45_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_45_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_45_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_46_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_47_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_47_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_47_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_48_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_48_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_48_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_50_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_50_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_50_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_51_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_51_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_53_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x25._OH_11_53_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_53_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_54_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x25._OH_11_54_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x25._OH_11_54_SW_2_DE.erase = false;
                    }
                    ////BOARD 26
                    if (datosOmegas.Board0x26._OH_11_56_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_11_56_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_56_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_11_57_RS_2_1_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_11_57_RS_2_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_59_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_11_59_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_11_59_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_1_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x26._OH_12_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_3_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x26._OH_12_4_PL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_4_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_4_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_5_PL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_5_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_5_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_6_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_6_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_7_PL_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x26._OH_12_7_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_7_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_8_PL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_8_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_8_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_9_PL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x26._OH_12_9_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x26._OH_12_9_PL_2_DE.erase = false;
                    }


                    ////      BOARD 0X27
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_1_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_1_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_1_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_2_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_2_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_2_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_3_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_3_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_3_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_4_SW_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_4_SW_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_13_4_SW_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_1_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x27._OH_14_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_14_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_2_SW_2_DE.erase = false;
                      }
                    if (datosOmegas.Board0x27._OH_14_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_14_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_4_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_14_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_5_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_14_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_6_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_14_6_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_14_6_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_15_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_15_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_3_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_15_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_15_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_9_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_9_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_9_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_10_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_10_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_11_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_11_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_12_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_12_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_13_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_13_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_14_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x27._OH_16_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_15_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_16_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_16_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_16_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x27._OH_17_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase = false;
                    }
                   
                    #endregion
                    #region Senales_Frontal

                    #region Pilot_and_copilot



                    if (datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._PI_3_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._PI_6_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._PI_6_2_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._PI_11_PL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._PI_11_PL_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._PI_11_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._EI_3_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._EI_3_2_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_2_1_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x2E._CI_2_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_2_1_SW_2_DE.erase = false;
                    }

                   
                    if (datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_3_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_8_3_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_8_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_8_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_1_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_9_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_9_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_9_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_10_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_10_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_11_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_11_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_12_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_12_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_13_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_13_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_16_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_9_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_9_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_1_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_4_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_5_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_10_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_10_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_11_4_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2E._CI_11_4_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2E._CI_11_4_SW_2_DE.erase = false;
                    }



                    #endregion

                    #region Pilot_Side_Shelf


                    if (datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_1_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PS_3_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_5_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_5_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_3_8_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_3_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_3_8_SW_2_DE.erase = false;

                    }


                    if (datosOmegas.Board0x2F._PE_2_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PE_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PE_2_SW_3_1_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PE_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PE_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PE_2_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_1_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_1_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x2F._PS_1_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x2F._PS_1_3_SW_2_DE.erase = false;
                    }




                    #endregion

                    #region Copilot_Side_Shelf

                    if (datosOmegas.Board0x30._CS_2_7_SW_2_DE.erase)
                    {


                        HallarInstrumento(datosOmegas.Board0x30._CS_2_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_2_7_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x30._CS_3_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_3_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_3_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_3_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_7_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_3_7_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_7_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_8_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_3_8_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_3_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_9_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_9_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_10_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_11_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_12_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_13_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_14_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_14_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_15_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_15_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_16_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_16_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_17_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_4_17_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_4_17_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_1_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_1_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_1_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_3_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x30._CS_1_3_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x30._CS_1_3_SW_2_DE.erase = false;
                    }

                    #endregion

                    #region circuit br


                    if (datosOmegas.Board0x38._PB_1_1_CC_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x38._PB_1_1_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_1_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_2_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_2_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_2_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_3_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_3_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_3_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_4_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_4_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_4_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_5_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_5_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_5_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_6_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_6_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_6_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_7_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_7_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_7_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_8_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_8_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_8_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_9_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_9_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_9_CC_2_DE.erase = false;
                    }



                    if (datosOmegas.Board0x38._PB_1_10_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_10_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_10_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_11_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_11_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_11_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_12_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_12_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_12_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_13_CC_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x38._PB_1_13_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_13_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_14_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_14_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_14_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_15_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_15_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_15_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_16_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_16_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_16_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_17_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_17_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_17_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_18_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_18_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_18_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_19_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_19_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_19_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_20_CC_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x38._PB_1_20_CC_2_DE, _Instrumentos);
                        datosOmegas.Board0x38._PB_1_20_CC_2_DE.erase = false;
                    }

                    #endregion




                    #endregion
                    #region Pedestal
                    if (datosOmegas.Board0x28._FC_2_1_SW_2_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x28._FC_2_1_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x28._FC_2_2_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_2_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_3_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_3_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x28._FC_2_5_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_5_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_6_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_2_6_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_2_6_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_1_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_1_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_1_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_1_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_1_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_1_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_2_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_2_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_2_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_2_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_2_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_2_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_3_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_3_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_3_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_3_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_3_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_3_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_4_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_4_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_4_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_4_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_4_4_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_4_4_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_1_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_1_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_1_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_1_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_1_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_1_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_2_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_2_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_2_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_2_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_2_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_2_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_3_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_3_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_3_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_3_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_3_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_3_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_4_L_4_1_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_4_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_4_L_4_2_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_4_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_3_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x28._FC_18_4_L_4_3_DE, _Instrumentos);
                        datosOmegas.Board0x28._FC_18_4_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.erase)
                    {

                        HallarInstrumento(datosOmegas.Board0x29._FC_5_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_1_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_2_SW_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_2_SW_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_3_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.erase = false;
                    }
                   
                    if (datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_3_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase = false;
                    }
                  
                    if (datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_4_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_4_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_5_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_5_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_6_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_5_6_SW_3_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_6_1_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_6_2_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_6_3_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_6_4_PHPL_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_7_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_7_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_3_PH_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_7_3_PH_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_7_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_9_23_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_9_23_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_9_23_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_1_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_12_1_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_2_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_12_2_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_3_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_12_3_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_3_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_4_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_12_4_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_12_4_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_13_23_PHK_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_13_23_PHK_2_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_13_23_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_17_1_SW_3_1_DE, _Instrumentos);
                        datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_17_1_SW_3_2_DE.erase)
                    {
                        HallarInstrumento(datosOmegas.Board0x29._FC_17_1_SW_3_2_DE, _Instrumentos);
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
