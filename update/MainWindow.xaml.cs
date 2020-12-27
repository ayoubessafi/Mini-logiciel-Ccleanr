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
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;


namespace update
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

       
        private void btn_srt_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                WebClient webClient = new WebClient();
                var client = new WebClient();
                string[] files = Directory.GetFiles(@"C:\Users\Administrateur\source\repos\WpfApp2\WpfApp2\bin\Release");

                foreach (string file in files)
                {
                    File.Delete(file);
                }

                //Thread.Sleep(5000);
                
                //if crash , everything lost , best not delate and replace directly 
                //File.Delete(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.exe");
                client.DownloadFile("http://localhost/Nouveau%20dossier/WpfApp3.zip", @"C:\Users\Administrateur\source\repos\WpfApp2\WpfApp2\bin\Release\WpfApp3.zip");
                string zipPath = @"C:\Users\Administrateur\source\repos\WpfApp2\WpfApp2\bin\Release\WpfApp3.zip";
                //. pour racourcir 
                string extractPath = @"C:\Users\Administrateur\source\repos\WpfApp2\WpfApp2\bin\Release";
                ZipFile.ExtractToDirectory(zipPath, extractPath);

                // not delate the zip file and leave it as backup by rename
                File.Delete(@"C:\Users\Administrateur\source\repos\WpfApp2\WpfApp2\bin\Release\WpfApp3.zip");
                Process.Start(@"C:\Users\Administrateur\source\repos\WpfApp2\WpfApp2\bin\Release\WpfApp3.exe");
                this.Close();

            }
            catch
            {

            }
        }
    }
}
