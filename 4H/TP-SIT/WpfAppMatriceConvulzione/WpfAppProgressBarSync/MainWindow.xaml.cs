using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppProgressBarSync
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartProgressBarSync01(int tempo)
        {
            txtSync01.Text = "Inizio Progress Bar";
            ProgressBar01.Minimum = 0;
            ProgressBar01.Maximum = tempo;
            for (int i = 0; i < tempo; i++)
            {
                ProgressBar01.Value = i;
                Thread.Sleep(1);
            }

            txtSync01.Text = "Fine Progress Bar";
        }

        private void StartProgressBarSync02(int tempo)
        {
            txtSync02.Text = "Inizio Progress Bar";
            ProgressBar02.Minimum = 0;
            ProgressBar02.Maximum = tempo;
            for (int i = 0; i <= tempo; i++)
            {
                ProgressBar02.Value = i;
                Thread.Sleep(1);
            }

            txtSync02.Text = "Fine Progress Bar";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartProgressBarSync01(2000);
            StartProgressBarSync02(2000);
        }
    }
}
