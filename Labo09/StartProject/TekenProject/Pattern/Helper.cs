using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using TekenProject.Pattern.Figuren;

namespace TekenProject.Pattern
{
    public class Helper
    {
        Stack<IFigure> figuren = new Stack<IFigure>();

        SolidColorBrush[] colors = { Brushes.Black, Brushes.White, Brushes.Gray, Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Yellow, Brushes.Purple, Brushes.Brown, Brushes.Orange };
        int strokeNr = 0, fillNr = 1;

        internal SolidColorBrush StrokeColor => colors[StrokeNr];
        internal SolidColorBrush FillColor => colors[FillNr];

        internal int StrokeNr
        {
            get { return strokeNr; }
            set
            {
                strokeNr = value % colors.Length;

            }
        }

        internal int FillNr
        {
            get { return fillNr; }
            set
            {
                fillNr = value % colors.Length;
            }
        }


        public void AddFigure(IFigure figuur)
        {
            if (figuur != null) figuren.Push(figuur);
        }

        public void ClearAll()
        {
            figuren.Clear();
        }

        public void RemoveLast()
        {
            if (figuren.Count > 0)
            {
                figuren.Pop();
            }
        }


        public void Draw(Canvas canvas)
        {
            canvas.Children.Clear();
            foreach (IFigure figuur in figuren)
            {
                figuur.Draw(canvas);
            }
        }
    }
}
