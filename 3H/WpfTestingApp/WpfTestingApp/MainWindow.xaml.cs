using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestingApp
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

        private void btnCalcolaPerimetro_Click(object sender, RoutedEventArgs e)
        {
            double lato1;
            if (!double.TryParse(txtLato1.Text, out lato1))
            {
                MessageBox.Show("Lato 1 non valido","Errore", MessageBoxButton.OK ,MessageBoxImage.Error);
                return;
            }

            double lato2;
            if (!double.TryParse(txtLato2.Text, out lato2))
            {
                MessageBox.Show("Lato 2 non valido", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double risultato = lato1 * 2 + lato2 * 2;
            txtRisultato.Content = $"Perimeter is {risultato}";
            txtLato1.IsEnabled = false;
            txtLato2.IsEnabled = false;
            imgEmoji.Visibility = Visibility.Visible;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtRisultato.Content = "";
            txtLato1.IsEnabled = true;
            txtLato2.IsEnabled = true;
            imgEmoji.Visibility = Visibility.Hidden;
        }
    }
}
