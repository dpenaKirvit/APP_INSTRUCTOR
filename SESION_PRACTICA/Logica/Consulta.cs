using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using SESION_PRACTICA.Datos;
using SESION_PRACTICA.Modelos;

namespace SESION_PRACTICA.Logica
{
    public class Consulta
    {
        KIRVIT_AppContext DB;
        ListadoInstrumentos InstrumentosActuales;
        ListadoSenales SenalesActuales;
        public Consulta()
        {
            DB = new KIRVIT_AppContext();
            SenalesActuales = new ListadoSenales();
            InstrumentosActuales = new ListadoInstrumentos();
            ConsultaInicial();
        }

        private void ConsultaInicial()
        {
            var Senales = new List<string>();

            var SenalesEnDB = from s in DB.SenalElectronica
                              select s;

            var InstrumentosEnDB = from q in DB.Instrumento
                                   select q;
            var Lista_Instrumentos = InstrumentosEnDB.ToList();
            var Lista_Senales = SenalesEnDB.ToList();

            var SenalesAgrupadas = Lista_Senales.GroupBy(g => g.Instrumento).ToList();

            SenalesActuales = ObtenerSenales(SenalesAgrupadas);
            InstrumentosActuales = ObtenerInstrumentos(SenalesAgrupadas, Lista_Instrumentos, SenalesActuales);
        }
        public ListadoSenales getListadoSenales()
        {
            return SenalesActuales;
        }

        public ListadoInstrumentos getInstrumentos()
        {
            return InstrumentosActuales;

        }

        private ListadoSenales ObtenerSenales(List<IGrouping<int?, SenalElectronica>> SenalesAgrupadas)
        {
            foreach (var item in SenalesAgrupadas)
            {

                var Id_Senales_Asociadas = item.Select(x => x.Id).ToArray(); //Listado Senales Asociadas ID_Electronica
                var Nombre_SenaleS_Asociadas = item.Select(x => x.Nombre).ToArray();//Listado Nombres Senales Asociadas
                for (int i = 0; i < Id_Senales_Asociadas.Length; i++)
                {
                    Mod_Senales Senal = new Mod_Senales(Id_Senales_Asociadas[i], Nombre_SenaleS_Asociadas[i], "0");
                    SenalesActuales.Add(Senal);
                }
            }
            return SenalesActuales;

        }

        private ListadoInstrumentos ObtenerInstrumentos(List<IGrouping<int?, SenalElectronica>> SenalesAgrupadas, List<Instrumento> Instrumentos, ListadoSenales SenalesActuales)
        {

            foreach (var item in Instrumentos)
            {
                
                var SenalesXInstrumento = SenalesAgrupadas.FirstOrDefault(o => o.Key.Equals(item.Oid)).Select(x => x.Id).ToArray();
                var NombreInstrumento = item.NombreInstrumento;
                var IdInstrumento = item.Oid;
                Mod_Senales[] Senales = new Mod_Senales[SenalesXInstrumento.Length];
                for (int i = 0; i < SenalesXInstrumento.Length; i++)
                {

                    if (SenalesXInstrumento[i].Equals(SenalesActuales.Select(o => o.IDProtocolo)))
                    {
                        Senales[i] = SenalesActuales.FirstOrDefault(o => o.IDProtocolo.Equals(SenalesXInstrumento[i]));
                    }
                }
                Mod_Instrumento InstrumentoDummy = new Mod_Instrumento(IdInstrumento, NombreInstrumento, Senales);
                InstrumentosActuales.Add(InstrumentoDummy);

            }
            return InstrumentosActuales;





        }
    }
}
