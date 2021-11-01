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
    public abstract class AShapeFigure : AFigure
    {
        private Shape shape;
        private Brush fillColor;

        public AShapeFigure(Shape shape, Brush strokeColor, Brush fillColor) : base(strokeColor)
        {
            this.shape = shape;
            this.fillColor = fillColor;
        }

        // Overschreven indien 2 of meer punten
        public override void Draw(Canvas canvas)
        {
            if (punten.Count >= 2)
            {
                Point start = punten[0];
                Point eind = punten[1];
                shape.Width = Math.Abs(eind.X - start.X);
                shape.Height = Math.Abs(eind.Y - start.Y);
                shape.Stroke = strokeColor;
                shape.Fill = fillColor;

                Canvas.SetLeft(shape, Math.Min(start.X, eind.X));
                Canvas.SetTop(shape, Math.Min(start.Y, eind.Y));
                canvas.Children.Add(shape);
            }
        }
    }
}
