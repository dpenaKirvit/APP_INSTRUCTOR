using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ComunicacionServidorEIDS
{
    public class ServidorSocket
    {
        
        private static int myPort = 8000;
        static Socket serverSocket;
        public Socket SocketServidor {
            get { return serverSocket; }
            set { serverSocket = value; }
        
        }

        public ServidorSocket() {

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myPort));
            serverSocket.Listen(10);
            Console.WriteLine("Start monitoring{0}success", serverSocket.LocalEndPoint.ToString());
        }

       


    }
}
