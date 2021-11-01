using Microsoft.Win32;
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

namespace ImageViewer
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

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            // Maak een OpenFileDialog object
            OpenFileDialog dlg = new OpenFileDialog();

            // Voeg een bestandsfilter toe 
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif)|*.png;*.jpeg;*.jpg;*.png|All files (*.*)|*.*";

            // Open de OpenFileDialog door de ShowDialog methode op te roepen 
            Nullable<bool> result = dlg.ShowDialog();

            // Haal het volledige pad op van het geselecteerde bestand 
            if (result == true)
            {
                string filename = dlg.FileName;

                string[] words = filename.Split('\\');
                TxtInputFile.Text = words[words.Length-1];

                Image.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.RelativeOrAbsolute));
                ImageRotateTransform.Angle = 0; // Reset de huidige rotatie
            }
        }

        private void btnRotateLeft_Click(object sender, RoutedEventArgs e)
        {
            ImageRotateTransform.Angle -= 90;
        }


        private void btnRotateRight_Click(object sender, RoutedEventArgs e)
        {
            ImageRotateTransform.Angle += 90;

        }
    }
}
