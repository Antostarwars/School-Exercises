using System.Net;
using System.Net.Sockets;
using System.Text;


namespace SocketTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            StartServer();
        }

        public static void StartServer()
        {
            IPHostEntry host = Dns.GetHostEntry("10.73.0.24");

            IPAddress ip = IPAddress.Parse("10.73.0.24"); //host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ip, 11000);

            try
            {
                Socket listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(localEndPoint);

                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");

                Socket handler = listener.Accept();

                string data = null;

                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1) break;
                }

                Console.WriteLine($"Text received: {data}");

                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);

                handler.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
