using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        ListadoEtiquetas EtiquetasActuales;
        public Consulta()
        {
            DB = new KIRVIT_AppContext();
            SenalesActuales = new ListadoSenales();
            InstrumentosActuales = new ListadoInstrumentos();
            EtiquetasActuales = new ListadoEtiquetas();
            ConsultaInicial();
        }

        private void ConsultaInicial()
        {
            var Senales = new List<string>();

            var SenalesEnDB = from s in DB.SenalElectronica
                              select s;

            var InstrumentosEnDB = from q in DB.Instrumento
                                   select q;

            var EtiquetasEnDB = from e in DB.Etiqueta
                                select e;

            var LabelSignalsDB = from l in DB.LabelSignalsEtiquetas
                                 select l;

            var Lista_Instrumentos = InstrumentosEnDB.ToList();
            var Lista_Senales = SenalesEnDB.ToList();
            var Lista_Etiquetas = EtiquetasEnDB.ToList();
            var Lista_LabelSignals = LabelSignalsDB.ToList();

            var SenalesAgrupadas = Lista_Senales.GroupBy(g => g.Instrumento).ToList();
            var LabelOrdenados = Lista_LabelSignals.OrderBy(o => o.SenalElectronica).ToList();
            var LabelAgrupados = LabelOrdenados.GroupBy(g => g.Etiquetas).ToList();

            SenalesActuales = ObtenerSenales(SenalesAgrupadas);
            InstrumentosActuales = ObtenerInstrumentos(SenalesAgrupadas, Lista_Instrumentos, SenalesActuales);
            EtiquetasActuales = ObtenerEtiquetas(LabelAgrupados, InstrumentosActuales, Lista_Etiquetas);
        }
        public ListadoSenales getListadoSenales()
        {
            return SenalesActuales;
        }

        public ListadoInstrumentos getInstrumentos()
        {
            return InstrumentosActuales;

        }

        public ListadoEtiquetas getEtiquetas()
        {
            return EtiquetasActuales;
        }

        private ListadoSenales ObtenerSenales(List<IGrouping<int?, SenalElectronica>> SenalesAgrupadas)
        {
            foreach (var item in SenalesAgrupadas)
            {

                var Id_Senales_Asociadas = item.Select(x => x.Id).ToArray(); //Listado Senales Asociadas ID_Electronica
                var Nombre_SenaleS_Asociadas = item.Select(x => x.Nombre).ToArray();//Listado Nombres Senales Asociadas
                var Tipo_Senales = item.Select(x => x.Io.ToString()).ToArray();
                for (int i = 0; i < Id_Senales_Asociadas.Length; i++)
                {
                    Mod_Senales Senal = new Mod_Senales(Id_Senales_Asociadas[i], Nombre_SenaleS_Asociadas[i], false, Tipo_Senales[i]);
                    SenalesActuales.Add(Senal);
                }
            }
            return SenalesActuales;

        }

        private ListadoInstrumentos ObtenerInstrumentos(List<IGrouping<int?, SenalElectronica>> SenalesAgrupadas, List<Instrumento> Instrumentos, ListadoSenales SenalesActuales)
        {

            foreach (var item in Instrumentos)
            {
                if (SenalesAgrupadas.Find(x => x.Key == item.Oid) != null)
                {
                    var SenalesXInstrumento = SenalesAgrupadas.FirstOrDefault(o => o.Key.Equals(item.Oid)).Select(x => x.Id).ToArray();

                    var NombreInstrumento = item.NombreInstrumento;
                    var IdInstrumento = item.Oid;
                    Mod_Senales[] Senales = new Mod_Senales[SenalesXInstrumento.Length];
                    for (int i = 0; i < SenalesXInstrumento.Length; i++)
                    {
                      

                        if (SenalesXInstrumento[i].Equals(SenalesActuales.FirstOrDefault(o => o.IDProtocolo.Equals(SenalesXInstrumento[i])).IDProtocolo))
                        {
                            Senales[i] = SenalesActuales.FirstOrDefault(o => o.IDProtocolo.Equals(SenalesXInstrumento[i]));
                        }
                    }
                    Mod_Instrumento InstrumentoDummy = new Mod_Instrumento(IdInstrumento, NombreInstrumento, Senales);
                    InstrumentosActuales.Add(InstrumentoDummy);
                }
                else {
                    var NombreInstrumento = item.NombreInstrumento;
                    var IdInstrumento = item.Oid;
                    Mod_Senales[] Senales = new Mod_Senales[0];
                    Mod_Instrumento InstrumentoDummy = new Mod_Instrumento(IdInstrumento, NombreInstrumento, Senales);
                    InstrumentosActuales.Add(InstrumentoDummy);

                }

            }
            return InstrumentosActuales;

        }

        private ListadoEtiquetas ObtenerEtiquetas(List<IGrouping<int?, LabelSignalsEtiquetas>> LabelAgrupados, ListadoInstrumentos Instrumentos, List<Etiqueta> Etiquetas)
        {
            foreach (var item in LabelAgrupados)
            {
                var ValorEtiquetasAsociadas= item.Select(x => x.Valor).ToArray();
                var IdEtiqueta = item.Key;
                var NombreEtiqueta = Etiquetas.FirstOrDefault(x=>x.Oid.Equals(item.Key)).Nombre;
                var InstrumentoAsociado = Instrumentos.FirstOrDefault(y=> Etiquetas.FirstOrDefault(x=>x.Oid.Equals(item.Key)).Instrumento.Equals(y.ID));
                Mod_Etiqueta _Etiquetas = new Mod_Etiqueta(IdEtiqueta, NombreEtiqueta, ValorEtiquetasAsociadas, InstrumentoAsociado);
                EtiquetasActuales.Add(_Etiquetas);
            }
                    
            

            return EtiquetasActuales;
        }

    }
}
