using DrukMeter.Pattern;
using System;
using System.Windows.Controls;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for UitvoerControl.xaml
    /// </summary>
    public partial class UitvoerControl : UserControl
    {
        // het IDrukModel is het Subject
        private IDrukSubject drukSubject;

        public UitvoerControl(IDrukSubject drukSubject)
        {
            InitializeComponent();
            this.drukSubject = drukSubject;

            // observer toevoegen, Action is zoals delegate (Func), maar dan zonder return type
            drukSubject.RegisterObserver(UpdateWijzer);
            UpdateWijzer();
        }

        private void UpdateWijzer()
        {
            // Druk en MaximaleDruk zijn nu niet meer hardgecodeerd in deze klasse maar
            // worden opgehaald uit het drukSubject.
            double currentAngle = (5.0 / 4.0) * Math.PI - (drukSubject.Druk / drukSubject.MaximaleDruk) * (Math.PI * 3.0 / 2.0);
            // wijzer is een line zie UitvoerControl.xaml
            wijzer.X2 = 100 + 60 * Math.Cos(currentAngle);
            wijzer.Y2 = 100 - 60 * Math.Sin(currentAngle);
        }
    }
}