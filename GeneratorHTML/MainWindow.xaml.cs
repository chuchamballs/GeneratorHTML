using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GeneratorHTML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string HTMLskeleton = @"<!DOCTYPE html>
        <html>
            <head>
              <title>HTML Skeleton</title>
            </head>
            <body>
              Hello World!
            </body>
        </html>";
        string adresaSouboru = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNacistHTML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "HTML soubory (*.html)|*.html";
            if(dialog.ShowDialog() == true)
            {
                string obsahSouboru = File.ReadAllText(dialog.FileName);
                adresaSouboru = dialog.FileName;
                txtObsah.Text = obsahSouboru;
            }
            else
            {
                MessageBox.Show("Nebyl vybrán žádný soubor");
            }
        }

        private void btnVytvoritHTML_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog dialogSlozka = new VistaFolderBrowserDialog();
            if(dialogSlozka.ShowDialog() == true)
            {
                adresaSouboru = dialogSlozka.SelectedPath;
                File.WriteAllText(dialogSlozka.SelectedPath + "/indes.html", HTMLskeleton);
            }
        }

        private void btnUlozitHTML_Click(object sender, RoutedEventArgs e)
        {
            string obsahTextboxu = txtObsah.Text;
            File.WriteAllText(adresaSouboru, obsahTextboxu);

            MessageBox.Show("Uloženo ty jeden chytrý člověku :)");
        }
    }
}
