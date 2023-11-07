using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Net.Configuration;

namespace Server
{
    internal class Server_Chat
    {
        private TcpListener server;
        private TcpClient client = new TcpClient();
        private IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 8000);
        private List<Connection> list = new List<Connection>();
        private Semaphore connectionSemaphore; // Semaphore para controlar conexiones simultáneas

        Connection con;

        private struct Connection
        {
            public NetworkStream stream;    // Flujo de red para comunicarse con el cliente
            public StreamWriter streamw;     // Escritor para enviar datos al cliente
            public StreamReader streamr;     // Lector para recibir datos del cliente
            public string userName;          // Nombre de usuario del cliente
        }

        public Server_Chat()
        {
            connectionSemaphore = new Semaphore(3, 3); // Permitir hasta 3 conexiones simultáneas
            Init();
        }

        public void Init()
        {
            Console.WriteLine("Server is running!");

            // Inicializa el servidor y lo pone a la escucha en el puerto 8000
            server = new TcpListener(ipendpoint);
            server.Start();

            while (true)
            {
                // Espera a que haya un espacio disponible en el Semaphore
                connectionSemaphore.WaitOne();

                // Espera y acepta una conexión entrante
                client = server.AcceptTcpClient();
                con = new Connection();

                // Obtiene los flujos de red para comunicarse con el cliente
                con.stream = client.GetStream();
                con.streamr = new StreamReader(con.stream);
                con.streamw = new StreamWriter(con.stream);

                // Lee el nombre de usuario del cliente
                con.userName = con.streamr.ReadLine();

                // Agrega la conexión a la lista de conexiones activas
                list.Add(con);
                Console.WriteLine(con.userName + " is connected");

                // Inicia un hilo para escuchar la conversación del cliente
                Thread t = new Thread(Listen_connection);
                t.Start();
            }
        }

        void Listen_connection()
        {
            Connection hcon = con;

            do
            {
                try
                {
                    // Lee el mensaje del cliente
                    string tmp = hcon.streamr.ReadLine();
                    Console.WriteLine(hcon.userName + ": " + tmp);

                    // Reenvía el mensaje a todos los otros clientes conectados
                    foreach (Connection c in list)
                    {
                        try
                        {
                            // Escribe el mensaje en el flujo de cada cliente conectado
                            c.streamw.WriteLine(hcon.userName + ": " + tmp);
                            c.streamw.Flush();
                        }
                        catch { }
                    }
                }
                catch
                {
                    // Si la conexión se rompe (el usuario se desconecta), elimina al cliente de la lista
                    list.Remove(hcon);
                    Console.WriteLine(hcon.userName + " is disconnected");

                    // Libera un espacio en el Semaphore
                    connectionSemaphore.Release();
                    break;
                }
            } while (true);
        }
    }
}

