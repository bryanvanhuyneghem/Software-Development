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
    public class Rectangle : AShapeFigure
    {
        public Rectangle(Brush strokeColor, Brush fillColor) : base(new System.Windows.Shapes.Rectangle(), strokeColor, fillColor)
        {
        }
    }
}
