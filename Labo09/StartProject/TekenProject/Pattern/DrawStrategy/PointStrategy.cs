using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TekenProject.Pattern.Figuren;

namespace TekenProject.Pattern.DrawStrategy
{
    public class PointStrategy : LineStrategy
    {
        public PointStrategy(Helper helper, Canvas canvas) : base(helper, canvas)
        {
        }



        public override IFigure GetFigure()
        {
            return new Pencil(helper.StrokeColor);
        }
    }
}
