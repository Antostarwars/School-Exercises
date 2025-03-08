using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Concurrent;

namespace WpfSocketServer
{
    public partial class MainWindow : Window
    {
        private Socket listener;
        private bool isRunning = false;
        private ConcurrentBag<Task> clientTasks = new ConcurrentBag<Task>();

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
                IPAddress ip = IPAddress.Parse("10.73.0.5");
                IPEndPoint localEndPoint = new IPEndPoint(ip, 11000);

                listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);

                UpdateUI("In attesa di connessioni...");

                while (isRunning)
                {
                    Socket handler = listener.Accept();
                    UpdateUI("Connessione riuscita!");

                    Task clientTask = Task.Run(() => HandleClient(handler));
                    clientTasks.Add(clientTask);
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

        private void HandleClient(Socket handler)
        {
            try
            {
                StringBuilder receivedData = new StringBuilder();
                byte[] buffer = new byte[1024];

                while (isRunning)
                {
                    int bytesReceived = handler.Receive(buffer);
                    if (bytesReceived == 0) break;

                    receivedData.Append(Encoding.ASCII.GetString(buffer, 0, bytesReceived));
                    string content = receivedData.ToString();

                    while (content.Contains("<EOF>"))
                    {
                        int eofIndex = content.IndexOf("<EOF>");
                        string message = content.Substring(0, eofIndex);
                        content = content.Substring(eofIndex + 5);
                        receivedData.Clear();
                        receivedData.Append(content);

                        UpdateUI($"Dati ricevuti: {message}");

                        string responseMessage = Dispatcher.Invoke(() => $"{messageTextBox.Text}<EOF>");
                        byte[] responseBytes = Encoding.ASCII.GetBytes(responseMessage);
                        handler.Send(responseBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateUI($"Errore client: {ex.Message}");
            }
            finally
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                handler.Dispose();
            }
        }

        private void StopServer()
        {
            try
            {
                listener?.Close();
                listener?.Dispose();

                foreach (var task in clientTasks)
                {
                    task.Wait(1000);
                }
                clientTasks.Clear();
            }
            catch (Exception ex)
            {
                UpdateUI($"Errore chiusura: {ex.Message}");
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