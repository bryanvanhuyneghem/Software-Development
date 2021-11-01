using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Blaadjes.Pattern
{
    public abstract class AFigure : IFigure
    {
        // Properties
        public Random Rand { get; set; }
        public BitmapImage BitmapImage { get; set; }

        public abstract void Draw(Punt punt, MainWindow window);

        public abstract Punt Move(Punt punt, MainWindow window);
    }
}
