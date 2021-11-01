using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Blaadjes.Pattern
{
    public class Leaf : AFigure
    {
        //Constructor
        public Leaf(string path)
        {
            Rand = new Random();
            // Met een BitmapImage i.p.v. een Image, maar dan moet de parameter
            // van type Uri zijn en niet string.
            BitmapImage = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }

        // Teken het figuurtje op het scherm.
        public override void Draw(Punt punt, MainWindow window)
        {
            window.DrawImage(punt, BitmapImage);
        }

        // Update de coördinaten van het meegegeven punt: een leaf beweegt van boven naar onder.
        public override Punt Move(Punt punt, MainWindow window)
        {
            punt.Y += 10;
            return punt;
        }
    }
}
