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
			Stopwatch timer = new Stopwatch();
			timer.Start();
			ConsultaInicial = new Consulta();
			SenalesActuales = ConsultaInicial.getListadoSenales(); //Listado de todos los instrumentos
			Console.WriteLine("Consulta 1");
			InstrumentosActuales = ConsultaInicial.getInstrumentos();//Listado de todas las etiquetas
			Console.WriteLine("Consulta 2");
			EtiquetasActuales = ConsultaInicial.getEtiquetas();
			Console.WriteLine("Consulta 3");
			timer.Stop();
			Console.WriteLine("Elapsed time: " + timer.ElapsedMilliseconds.ToString());
			InitializeComponent();
			
		}

        private void B_Conectar_Click(object sender, RoutedEventArgs e)
        {
            Driver_C130 = new DriverElectronica();
			Driver_C130.DetectarDispositivos();
            Driver_C130.Iniciar(InstrumentosActuales,EtiquetasActuales);
            Panel_prueba.Visibility = Visibility.Visible;
        }

        private void B_Instrumento_OVH1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(501);
        }

        private void B_Instrumento_OVH2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(400);
        }

        private void B_Instrumento_OVH3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(402);
        }

        private void B_Instrumento_OVH4_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(409);
        }

        private void B_Instrumento_frontal1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(29);
        }

        private void B_Instrumento_frontal2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(61);
        }

        private void B_Instrumento_frontal3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(62);
        }

        private void B_Instrumento_frontal4_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(672);
        }

        private void B_Instrumento_Pedestal1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(334);
        }

        private void B_Instrumento_Pedestal2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(267);
        }

        private void B_Instrumento_Pedestal3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(268);
        }

        private void B_Instrumento_Pedestal4_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(269);
        }

        private void B_Instrumento_CB1_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(681);
        }

        private void B_Instrumento_CB2_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(685);
        }

        private void B_Instrumento_CB3_click(object sender, RoutedEventArgs e)
        {
            Driver_C130.GetEtiquetaActual(686);
        }
    }
}
