using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TekenProject.Pattern.Figuren
{
    public interface IFigure
    {
        void Draw(Canvas canvas);
        void AddPoint(Point p);
    }
}
