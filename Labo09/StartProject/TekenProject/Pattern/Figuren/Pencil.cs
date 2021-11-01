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
    public class Pencil : RechteLijn
    {
        public Pencil(Brush strokeColor) : base(strokeColor)
        {
        }

        public override void AddPoint(Point p)
        {
            punten.Add(p); // altijd toevoegen
        }
    }
}
