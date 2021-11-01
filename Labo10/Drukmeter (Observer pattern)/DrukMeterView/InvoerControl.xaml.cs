using System.Windows.Controls;
using System;
using DrukMeter.Pattern;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for InvoerControl.xaml
    /// </summary>
    public partial class InvoerControl : UserControl
    {
        // IDrukModel is het subject
        IDrukSubject drukSubject;

        public InvoerControl(IDrukSubject drukSubject, string titel)
        {
            InitializeComponent();
            this.drukSubject = drukSubject;
            // we willen de verandering van de data in IDrukSubject tonen, 
            // dus schrijven we de methode Show() in.
            drukSubject.RegisterObserver(Show);
            Show();

            lblEenheid.Content = drukSubject.Eenheid;
            groupBox.Header = titel;
            txtMax.Text = Convert.ToString(drukSubject.MaximaleDruk);
        }

        private void Show()
        {
            txtWaarde.Text = Convert.ToString(drukSubject.Druk);
        }

        private void btnVerlaag_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            drukSubject.Verlaag();
        }

        private void btnVerhoog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            drukSubject.Verhoog();
        }

        private void txtWaarde_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                double druk = double.Parse(txtWaarde.Text);
                //aanvullen: ok
                drukSubject.Druk = druk;
            }
        }
    }
}
