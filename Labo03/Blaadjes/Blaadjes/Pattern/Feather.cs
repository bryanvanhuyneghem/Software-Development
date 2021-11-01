using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Blaadjes.Pattern
{
    public class Feather : AFigure
    {

        // Constructor
        public Feather()
        {
            Rand = new Random();
            // Met een BitmapImage i.p.v. een Image, maar dan moet de parameter
            // van type Uri zijn en niet string.
            BitmapImage = new BitmapImage(new Uri(@"Images\pluim.png", UriKind.RelativeOrAbsolute));
        }

        // Teken het figuurtje op het scherm.
        public override void Draw(Punt punt, MainWindow window)
        { 
            window.DrawImage(punt, BitmapImage);
        }

        // Update de coördinaten van het meegegeven punt: een feather beweegt van rechts naar links.
        public override Punt Move(Punt punt, MainWindow window)
        {
            punt.X -= 10;
            return punt;
        }
    }
}
