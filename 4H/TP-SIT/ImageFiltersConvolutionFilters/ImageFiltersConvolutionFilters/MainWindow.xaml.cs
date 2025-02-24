using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;

/*
 * Antonio De Rosa 4H - Immagine con filtro a Convoluzioni.
 * Filtro un'immagine usando una matrice a convoluzioni
 * 24/02/2025
 */
namespace ImageFiltersConvolutionFilters
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

        private void Btn_CaricaFoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif;*.webp;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.webp;*.bmp";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                Label_PercorsoFoto.Content = filename;
                img_FotoCaricata.Source = new BitmapImage(new Uri(filename));
            } else
            {
                MessageBox.Show("L'immagine non è stata caricata correttamente.", "Errore!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_Trasforma_Click(object sender, RoutedEventArgs e)
        {
            // Creo la matrice di convoluzione
            int[,] matrix = new int[3, 3];
            int.TryParse(MatrixCell_1.Text, out matrix[0, 0]); // Nel caso il tryparse fallisca il valore sarà 0 di default.
            int.TryParse(MatrixCell_2.Text, out matrix[0, 1]);
            int.TryParse(MatrixCell_3.Text, out matrix[0, 2]);
            int.TryParse(MatrixCell_4.Text, out matrix[1, 0]);
            int.TryParse(MatrixCell_6.Text, out matrix[1, 1]);
            int.TryParse(MatrixCell_8.Text, out matrix[1, 2]);
            int.TryParse(MatrixCell_5.Text, out matrix[2, 0]);
            int.TryParse(MatrixCell_7.Text, out matrix[2, 1]);
            int.TryParse(MatrixCell_9.Text, out matrix[2, 2]);

            // Controllo che i valori della matrice siano corretti, in caso non lo siano mando un messaggio di errore.
            foreach (int i in matrix)
            {
                if (i < -255 || i > 255)
                {
                    MessageBox.Show("I valori della matrice di convoluzione devono essere compresi tra -255 e 255");
                    return;
                }
            }
            
            // TODO: Crea la convoluzione.
        }

        // SERVE PER FARE INSERIRE SOLO NUMERI NELLE TEXTBOX !!! NON CANCELLARE !!!
        private void MatrixCell_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}