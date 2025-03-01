using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfSocketServer
{
    public partial class MainWindow : Window
    {
        private Socket listener;
        private bool isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ToggleServer_Click(object sender, RoutedEventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                toggleButton.Content = "Ferma Server";
                await Task.Run(() => StartServer());
            }
            else
            {
                StopServer();
                toggleButton.Content = "Avvia Server";
                isRunning = false;
            }
        }

        private void StartServer()
        {
            try
            {
                IPAddress ip = IPAddress.Parse("10.73.0.24");
                IPEndPoint localEndPoint = new IPEndPoint(ip, 11000);

                listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);

                UpdateUI("In attesa di connessioni...");

                using (Socket handler = listener.Accept())
                {
                    UpdateUI("Connessione riuscita!");

                    // Ricezione dati
                    string data = "";
                    byte[] buffer = new byte[1024];

                    while (true)
                    {
                        int received = handler.Receive(buffer);
                        data += Encoding.ASCII.GetString(buffer, 0, received);
                        if (data.IndexOf("<EOF>") > -1) break;
                    }

                    UpdateUI($"Dati ricevuti: {data.Replace("<EOF>", "")}");

                    // Invio risposta personalizzata
                    string responseMessage = Dispatcher.Invoke(() => $"{messageTextBox.Text}<EOF>");
                    byte[] msg = Encoding.ASCII.GetBytes(responseMessage);
                    handler.Send(msg);

                    handler.Shutdown(SocketShutdown.Both);
                }
            }
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.Interrupted)
            {
                UpdateUI("Server fermato");
            }
            catch (Exception ex)
            {
                UpdateUI($"Errore: {ex.Message}");
            }
            finally
            {
                StopServer();
            }
        }

        private void StopServer()
        {
            try
            {
                listener?.Close();
                listener?.Dispose();
            }
            catch (Exception ex)
            {
                UpdateUI($"Errore durante la chiusura: {ex.Message}");
            }
        }

        private void UpdateUI(string message)
        {
            Dispatcher.Invoke(() =>
            {
                statusLabel.Content = message;
            });
        }
    }
}