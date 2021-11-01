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
    public abstract class AFigure : IFigure
    {
        protected List<Point> punten = new List<Point>();
        protected Brush strokeColor;

        public AFigure(Brush strokeColor)
        {
            this.strokeColor = strokeColor;
        }

        // Maximaal 2 punten voor een basisfiguur; vandaar virtual, overschrijfbaar
        public virtual void AddPoint(Point p)
        {
            if(punten.Count < 2)
            {
                punten.Add(p);
            }
            else
            {
                punten[1] = p; // maximaal 2 punten (vervang dus eigenlijk gewoon telkens laatste punt)
                               // zodat max. 2 punten.
            }
        }

        public abstract void Draw(Canvas canvas);
    }
}
