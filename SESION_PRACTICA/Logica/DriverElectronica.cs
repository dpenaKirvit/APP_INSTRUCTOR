using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Electronica.Componentes;

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
        IDictionary<string, string> dictInstrumentsRef;
        SenalAEtiqueta mov;

        public bool EstaOmegas
        {
            get { return (datosOmegas.EstaConectado && datosOmegas.EstaConectado2 && datosOmegas.EstaConectado3); }
        }

        public DriverElectronica()
        {
            datosOmegas = new ProcesoOmegas();
            mov = new SenalAEtiqueta(datosOmegas);
        }


       

    public void Iniciar(IDictionary<string,string> DicInstruments) {
            DicInstruments = dictInstrumentsRef;
            try
            {
                procesar = false;
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



        private bool digitalSignalValue()
        {
            VarBoard0x21 a = datosOmegas.Board0x21;
            Type type = typeof(VarBoard0x21);
            MethodInfo method = type.GetMethod("OH_1_1_SW_2_DE");
            //                    MyReflectionClass c = new MyReflectionClass();
            bool result = (bool)method.Invoke(a, null);
            return result;
        }

        private bool setDictInstrument(string inst)
        {
            bool ret = false;
            if (inst != null)
            {
                string etiqueta = mov.instrumentoDigital(inst);
                if (etiqueta != null)
                    if (dictInstrumentsRef.ContainsKey(inst))
                    {
                        dictInstrumentsRef[inst] = etiqueta;
                        MessageBox.Show(inst + "\n" + etiqueta);
                        ret = true;
                    }
            }
            return ret;
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
                                           
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_1_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_1_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_1_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_1_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_1_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_1_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_1_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_1_4_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_1_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_1_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.erase)
                    {
                        datosOmegas.Board0x21.OH_2_1_PH_2_M_G_DS = datosOmegas.Board0x21.OH_2_2_SW_3_1_DE();
                        datosOmegas.Board0x21.OH_2_3_PH_2_M_G_DS = datosOmegas.Board0x21.OH_2_2_SW_3_1_DE();
                        datosOmegas.Board0x21.OH_2_4_PH_2_M_G_DS = datosOmegas.Board0x21.OH_2_2_SW_3_1_DE();
                        datosOmegas.Board0x21.OH_2_5_PH_2_M_G_DS = datosOmegas.Board0x21.OH_2_2_SW_3_1_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_2_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_2_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_1_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_3_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_3_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_3_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_3_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_3_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_3_3_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x21._OH_6_4_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_5_RS_5_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_5_RS_5_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_5_RS_5_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_5_RS_5_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_5_RS_5_5_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_6_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_6_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_6_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_6_RS_4_4_DE.erase = false;
                    }


                    if (datosOmegas.Board0x21._OH_6_7_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_7_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_7_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_10_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_10_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_10_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_12_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_12_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_13_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_13_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_14_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x21._OH_6_14_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_6_9_MN_1_AS = 4000;


                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_6_9_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_14_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_15_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x21._OH_6_15_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_6_8_MN_1_AS = 4000;


                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_6_8_MN_1_AS = 000;

                        }
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_15_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_16_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_16_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_6_16_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_3_SW_2_DE.erase)
                    {
                        datosOmegas.Board0x21.OH_7_5_PH_2_DS = datosOmegas.Board0x21.OH_7_3_SW_2_DE();
                        datosOmegas.Board0x21.OH_7_6_PH_2_DS = datosOmegas.Board0x21.OH_7_3_SW_2_DE();
                        datosOmegas.Board0x21.OH_7_7_PH_2_DS = datosOmegas.Board0x21.OH_7_3_SW_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_7_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_7_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_7_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_7_4_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_5_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_5_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_5_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_5_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x21._OH_5_3_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x21._OH_5_3_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x21.OH_5_5_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_5_5_MN_1_AS = 0;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x21._OH_5_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x21._OH_5_3_SW_2_DE.erase = false;



                    }

                    if (datosOmegas.Board0x22._OH_8_1_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_1_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_1_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.erase)
                    {
                        //                        // AQUI VAN LAS DEL 8
                        datosOmegas.Board0x22.OH_8_12_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();
                        datosOmegas.Board0x22.OH_8_36_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();
                        datosOmegas.Board0x22.OH_8_37_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();
                        datosOmegas.Board0x22.OH_8_38_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();
                        datosOmegas.Board0x22.OH_8_40_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();
                        datosOmegas.Board0x22.OH_8_41_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();
                        datosOmegas.Board0x22.OH_8_42_PH_2_DS = datosOmegas.Board0x22.OH_8_2_SW_3_1_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_3_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_3_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_5_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_5_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_6_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_6_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_6_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_7_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_7_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_7_SW_2_DE.erase = false;

                    }
                    if (datosOmegas.Board0x22._OH_8_8_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_8_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_9_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_9_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x22._OH_8_11_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_11_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_13_SW_2_DE.erase)
                    {


                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_13_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_14_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_14_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_15_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_15_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_16_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_16_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_17_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_17_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_17_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_18_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_18_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_18_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_19_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_19_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_19_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_20_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x22._OH_8_20_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_8_23_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_8_23_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_20_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_20_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_21_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x22._OH_8_21_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_8_10_MN_1_AS = 4000;


                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_8_10_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_21_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_21_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_22_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x22._OH_8_22_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_8_24_MN_1_AS = 4000;


                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_8_24_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_22_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_22_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_25_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_25_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_26_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_26_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_27_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_27_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_28_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_28_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_32_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x22._OH_8_32_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_8_29_MN_1_AS = 4000;
                            datosOmegas.Board0x21.OH_8_30_MN_1_AS = 4000;
                            datosOmegas.Board0x21.OH_8_31_MN_1_AS = 4000;


                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_8_29_MN_1_AS = 000;
                            datosOmegas.Board0x21.OH_8_30_MN_1_AS = 000;
                            datosOmegas.Board0x21.OH_8_31_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_32_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_32_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x22._OH_8_39_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x22._OH_8_39_SW_2_DE.Valor)
                        {

                            datosOmegas.Board0x21.OH_8_33_MN_1_AS = 4000;
                            datosOmegas.Board0x21.OH_8_34_MN_1_AS = 4000;
                            datosOmegas.Board0x21.OH_8_35_MN_1_AS = 4000;


                        }
                        else
                        {
                            datosOmegas.Board0x21.OH_8_33_MN_1_AS = 000;
                            datosOmegas.Board0x21.OH_8_34_MN_1_AS = 000;
                            datosOmegas.Board0x21.OH_8_35_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x22._OH_8_39_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x22._OH_8_39_SW_2_DE.erase = false;
                    }
                    //// BOARD 23
                    if (datosOmegas.Board0x23._OH_10_1_PH_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_1_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_1_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_2_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x23._OH_10_3_SW_2_DE.erase)
                    {

                        datosOmegas.Board0x24.OH_10_7_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_8_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_9_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_10_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_11_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_12_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_13_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_14_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_15_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_16_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_17_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_18_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_19_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_20_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_21_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_22_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_23_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_24_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_25_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_26_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_48_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_52_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();
                        datosOmegas.Board0x24.OH_10_58_PHK_2_DS = datosOmegas.Board0x23.OH_10_3_SW_2_DE();



                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_3_SW_2_DE.erase = false;

                    }


                    if (datosOmegas.Board0x23._OH_10_4_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_4_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x23._OH_10_5_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_5_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_5_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x23._OH_10_27_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x23._OH_10_27_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_29_MN_1_AS = 4000;
                            datosOmegas.Board0x23.OH_10_54_MN_1_AS = 4000;
                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_29_MN_1_AS = 000;
                            datosOmegas.Board0x23.OH_10_54_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_27_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_27_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_28_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_28_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_28_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_28_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_30_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x23._OH_10_30_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_32_MN_1_AS = 4000;
                            datosOmegas.Board0x23.OH_10_55_MN_1_AS = 4000;
                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_32_MN_1_AS = 000;
                            datosOmegas.Board0x23.OH_10_55_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_30_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_30_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_31_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_31_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_31_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_31_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_33_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x23._OH_10_33_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_35_MN_1_AS = 4000;
                            datosOmegas.Board0x23.OH_10_56_MN_1_AS = 4000;
                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_35_MN_1_AS = 000;
                            datosOmegas.Board0x23.OH_10_56_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_33_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_33_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_34_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_34_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_34_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_34_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_36_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x23._OH_10_36_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_38_MN_1_AS = 4000;
                            datosOmegas.Board0x23.OH_10_57_MN_1_AS = 4000;
                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_38_MN_1_AS = 000;
                            datosOmegas.Board0x23.OH_10_57_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_36_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_36_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_37_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_37_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_37_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_37_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_39_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x23._OH_10_39_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_40_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_40_MN_1_AS = 000;


                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_39_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_39_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_41_RS_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_41_RS_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_41_RS_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_41_RS_4_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.erase)
                    {

                        if (datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_42_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_42_MN_1_AS = 000;


                        }



                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_44_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.erase)
                    {

                        if (datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_43_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_43_MN_1_AS = 000;


                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_44_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.erase)
                    {

                        if (datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.Valor)
                        {
                            datosOmegas.Board0x23.OH_10_47_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x23.OH_10_47_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_44_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_4_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_5_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_6_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_45_RS_7_7_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.erase)
                    {


                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_46_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_46_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_46_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_49_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x23._OH_10_49_RS_2_2_DE.erase = false;
                    }
                    ////   BOARD 24
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_50_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_50_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_50_RS_3_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_51_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_51_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_51_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_53_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_53_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_59_RS_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_59_RS_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x24._OH_10_59_RS_3_3_DE.erase = false;
                    }


                    //// BOARD 25
                    if (datosOmegas.Board0x25._OH_11_1_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_2_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x25._OH_11_2_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_3_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_3_MN_1_AS = 000;

                        }



                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_4_SW_2_DE.erase)
                    {
                        //============INSTRUMENTOS OH 11====================

                        datosOmegas.Board0x26.OH_11_5_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_11_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_19_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_27_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_30_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_34_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_42_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_52_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();
                        datosOmegas.Board0x26.OH_11_58_PHK_2_DS = datosOmegas.Board0x25.OH_11_4_SW_2_DE();


                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_6_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_6_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_7_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_7_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_7_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_8_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_8_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_9_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_9_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_8_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_10_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_10_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_12_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_12_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_13_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_13_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_13_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_14_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_14_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_15_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_15_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_14_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_16_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_16_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_17_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_17_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_18_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_18_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_20_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_20_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_20_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_21_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x25._OH_11_21_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_22_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_22_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_21_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_21_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_23_SW_2_DE.erase)
                    {

                        if (datosOmegas.Board0x25._OH_11_23_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_29_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_29_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_23_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_23_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_24_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_24_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_31_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_31_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_24_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_24_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_25_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_25_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_26_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_26_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_26_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_28_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_28_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_28_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_32_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_32_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_33_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_33_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_33_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_35_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_35_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_36_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_36_MN_1_AS = 000;

                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_35_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_35_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_37_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_37_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_37_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_38_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_38_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_38_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_39_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_39_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_40_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_40_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_41_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_41_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_41_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_43_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_43_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_44_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_44_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_43_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_43_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_45_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_45_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_45_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_46_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_46_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_47_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_47_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_47_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_48_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_48_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_49_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_49_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_48_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_48_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_50_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_50_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_50_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_51_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_51_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_53_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_53_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_53_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x25._OH_11_54_SW_2_DE.erase)
                    {
                        if (datosOmegas.Board0x25._OH_11_54_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x25.OH_11_55_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x25.OH_11_55_MN_1_AS = 000;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x25._OH_11_54_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x25._OH_11_54_SW_2_DE.erase = false;
                    }
                    ////BOARD 26
                    if (datosOmegas.Board0x26._OH_11_56_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_11_56_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_11_56_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_11_57_RS_2_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_11_57_RS_2_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_11_59_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_11_59_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_11_59_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_1_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_3_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x26._OH_12_4_PL_2_DE.erase)
                    {
                        datosOmegas.Board0x26.OH_12_4_PL_2_R_DS = datosOmegas.Board0x26.OH_12_4_PL_2_DE();
                        datosOmegas.Board0x26.OH_12_4_PL_2_F_DS = datosOmegas.Board0x26.OH_12_4_PL_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_4_PL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_4_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_5_PL_2_DE.erase)
                    {
                        datosOmegas.Board0x26.OH_12_5_PL_2_R_DS = datosOmegas.Board0x26.OH_12_5_PL_2_DE();
                        datosOmegas.Board0x26.OH_12_5_PL_2_F_DS = datosOmegas.Board0x26.OH_12_5_PL_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_5_PL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_5_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_6_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_6_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_7_PL_2_DE.erase)
                    {
                        datosOmegas.Board0x26.OH_12_7_PL_2_R_DS = datosOmegas.Board0x26.OH_12_7_PL_2_DE();
                        datosOmegas.Board0x26.OH_12_7_PL_2_F_DS = datosOmegas.Board0x26.OH_12_7_PL_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_7_PL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_7_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_8_PL_2_DE.erase)
                    {
                        datosOmegas.Board0x26.OH_12_8_PL_2_R_DS = datosOmegas.Board0x26.OH_12_8_PL_2_DE();
                        datosOmegas.Board0x26.OH_12_8_PL_2_F_DS = datosOmegas.Board0x26.OH_12_8_PL_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_8_PL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_8_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x26._OH_12_9_PL_2_DE.erase)
                    {
                        datosOmegas.Board0x26.OH_12_9_PL_2_R_DS = datosOmegas.Board0x26.OH_12_9_PL_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x26._OH_12_9_PL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x26._OH_12_9_PL_2_DE.erase = false;
                    }


                    ////      BOARD 0X27
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_1_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_1_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_1_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_2_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_2_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_2_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_3_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_3_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_3_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_4_SW_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_4_SW_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_13_4_SW_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_1_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_14_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_14_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_2_SW_2_DE.erase)
                    {

                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_14_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_14_2_SW_2_DE.erase = false;



                    }
                    if (datosOmegas.Board0x27._OH_14_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_14_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_14_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_4_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_14_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_14_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_5_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_14_5_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_14_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_14_6_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_14_6_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_14_6_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_15_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_15_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_15_3_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_15_3_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_15_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_9_SW_2_DE.erase)
                    {

                        datosOmegas.Board0x27.OH_14_7_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_14_8_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_14_9_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_14_10_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_14_11_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_14_12_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_15_1_PH_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_15_4_PH_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_1_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_2_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_3_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_4_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_5_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_6_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_7_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();
                        datosOmegas.Board0x27.OH_16_8_PHK_2_DS = datosOmegas.Board0x27.OH_16_9_SW_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_9_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_9_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_10_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_10_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_11_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_11_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_12_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_12_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_13_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_13_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_14_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_14_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_15_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_15_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_16_16_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_16_16_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_16_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_17_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x27._OH_17_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x27._OH_17_2_SW_2_DE.erase = false;
                    }
                    #endregion
                    #region Senales_Frontal

                    #region Pilot_and_copilot



                    if (datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._PI_3_1_PHK_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._PI_6_1_PHK_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._PI_6_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._PI_11_PL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._PI_11_PL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._PI_11_PL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._EI_3_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._EI_3_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_2_1_SW_2_DE.erase)
                    {
                        //DIGITALES SALIDA P&C FRONTAL

                        datosOmegas.Board0x2E.PI_3_1_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.PI_3_2_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.PI_5_1_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.PI_5_2_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.EI_3_1_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.EI_3_2_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_2_2_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_2_3_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_2_4_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_2_5_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_3_1_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_3_2_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_8_2_LK_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_4_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_5_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_6_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_7_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_8_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_14_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.CI_9_15_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();

                        datosOmegas.Board0x2E.PI_6_1_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();
                        datosOmegas.Board0x2E.PI_6_2_PHK_2_DS = datosOmegas.Board0x2E.CI_2_1_SW_2_DE();

                        if (datosOmegas.Board0x2E._CI_2_1_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x2E.CI_8_1_MN_1_AS = 4000;
                            datosOmegas.Board0x2E.PI_8_1_MN_1_AS = 4000;
                            datosOmegas.Board0x2E.EI_5_1_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x2E.CI_8_1_MN_1_AS = 0;
                            datosOmegas.Board0x2E.PI_8_1_MN_1_AS = 0;
                            datosOmegas.Board0x2E.EI_5_1_MN_1_AS = 0;
                        }


                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_2_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_2_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_3_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_8_3_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_8_3_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_8_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_1_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_3_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_9_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_9_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_9_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_10_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_10_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_10_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_11_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_11_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_11_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_12_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_12_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_12_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_13_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_13_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_13_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_9_16_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_9_16_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_9_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_1_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_3_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_3_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_4_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_4_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_10_5_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_10_5_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_10_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2E._CI_11_4_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2E._CI_11_4_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2E._CI_11_4_SW_2_DE.erase = false;
                    }



                    #endregion

                    #region Pilot_Side_Shelf


                    if (datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_2_7_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_2_7_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_1_SW_2_DE.erase)
                    {
                        //DIGITALES SALIDA PS

                        datosOmegas.Board0x2F.PS_3_3_PH_2_DS = datosOmegas.Board0x2F.PS_3_1_SW_2_DE();
                        datosOmegas.Board0x2F.PS_3_4_PH_2_DS = datosOmegas.Board0x2F.PS_3_1_SW_2_DE();
                        datosOmegas.Board0x2F.PS_3_6_PH_2_DS = datosOmegas.Board0x2F.PS_3_1_SW_2_DE();


                        if (datosOmegas.Board0x2F._PS_3_1_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x2E.PS_1_5_MN_1_AS = 4000;

                        }
                        else
                        {
                            datosOmegas.Board0x2E.PS_1_5_MN_1_AS = 0;

                        }

                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_1_SW_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PS_3_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_5_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_5_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_5_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_7_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_3_8_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_3_8_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_3_8_SW_2_DE.erase = false;

                    }


                    if (datosOmegas.Board0x2F._PE_2_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PE_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PE_2_SW_3_1_DE.erase = false;
                    }


                    if (datosOmegas.Board0x2F._PE_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PE_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PE_2_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_1_1_SW_3_1_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_1_1_SW_3_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x2F._PS_1_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_1_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x2F._PS_1_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x2F._PS_1_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x2F._PS_1_3_SW_2_DE.erase = false;
                    }




                    #endregion

                    #region Copilot_Side_Shelf

                    if (datosOmegas.Board0x30._CS_2_7_SW_2_DE.erase)
                    {
                        #region salidas_cs
                        ////DIGITALES SALIDA P&C FRONTAL

                        datosOmegas.Board0x30.CS_4_1_PHK_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_2_PHK_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_3_PHK_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_4_PHK_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_5_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_6_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_7_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_4_8_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();




                        datosOmegas.Board0x30.CS_3_5_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_3_6_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();
                        datosOmegas.Board0x30.CS_3_3_PH_2_DS = datosOmegas.Board0x30.CS_2_7_SW_2_DE();



                        if (datosOmegas.Board0x30._CS_2_7_SW_2_DE.Valor)
                        {
                            datosOmegas.Board0x2E.CS_1_5_MN_1_AS = 4000;
                            datosOmegas.Board0x2E.OH_9_1_MN_1_AS = 4000;
                        }
                        else
                        {
                            datosOmegas.Board0x2E.CS_1_5_MN_1_AS = 0;
                            datosOmegas.Board0x2E.OH_9_1_MN_1_AS = 0;
                        }

                        #endregion salidas_cs

                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_2_7_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_2_7_SW_2_DE.erase = false;
                    }

                    if (datosOmegas.Board0x30._CS_3_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_3_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_3_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_3_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_3_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_7_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_3_7_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_3_7_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_3_8_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_3_8_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_3_8_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_9_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_9_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_10_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_11_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_12_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_13_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_14_SW_2_DE.erase)
                    {
                        datosOmegas.Board0x30.CS_4_10_PHPL_2_BB_DS = datosOmegas.Board0x30.CS_4_14_SW_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_14_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_14_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_15_SW_2_DE.erase)
                    {
                        datosOmegas.Board0x30.CS_4_11_PHPL_2_BB_DS = datosOmegas.Board0x30.CS_4_15_SW_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_15_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_15_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_16_SW_2_DE.erase)
                    {
                        datosOmegas.Board0x30.CS_4_12_PHPL_2_BB_DS = datosOmegas.Board0x30.CS_4_16_SW_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_16_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_16_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_4_17_SW_2_DE.erase)
                    {
                        datosOmegas.Board0x30.CS_4_13_PHPL_2_BB_DS = datosOmegas.Board0x30.CS_4_17_SW_2_DE();
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_4_17_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_4_17_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_1_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_1_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_1_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_1_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x30._CS_1_3_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x30._CS_1_3_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x30._CS_1_3_SW_2_DE.erase = false;
                    }

                    #endregion

                    #region circuit br


                    if (datosOmegas.Board0x38._PB_1_1_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_1_CC_2_DS = datosOmegas.Board0x38.PB_1_1_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_1_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_1_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_2_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_2_CC_2_DS = datosOmegas.Board0x38.PB_1_2_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_2_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_2_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_3_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_3_CC_2_DS = datosOmegas.Board0x38.PB_1_3_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_3_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_3_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_4_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_4_CC_2_DS = datosOmegas.Board0x38.PB_1_4_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_4_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_4_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_5_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_5_CC_2_DS = datosOmegas.Board0x38.PB_1_5_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_5_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_5_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_6_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_6_CC_2_DS = datosOmegas.Board0x38.PB_1_6_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_6_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_6_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_7_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_7_CC_2_DS = datosOmegas.Board0x38.PB_1_7_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_7_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_7_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_8_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_8_CC_2_DS = datosOmegas.Board0x38.PB_1_8_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_8_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_8_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_9_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_9_CC_2_DS = datosOmegas.Board0x38.PB_1_9_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_9_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_9_CC_2_DE.erase = false;
                    }



                    if (datosOmegas.Board0x38._PB_1_10_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_10_CC_2_DS = datosOmegas.Board0x38.PB_1_10_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_10_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_10_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_11_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_11_CC_2_DS = datosOmegas.Board0x38.PB_1_11_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_11_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_11_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_12_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_12_CC_2_DS = datosOmegas.Board0x38.PB_1_12_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_12_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_12_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_13_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_13_CC_2_DS = datosOmegas.Board0x38.PB_1_13_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_13_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_13_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_14_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_14_CC_2_DS = datosOmegas.Board0x38.PB_1_14_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_14_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_14_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_15_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_15_CC_2_DS = datosOmegas.Board0x38.PB_1_15_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_15_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_15_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_16_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_16_CC_2_DS = datosOmegas.Board0x38.PB_1_16_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_16_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_16_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_17_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_17_CC_2_DS = datosOmegas.Board0x38.PB_1_17_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_17_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_17_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_18_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_18_CC_2_DS = datosOmegas.Board0x38.PB_1_18_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_18_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_18_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_19_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_19_CC_2_DS = datosOmegas.Board0x38.PB_1_19_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_19_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_19_CC_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x38._PB_1_20_CC_2_DE.erase)
                    {
                        datosOmegas.Board0x38.PB_1_20_CC_2_DS = datosOmegas.Board0x38.PB_1_20_CC_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x38._PB_1_20_CC_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x38._PB_1_20_CC_2_DE.erase = false;
                    }

                    #endregion




                    #endregion
                    #region Pedestal
                    if (datosOmegas.Board0x28._FC_2_1_SW_2_DE.erase)
                    {

                        datosOmegas.Board0x28.FC_2_6_PHK_2_DS = datosOmegas.Board0x28.FC_2_1_SW_2_DE();
                        datosOmegas.Board0x28.FC_2_6_PHK_2_2_DS = datosOmegas.Board0x28.FC_2_1_SW_2_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_1_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_1_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.erase)
                    {



                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_2_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_2_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_3_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_3_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_4_SW_3_2_DE.erase = false;
                    }


                    if (datosOmegas.Board0x28._FC_2_5_SW_2_DE.erase)
                    {


                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_5_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_5_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_2_6_PHK_2_DE.erase)
                    {


                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_2_6_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_2_6_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_1_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_1_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_1_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_1_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_1_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_1_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_1_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_2_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_2_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_2_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_2_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_2_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_2_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_2_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_3_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_3_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_3_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_3_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_3_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_3_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_3_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_4_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_4_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_4_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_4_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_4_4_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_4_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_4_4_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_1_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_1_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_1_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_1_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_1_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_1_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_1_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_2_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_2_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_2_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_2_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_2_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_2_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_2_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_3_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_3_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_3_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_3_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_3_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_3_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_3_L_4_3_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_4_L_4_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_4_L_4_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_4_L_4_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_4_L_4_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x28._FC_18_4_L_4_3_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_4_L_4_3_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x28._FC_18_4_L_4_3_DE.erase = false;
                    }
                    //if (datosOmegas.Board0x28._FC_4_1_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_1_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_4_1_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_4_1_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_4_2_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_2_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_4_2_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_4_2_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_4_3_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_3_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_4_3_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_4_3_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_4_4_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_4_4_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_4_4_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_4_4_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_18_1_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_1_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_18_1_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_18_1_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_18_2_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_2_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_18_2_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_18_2_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_18_3_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_3_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_18_3_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_18_3_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}
                    //if (datosOmegas.Board0x28._FC_18_4_L_4_AE.erase)
                    //{
                    //    string inst = mov.Getinstrumento(datosOmegas.Board0x28._FC_18_4_L_4_AE.Nombre);
                    //    if (inst != null)
                    //        if (dictInstrumentsRef.ContainsKey(inst))
                    //        {
                    //            dictInstrumentsRef[inst] = datosOmegas.Board0x28._FC_18_4_L_4_AE.ToString();
                    //        }
                    //    datosOmegas.Board0x28._FC_18_4_L_4_AE.erase = false;
                    //    MessageBox.Show(inst);
                    //}

                    if (datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.erase)
                    {

                        datosOmegas.Board0x29.FC_7_2_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_9_23_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_12_1_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_12_2_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_12_3_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_12_4_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_13_23_PHK_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_6_1_PHPL_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_6_2_PHPL_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_6_3_PHPL_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();
                        datosOmegas.Board0x29.FC_6_4_PHPL_2_DS = datosOmegas.Board0x29.FC_5_1_SW_3_1_DE();

                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_2_SW_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_2_SW_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_2_SW_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_3_SW_3_1_DE.erase = false;
                    }
                    var x1 = datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase;
                    if (datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase = false;
                    }
                    var x2 = datosOmegas.Board0x29._FC_5_3_SW_3_2_DE.erase;
                    if (datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_4_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_4_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_5_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_5_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_6_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_5_6_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_6_1_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_6_2_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_6_3_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_6_4_PHPL_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_7_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_7_1_SW_3_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_7_3_PH_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_7_3_PH_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_7_3_PH_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_9_23_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_9_23_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_9_23_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_1_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_12_1_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_12_1_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_2_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_12_2_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_12_2_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_3_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_12_3_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_12_3_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_12_4_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_12_4_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_12_4_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_13_23_PHK_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_13_23_PHK_2_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_13_23_PHK_2_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.Nombre);
                        setDictInstrument(inst);
                        datosOmegas.Board0x29._FC_17_1_SW_3_1_DE.erase = false;
                    }
                    if (datosOmegas.Board0x29._FC_17_1_SW_3_2_DE.erase)
                    {
                        string inst = mov.Getinstrumento(datosOmegas.Board0x29._FC_17_1_SW_3_2_DE.Nombre);
                        setDictInstrument(inst);
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
