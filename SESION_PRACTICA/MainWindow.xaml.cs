using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SESION_PRACTICA.Logica;
using SESION_PRACTICA.Modelos;

namespace SESION_PRACTICA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DriverElectronica Driver_C130;
		Consulta ConsultaInicial;
		ListadoSenales SenalesActuales;
		ListadoInstrumentos InstrumentosActuales;
		ListadoEtiquetas EtiquetasActuales;
        
		

		public MainWindow()
        {
			ConsultaInicial = new Consulta();
			SenalesActuales = ConsultaInicial.getListadoSenales(); //Listado de todos los instrumentos
			InstrumentosActuales = ConsultaInicial.getInstrumentos();//Listado de todas las etiquetas
			EtiquetasActuales = ConsultaInicial.getEtiquetas();
            Console.WriteLine("Consulta realizada");
            InitializeComponent();
			
		}

        private void B_Conectar_Click(object sender, RoutedEventArgs e)
        {
            Driver_C130 = new DriverElectronica();
			Driver_C130.DetectarDispositivos();
            Driver_C130.Iniciar(InstrumentosActuales,EtiquetasActuales);
            if (Driver_C130.EstaOmegas)
            {
                Panel_prueba.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("La electrónica no se encuentra");
                Driver_C130.Cerrar();
                this.Close();
            }
        }

        private void B_Instrumento_OVH1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("OH_1_1_SW_2_SM_SC_1");
            Console.WriteLine("OH_1_1_SW_2_SM_SC_1");            
        }

        private void B_Instrumento_OVH2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("OH_10_2_SW_3_S_SC");
            Console.WriteLine("OH_10_2_SW_3_S_SC");
        }

        private void B_Instrumento_OVH3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("OH_12_5_PL_2_S_35");
            Console.WriteLine("OH_12_5_PL_2_S_35");
        }

        private void B_Instrumento_OVH4_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("OH_11_32_RS_2_S_34");
            Console.WriteLine("OH_11_32_RS_2_S_34");

        }

        private void B_Instrumento_frontal1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("CI_3_1_PHK_2_M_A_24");
            Driver_C130.GetEtiquetaActual_Out("CI_3_1_PHK_2_M_A_24");
            Driver_C130.GetEtiquetaActual_Out("EI_3_1_PHK_2_M_A_25");
            Console.WriteLine("CI_3_1_PHK_2_M_A_24");
        }

        private void B_Instrumento_frontal2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("EI_3_1_PHK_2_M_A_25");
            Driver_C130.GetEtiquetaActual_Out("EI_3_1_PHK_2_M_A_25");
            Driver_C130.NuevaReaccion("EI_3_1_PHK_2_M_A_25", "ON", 0, 0, 0, 0, false);
            
           
            //Driver_C130.EscribirInstrumento("CS_4_1_PHK_2_M_A_25", "ON", 0, 0, 0, 0, true);
            Console.WriteLine("EI_3_1_PHK_2_M_A_25");
        }

        private void B_Instrumento_frontal3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("CS_4_1_PHK_2_M_A_25");
            Driver_C130.GetEtiquetaActual_Out("CS_4_1_PHK_2_M_A_25");
            Console.WriteLine("CS_4_1_PHK_2_M_A_25");
            Driver_C130.NuevaReaccion("EI_3_1_PHK_2_M_A_25", "ON", 0, 0, 2, 0, false);
            Driver_C130.NuevaReaccion("OH_10_29_MN_1_79", "", 100, (float)51.3, 3, 0, true);
            Driver_C130.NuevaReaccion("OH_10_43_MN_1_81", "", 100, (float)20, 0, 0, true);
            Driver_C130.NuevaReaccion("OH_7_1_MN_2_75", "", 100, (float)20, 0, 0, true);
        }

        private void B_Instrumento_frontal4_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("CS_4_8_PH_2_M_G_19");
            Driver_C130.GetEtiquetaActual_Out("CS_4_8_PH_2_M_G_19");
            Console.WriteLine("CS_4_8_PH_2_M_G_19");
        }

        private void B_Instrumento_Pedestal1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("FC_2_6_PHK_2_M_G_25");
            Driver_C130.GetEtiquetaActual_Out("FC_2_6_PHK_2_M_G_25");
            Driver_C130.GetValorInstrumentoAnalogo("OH_6gh_17_PT_1_15");
            Console.WriteLine("FC_2_6_PHK_2_M_G_25");
        }

        private void B_Instrumento_Pedestal2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("FC_18_1_L_4_61");
            Driver_C130.GetEtiquetaActual_Out("FC_18_1_L_4_61");
            Console.WriteLine("FC_18_1_L_4_61");
        }

        private void B_Instrumento_Pedestal3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("FC_6_1_PHPL_2_S_46");
            Driver_C130.GetEtiquetaActual_Out("FC_6_1_PHPL_2_S_46");
            Console.WriteLine("FC_6_1_PHPL_2_S_46");
        }

        private void B_Instrumento_Pedestal4_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("FC_6_2_PHPL_2_S_46");
            Driver_C130.GetEtiquetaActual_Out("FC_6_2_PHPL_2_S_46");
            Console.WriteLine("FC_6_2_PHPL_2_S_46");
        }

        private void B_Instrumento_CB1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("PB_1_1_CC_2");
            Driver_C130.GetEtiquetaActual_Out("PB_1_1_CC_2");
            Console.WriteLine("PB_1_1_CC_2");
        }

        private void B_Instrumento_CB2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("PB_1_5_CC_2");
            Driver_C130.GetEtiquetaActual_Out("PB_1_5_CC_2");
            Console.WriteLine("PB_1_5_CC_2");
        }

        private void B_Instrumento_CB3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual_In("PB_1_20_CC_2");
            Driver_C130.GetEtiquetaActual_Out("PB_1_20_CC_2");
            Console.WriteLine("PB_1_20_CC_2");
        }
    }
}
