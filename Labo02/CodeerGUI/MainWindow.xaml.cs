using Coderingen.Pattern;
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

namespace CodeerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICodering codering;

        public MainWindow()
        {
            codering = new BasisCodering();
            InitializeComponent();
        }

        private void BtnCodering_Click(object sender,RoutedEventArgs e)
        {
            if (CoderingBlok.IsChecked.Value)
            {
                codering = new BlokCodering(codering);
            }
            else if (CoderingWissel.IsChecked.Value)
            {
                codering = new WisselCodering(codering);
            }
            else if (CoderingCijfer.IsChecked.Value)
            {
                codering = new CijferCodering(codering);
            }
            TxtResult.Text = codering.Codeer(txtInput.Text);
        }

    }
}
