using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronica.Componentes
{
    public enum TipoTrama
    {
        SolicitudEstado = 0x20,
        CambioVariables = 0x21,
        EnvioVariables = 0x22
    }

    public enum TipoByte
    {
        STX = 0x02,
        ETX = 0x03,
    }

    public enum ValorBooleano
    {
        Verdadero = 0x21,
        Falso = 0x20
    }

    public enum CodigoBoard
    {
        Board0x21 = 0x21,
        Board0x22 = 0x22,
        Board0x23 = 0x23,
        Board0x24 = 0x24,
        Board0x25 = 0x25,
        Board0x26 = 0x26,
        Board0x27 = 0x27,
        Board0x28 = 0x28,
        Board0x29 = 0x29,
        Board0x2A = 0x2A,
        Board0x2B = 0x2B,
        Board0x2C = 0x2C,
        Board0x2D = 0x2D,
        Board0x2E = 0x2E,
        Board0x2F = 0x2F,
        Board0x30 = 0x30,
        Board0x31 = 0x31,
        Board0x32 = 0x32,
        Board0x33 = 0x33,
        Board0x34 = 0x34,
        Board0x35 = 0x35,
        Board0x36 = 0x36,
        Board0x37 = 0x37,
        Board0x38 = 0x38,
    }
}
