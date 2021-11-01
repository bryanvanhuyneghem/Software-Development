using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TekenProject.Pattern.Figuren
{
    public class Ellips : AShapeFigure
    {
        public Ellips(Brush strokeColor, Brush fillColor) : base(new Ellipse(), strokeColor, fillColor)
        {
        }
    }
}
