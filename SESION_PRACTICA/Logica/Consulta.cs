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
            var InstrumentosEnDB = from q in DB.Instrumento
                                   join r in DB.Etiqueta on q.Oid equals r.Instrumento
                                   join s in DB.LabelSignalsEtiquetas on r.Oid equals s.Etiquetas
                                   orderby q.Oid
                                   select new
                                   {
                                       q.NombreInstrumento,
                                       q.Oid,
                                       s.SenalElectronica,
                                       s.Valor            
                                   };
                                         

            foreach (var item in InstrumentosEnDB) 
            {
                var Nombre = item.NombreInstrumento;
                var Id = item.Oid;
                var Senales = item.SenalElectronica;
                var Valores = item.Valor;
                Console.WriteLine("Consulta Realizada");
            
            }
               
        }





    }
}
