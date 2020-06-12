using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionServidorEIDS
{
    class ClienteSocket
    {
        public void IniciarComunicacion()
        {
            byte[] bytesRecibidos = new byte[1024];
            try
            {
                IPHostEntry Servidor = Dns.GetHostEntry("localhost");
                IPAddress DirecionIp = Servidor.AddressList[0];
                IPEndPoint puntoRemoto = new IPEndPoint(DirecionIp, 11000);

                Socket sender = new Socket(DirecionIp.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(puntoRemoto);
                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
            }
            catch { }
        }
    }
}
