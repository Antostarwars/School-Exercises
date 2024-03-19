// Antonio De Rosa 3H 19/03/2024

using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Crossword
{
    public partial class MainWindow : Window
    {
        string filename;
        Button[,] buttons;
        string[] words;
        char[,] letters;
        bool[,] found;
        int h, w;
        bool loaded = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            bool? result = dialog.ShowDialog();
            if (result == null || result == false) return;
            filename = dialog.FileName;
            string[] s1;
            using(StreamReader reader = new StreamReader(filename))
            {
                string s = reader.ReadToEnd();
                s1 = s.Split("\n");
                reader.Close();
            }
            int i;
            for(i = 0; i < s1.Length; i++)
            {
                if (s1[i] == "\r")
                {
                    break;
                }
            }
            w = s1[0].Length-1; h = i;
            letters = new char[w,h];
            for (i = 0; i < s1.Length; i++)
            {
                if (s1[i] == "\r")
                {
                    break;
                }
                for(int j = 0; j < w; j++)
                {
                    letters[j, i] = s1[i][j];
                }
            }
            i++;
            if (s1.Length - h <= 0)
            {
                MessageBox.Show("Invalid file.");
                return;
            }
            words = new string[s1.Length - h - 1];
            wordsList.Text = "Parole:\n\n";
            for (;i<s1.Length; i++)
            {
                words[i - h-1] = s1[i];
                words[i - h - 1] = words[i - h - 1].Replace("\r", string.Empty);
                wordsList.Text += words[i - h - 1] + "\n";
            }

            CreateGrid();
        }

        private void solveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!loaded)
            {
                MessageBox.Show("Load a valid text file first.");
                return;
            }

            found = new bool[w, h];

            foreach(string s in words)
            {
                for(int i = 0; i < w; i++)
                {
                    for(int j = 0; j < h; j++)
                    {
                        if (Search(i, j, 1, 0, s)) break;
                        if (Search(i, j, -1, 0, s)) break;
                        if (Search(i, j, 0, 1, s)) break;
                        if (Search(i, j, 0, -1, s)) break;
                        if (Search(i, j, 1, 1, s)) break;
                        if (Search(i, j, -1, 1, s)) break;
                        if (Search(i, j, 1, -1, s)) break;
                        if (Search(i, j, -1, -1, s)) break;
                    }
                }
            }
            string sol = "";
            for(int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (!found[j, i]) sol += letters[j, i].ToString();
                }
            }

            MessageBox.Show("La soluzione è: " + sol);
        }

        bool Search(int x, int y, int xDir, int yDir, string word)
        {
            int x1 = x, y1 = y;
            for(int i = 0; i < word.Length; i++)
            {
                if (x1 < 0 || x1 >= letters.GetLength(0) || y1 < 0 || y1 >= letters.GetLength(1)) return false;
                if (word[i] == letters[x1, y1])
                {
                    x1 += xDir; y1 += yDir;
                }
                else return false;
            }
            //if found traceback

            for (int i = 0; i < word.Length; i++)
            {
                x1 -= xDir; y1 -= yDir;
                found[x1, y1] = true;
                buttons[y1, x1].BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#eb2d59");
                buttons[y1, x1].Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ed87ab");
            }
            return true;
        }

        private void CreateGrid()
        {
            buttons = new Button[h, w];
            buttonGrid.Height = h * 30;
            buttonGrid.Width = w * 30;
            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    Button b = new Button();
                    b.Content = letters[j, i];
                    b.BorderBrush = Brushes.DarkCyan;
                    b.BorderThickness = new Thickness(3,3,3,3);
                    b.Background = Brushes.LightCyan;
                    b.Width = 29;
                    b.Height = 29;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.Margin = new Thickness(j * 30, i * 30, 0, 0);
                    b.Tag = i + "," + j;
                    buttons[i,j] = b;
                    buttonGrid.Children.Add(b);
                }
            }

            loaded = true;
        }

    }
}
