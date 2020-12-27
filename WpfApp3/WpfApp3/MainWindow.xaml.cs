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
using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String line = DateTime.UtcNow.ToString("f");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Administrateur\Desktop\historys/history.txt", true))
            {
                file.WriteLine(line);
            }

            // Make a reference to a directory.
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrateur\Desktop\T25.Alpha.By.E_M_A");
            // Get a reference to each file in that directory.
            FileInfo[] fiArr = di.GetFiles();
            // Display the names and sizes of the files.
            double b = 0;
            foreach (var item in fiArr)
            {
                b += item.Length;
            }

            clean.Content = $"The size of your file is counting by MO: {b / 1000000}";

            lbl_analyse.Content = "analyse en cours";


            LengthyTaskProgress.Visibility = Visibility.Visible;
            clean.Visibility = Visibility.Hidden;


            Thread.Sleep(1000);
            LengthyTaskProgress.Value = 0;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        LengthyTaskProgress.Value = i;
                        if (i == 99)
                        {
                            lbl_analyse.Content = "Analyse terminer";
                            LengthyTaskProgress.Visibility = Visibility.Hidden;
                            clean.Visibility = Visibility.Visible;

                        }


                    });
                }
            });

        }

        private void delet_Click(object sender, RoutedEventArgs e)
        {
            double b = 0;
            try
            {
                // Make a reference to a directory.
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Administrateur\Desktop\T25.Alpha.By.E_M_A");
                // Get a reference to each file in that directory.
                FileInfo[] fiArr = di.GetFiles();
                // Display the names and sizes of the files.
                foreach (var item in fiArr)
                {
                    item.Delete();
                    b += item.Length;
                }



                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Administrateur\Desktop\historys/history.txt", true))
                {
                    file.WriteLine(b / 100000);
                }

                clean.Content = $" your file is delted";
            }

            catch (Exception)
            {
                clean.Content = "your file is empty!";
            }


        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            /*clean.Content =  File.GetLastAccessTime(@"C:/Users/Administrateur/Desktop/T25.Alpha.By.E_M_A");*/
            clean.Content = $"the last analyse is give your size by MO: {System.IO.File.ReadAllLines(@"C:\Users\Administrateur\Desktop\historys/history.txt").Last()}";

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://pastebin.com/raw/HNL4B3Qr").Contains("1.1.4"))
                {
                    if (MessageBox.Show("Looks like there is an update! Do you want to download it?", "Demo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        using (var client = new WebClient())
                        {
                            Process.Start(@"C:\Users\Administrateur\source\repos\WpfApp2\update\bin\Release\update.exe");
                            this.Close();
                        }
                }
            }
            catch
            {

            }
        }
    }
}
