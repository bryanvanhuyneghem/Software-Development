using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TekenProject.Pattern.Figuren
{
    public class RechteLijn : AFigure
    {
        public RechteLijn(Brush strokeColor) : base(strokeColor)
        {
        }

        public override void Draw(Canvas canvas)
        {
            for(int i = 1; i < punten.Count; i++)
            {
                DrawLine(canvas, punten[i - 1], punten[i]);
            }
        }

        protected void DrawLine(Canvas canvas, Point start, Point eind)
        {
            System.Windows.Shapes.Line line = new System.Windows.Shapes.Line();
            line.Stroke = strokeColor;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = eind.X;
            line.Y2 = eind.Y;
            canvas.Children.Add(line);
        }
    }
}
