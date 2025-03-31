using Microsoft.Win32;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

/*
 * Antonio De Rosa 4H - Wpf App Image Processing
 *                31/03/2025
 */
namespace ImageProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float[,] mtxValue;

        int numWorkers = 5;
        object progLock = new object();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btn_chooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog(); // Create OpenFileDialog
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true) // Display OpenFileDialog by calling ShowDialog method
            {
                var path = new Uri(op.FileName);
                image.Source = new BitmapImage(path);
                imageTitle.Text = System.IO.Path.GetFileName($"{path.ToString()} [{image.Source.Height}x{image.Source.Width}]");
            }
        }

        private async void btn_process_Click(object sender, RoutedEventArgs e)
        {
            mtxValue = new float[3, 3]; // Initialize the matrix
            try
            {
                mtxValue[0, 0] = float.Parse(txt_00.Text);
                mtxValue[0, 1] = float.Parse(txt_01.Text);
                mtxValue[0, 2] = float.Parse(txt_02.Text);
                mtxValue[1, 0] = float.Parse(txt_10.Text);
                mtxValue[1, 1] = float.Parse(txt_11.Text);
                mtxValue[1, 2] = float.Parse(txt_12.Text);
                mtxValue[2, 0] = float.Parse(txt_20.Text);
                mtxValue[2, 1] = float.Parse(txt_21.Text);
                mtxValue[2, 2] = float.Parse(txt_22.Text);
            }
            catch
            {
                MessageBox.Show("Wrong matrix input"); // Show error message
                return;
            }
            
            if (image.Source != null)
            {
                WriteableBitmap bmp = new WriteableBitmap(image.Source as BitmapSource); // Create a WriteableBitmap from the image source

                // Run image processing without blocking UI
                await Task.Run(() => ProcessImageParallel(bmp));

                // Update the UI image once processing is done
                image.Source = bmp;
            }
        }




        private void ProcessImageParallel(WriteableBitmap bmp)
        {
            // Get UI-bound properties on the UI thread
            int height = bmp.Dispatcher.Invoke(() => bmp.PixelHeight);
            int width = bmp.Dispatcher.Invoke(() => bmp.PixelWidth);
            int bytesPerPixel = bmp.Dispatcher.Invoke(() => bmp.Format.BitsPerPixel) / 8;
            int stride = width * bytesPerPixel;

            byte[] pixelData = new byte[height * stride]; // Create a new byte array to store pixel data
            byte[] pixelDataNew = new byte[height * stride]; // Create a new byte array to store updated pixel data
            

            // Copy the pixel data from the WriteableBitmap on the UI thread
            bmp.Dispatcher.Invoke(() =>
            {
                bmp.Lock();
                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(bmp.BackBuffer, pixelData, 0, pixelData.Length);
                }
                finally
                {
                    bmp.Unlock();
                }
            });

            pixelData.CopyTo(pixelDataNew, 0);

            preggers.Dispatcher.Invoke(() => preggers.Minimum=0); // Set the progress bar minimum value
            preggers.Dispatcher.Invoke(() => preggers.Maximum = height); // Set the progress bar maximum value
            preggers.Dispatcher.Invoke(() => preggers.Value = 0); // Set the progress bar value to 0
            // Process pixel data in parallel (no UI-bound calls here)
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * stride) + (x * bytesPerPixel);
                    if (pixelDataNew[index+3]!=0 && index + 3 < pixelDataNew.Length) // Safety check
                    {
                        Color newColor = ApplyMatrix(x, y, width, height, pixelData, stride); // Apply the matrix to the pixel

                        // Write new color values back into the pixelData array
                        pixelDataNew[index] = newColor.B;
                        pixelDataNew[index + 1] = newColor.G;
                        pixelDataNew[index + 2] = newColor.R;
                        pixelDataNew[index + 3] = 255;
                    }
                }
                preggers.Dispatcher.Invoke(() => preggers.Value++);
            });

            // Copy the updated pixel data back to the WriteableBitmap on the UI thread
            bmp.Dispatcher.Invoke(() =>
            {
                bmp.Lock();
                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(pixelDataNew, 0, bmp.BackBuffer, pixelDataNew.Length); // Copy the updated pixel data back to the WriteableBitmap
                    bmp.AddDirtyRect(new Int32Rect(0, 0, width, height)); // Add a dirty rect to the WriteableBitmap
                }
                finally
                {
                    bmp.Unlock();
                }
            });
        }


        private Color ApplyMatrix(int x, int y, int width, int height, byte[] pixelData, int stride)
        {
            float R = 0, G = 0, B = 0; // Initialize the color values to 0

            for (int mx = 0; mx < 3; mx++)
            {
                for (int my = 0; my < 3; my++)
                {
                    int px = x + mx - 1, py = y + my - 1;
                    if (px >= 0 && px < width && py >= 0 && py < height)
                    {
                        int index = (py * stride) + (px * 4);
                        if (index + 3 < pixelData.Length) // Ensure safe access
                        {
                            Color c2 = Color.FromArgb(255, pixelData[index + 2], pixelData[index + 1], pixelData[index]); // Get the color of the pixel
                            R += (c2.R * mtxValue[mx, my]);
                            G += (c2.G * mtxValue[mx, my]);
                            B += (c2.B * mtxValue[mx, my]);
                        }
                    }
                }
            }

            return Color.FromArgb(255, (byte)Math.Clamp(R, 0, 255), (byte)Math.Clamp(G, 0, 255), (byte)Math.Clamp(B, 0, 255)); // Return the new color
        }

        public static Color GetPixelColor(BitmapImage bitmapImage, int x, int y)
        {
            if (x < 0 || x >= bitmapImage.PixelWidth || y < 0 || y >= bitmapImage.PixelHeight) // Check if the pixel coordinates are out of bounds
                throw new ArgumentOutOfRangeException("Pixel coordinates are out of bounds.");

            int bytesPerPixel = (bitmapImage.Format.BitsPerPixel + 7) / 8;
            byte[] pixelData = new byte[bytesPerPixel];
            Int32Rect rect = new Int32Rect(x, y, 1, 1); // Create a new Int32Rect
            bitmapImage.CopyPixels(rect, pixelData, bytesPerPixel, 0);

            byte b = pixelData[0];
            byte g = pixelData[1];
            byte r = pixelData[2];
            byte a = pixelData[3];
            return Color.FromArgb(a, r, g, b); // Return the color of the pixel
        }

        public static async Task<Color> GetPixelColorAsync(WriteableBitmap writeableBitmap, int x, int y)
        {
            if (x < 0 || x >= writeableBitmap.PixelWidth || y < 0 || y >= writeableBitmap.PixelHeight)
                throw new ArgumentOutOfRangeException("Pixel coordinates are out of bounds.");

            int bytesPerPixel = (writeableBitmap.Format.BitsPerPixel + 7) / 8; // Calculate the bytes per pixel
            byte[] pixelData = new byte[4];
            Int32Rect rect = new Int32Rect(x, y, 1, 1); // Create a new Int32Rect

            // Execute on UI thread asynchronously
            await writeableBitmap.Dispatcher.InvokeAsync(() =>
            {
                writeableBitmap.CopyPixels(rect, pixelData, bytesPerPixel, 0); // Copy the pixels from the WriteableBitmap
            });

            byte b = pixelData[0];
            byte g = pixelData[1];
            byte r = pixelData[2];
            byte a = pixelData[3];
            return Color.FromArgb(a, r, g, b); // Return the color of the pixel
        }


    }
}