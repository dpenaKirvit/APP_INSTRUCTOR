using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Electronica.Componentes;
using System.Reflection;
using SESION_PRACTICA.Datos;

namespace SESION_PRACTICA.Logica
{
    public class SenalAEtiqueta : IDisposable, INotifyPropertyChanged
    {
        private readonly KIRVIT_AppContext _context;
        public Instrumental instrumento { get; set; }
        private ProcesoOmegas datosOmegasRef;

        private string _instrumentName;
        VarBoard0x21 fucnt21;
        VarBoard0x22 fucnt22;
        VarBoard0x23 fucnt23;
        VarBoard0x24 fucnt24;
        VarBoard0x25 fucnt25;
        VarBoard0x26 fucnt26;
        VarBoard0x27 fucnt27;
        VarBoard0x2E fucnt2E;
        VarBoard0x2F fucnt2F;
        VarBoard0x30 fucnt30;
        VarBoard0x38 fucnt38;
        VarBoard0x28 fucnt28;
        VarBoard0x29 fucnt29;

        public string instrumentName
        {
            get { return _instrumentName; }
            set { _instrumentName = value; NotifyPropertyChanged("instrumentName"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public SenalAEtiqueta(ProcesoOmegas datosOmegas)
        {
            _context = new KIRVIT_AppContext();
            datosOmegasRef = datosOmegas;
            fucnt21 = datosOmegasRef.Board0x21;
            fucnt22 = datosOmegasRef.Board0x22;
            fucnt23 = datosOmegasRef.Board0x23;
            fucnt24 = datosOmegasRef.Board0x24;
            fucnt25 = datosOmegasRef.Board0x25;
            fucnt26 = datosOmegasRef.Board0x26;
            fucnt27 = datosOmegasRef.Board0x27;
            fucnt2E = datosOmegasRef.Board0x2E;
            fucnt2F = datosOmegasRef.Board0x2F;
            fucnt30 = datosOmegasRef.Board0x30;
            fucnt38 = datosOmegasRef.Board0x38;
            fucnt28 = datosOmegasRef.Board0x28;
            fucnt29 = datosOmegasRef.Board0x29;
        }

        public string Getinstrumento(string Identification)
        {
            //var instrumentoId = _context.Signals.FirstOrDefault(n => n.SignalsId == Identification).InstrumentosId;
            //var instrumento = _context.Instrumentos.FirstOrDefault(n => n.IdInstrumentos == instrumentoId).InstrumentosId;
            return "CAMBIAR";

        }

        public string instrumentoDigital(string InstrumentoId)
        {

            // Etiquetas etiqueta = null; OJO REVISAR
            string Etiqueta = null;
            KIRVIT_AppContext db = new KIRVIT_AppContext();

            /*
                int IdInstrumento = db.Instrumentos.FirstOrDefault(n => n.InstrumentosId == InstrumentoId).IdInstrumentos; OJO REVISAR
                int boardsign = db.Signals.FirstOrDefault(n => n.InstrumentosId == IdInstrumento).Board;
            */


            /*
            IQueryable<Etiquetas> labels = from e in db.Etiquetas
                                           where e.InstrumentosId == IdInstrumento
                                            select e;*/

            /*
            if (labels == null)
                return null;
            */

            /*
            foreach (var label in labels)
            {
                
                IQueryable<LabelSignals> labelsigns = from s in _context.LabelSignals
                                                      where s.EtiquetasId == label.IdEtiquetas
                                                      select s;

                bool check = true;
                foreach (LabelSignals labelsign in labelsigns)
                {
                    Type type;
                    MethodInfo method;
                    bool result;
                    var checkEndChar_Input = db.Signals.FirstOrDefault(s => s.IdSignals == labelsign.SignalsId).SignalsId.ToString().EndsWith("E");
                    var checkEndChar_Output = db.Signals.FirstOrDefault(s => s.IdSignals == labelsign.SignalsId).SignalsId.ToString().EndsWith("S");
                    var check_Analog = db.Signals.FirstOrDefault(s => s.IdSignals == labelsign.SignalsId).SignalsId.ToString().EndsWith("AE");
                    var SignalName = db.Signals.FirstOrDefault(s => s.IdSignals == labelsign.SignalsId).SignalsId.ToString();
                   


                    if (checkEndChar_Input && (!check_Analog))
                    {
                        switch (boardsign)
                        {
                            case 33:
                                type = typeof(VarBoard0x21);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt21, null);
                                break;
                            case 34:
                                type = typeof(VarBoard0x22);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt22, null);
                                break;
                            case 35:
                                type = typeof(VarBoard0x23);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt23, null);
                                break;
                            case 36:
                                type = typeof(VarBoard0x24);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt24, null);
                                break;
                            case 37:
                                type = typeof(VarBoard0x25);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt25, null);
                                break;
                            case 38:
                                type = typeof(VarBoard0x26);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt26, null);
                                break;
                            case 46:
                                type = typeof(VarBoard0x2E);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt2E, null);
                                break;
                            case 47:
                                type = typeof(VarBoard0x2F);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt2F, null);
                                break;
                            case 48:
                                type = typeof(VarBoard0x30);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt30, null);
                                break;
                            case 56:
                                type = typeof(VarBoard0x38);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt38, null);
                                break;
                            case 40:
                                type = typeof(VarBoard0x28);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt28, null);
                                break;
                            case 41:
                                type = typeof(VarBoard0x29);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt29, null);
                                break;
                            default:
                                type = typeof(VarBoard0x27);
                                method = type.GetMethod(SignalName);
                                result = (bool)method.Invoke(fucnt27, null);
                                break;
                        }
                        bool comp = labelsign.Valor != 0 ? true : false;
                        if (comp != result)
                        {
                            check = false;
                            break;
                        }
                    }
                    else
                    {
                        check = false;
                        if (check_Analog)
                        {
                            check = true;
                        }

                    }

                }
                if (check == true)
                {
                    Etiqueta = label.Nombre;
                    break;
                }
            }*/
            return Etiqueta;

        }

    }
    public class Instrumental
    {
        public string Instrumento { get; set; }
        public List<string> Signals { get; set; }
        public string Grupo { get; set; }
        public string board;
    }
}
