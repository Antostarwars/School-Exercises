using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;

namespace WPF_ClientSocketTCP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ip = IPAddress.Parse(IP.Text);
                IPEndPoint remoteEP = new IPEndPoint(ip, 11000);

                Socket Socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    Socket.Connect(remoteEP);

                    Console.WriteLine($"Socket connected to {Socket.RemoteEndPoint}");

                    byte[] msg = Encoding.ASCII.GetBytes($"{Messaggio.Text}<EOF>");

                    int bytesSent = Socket.Send(msg);

                    int bytesRec = Socket.Receive(bytes);
                    risposta.Content = $"Risposta del Server: {Encoding.ASCII.GetString(bytes, 0, bytesRec)}";

                    Socket.Shutdown(SocketShutdown.Both);
                    Socket.Close();
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