﻿using System;
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

namespace WpfAppProgressBarAsync3
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            BtnStart.IsEnabled = false;

            Task<int> Task1 = StartProgressBarAsync01(700);
            Task<int> Task2 = StartProgressBarAsync02(500);

            await Task.Delay(2000);

            int cas2 = await Task2;
            txtSync02.Text = $"Restituito {cas2}";
            
            await Task.Delay(2000);
            int cas1 = await Task1;
            txtSync01.Text = $"Restituito {cas1}";

            BtnStart.IsEnabled = true;
        }

        private async Task<int> StartProgressBarAsync01(int tempo)
        {
            txtSync01.Text = "Inizio Progress Bar";
            ProgressBar01.Minimum = 0;
            ProgressBar01.Maximum = tempo;
            for (int i = 0; i <= tempo; i++)
            {
                ProgressBar01.Value = i;
                await Task.Delay(1);
            }
            txtSync01.Text = "Fine Progress Bar";
            int random = new Random().Next(1, 100);
            return random;
        }

        private async Task<int> StartProgressBarAsync02(int tempo)
        {
            txtSync02.Text = "Inizio Progress Bar";
            ProgressBar02.Minimum = 0;
            ProgressBar02.Maximum = tempo;
            for (int i = 0; i <= tempo; i++)
            {
                ProgressBar02.Value = i;
                await Task.Delay(1);
            }
            txtSync02.Text = "Fine Progress Bar";
            int random = new Random().Next(1, 100);
            return random;
        }
    }
}
