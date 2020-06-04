using System;
using System.Collections.Generic;
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
		Dictionary<string, string> dictInstruments;

		public MainWindow()
        {
			ConsultaInicial = new Consulta();
			SenalesActuales = ConsultaInicial.getListadoSenales(); //Listado de todos los instrumentos
			Console.WriteLine("Consulta 1");
			InstrumentosActuales = ConsultaInicial.getInstrumentos();//Listado de todas las etiquetas
			Console.WriteLine("Consulta 2");
			EtiquetasActuales = ConsultaInicial.getEtiquetas();
			Console.WriteLine("Consulta 3"); 

			InitializeComponent();
			
		}

        private void B_Conectar_Click(object sender, RoutedEventArgs e)
        {
            Driver_C130 = new DriverElectronica();
			Driver_C130.DetectarDispositivos();
            Driver_C130.Iniciar(InstrumentosActuales,EtiquetasActuales,SenalesActuales);
        }
    }
}
