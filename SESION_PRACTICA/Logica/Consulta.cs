using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SESION_PRACTICA.Datos;
using SESION_PRACTICA.Modelos;

namespace SESION_PRACTICA.Logica
{
    public class Consulta
    {
        KIRVIT_AppContext DB;
        ListadoInstrumentos InstrumentosActuales;
        ListadoEtiquetas EtiquetasActuales;
        public Consulta() {
            DB = new KIRVIT_AppContext();

        }

        public void ObtenerInstrumentos()
        {
            var Senales = new List<string>();
            var Instrumentos = new List<string>();
            var InstrumentosEnDBConSenales = from q in DB.Instrumento
                                   //join s in DB.SenalElectronica on q.Oid equals s.Instrumento
                                   //where q.Oid.Equals(s.Instrumento)
                                   select new { q,s};



            var InstrumetosENDBConSenalesALista = InstrumentosEnDBConSenales.ToList();
            var InstAgrupados = InstrumetosENDBConSenalesALista.GroupBy(o => o.q.NombreInstrumento);



            foreach (var item in InstAgrupados)
            {
                var Nombre = item.Key.ToString();
                var Id = item.Select(o => o.q.Oid.ToString());

                foreach (var grupo in item)
                {
                    Senales.Add(grupo.s.Id.ToString());
                }                            
                
                Console.WriteLine("Consulta Realizada nombre:" + Nombre.ToString() + "Id: " + Id.ToString());
            
            }
               
        }





    }
}
