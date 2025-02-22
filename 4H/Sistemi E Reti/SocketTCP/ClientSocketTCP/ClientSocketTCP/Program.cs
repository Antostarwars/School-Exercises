using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientSocketTCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartClient();
        }

        public static void StartClient()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ip = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ip, 11000);

                Socket sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine($"Socket connected to {sender.RemoteEndPoint}");

                    byte[] msg = Encoding.ASCII.GetBytes("CIAO CIAO <EOF>");

                    int bytesSent = sender.Send(msg);

                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine($"Echoed test = {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
