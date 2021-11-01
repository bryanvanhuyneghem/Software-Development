using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TekenProject.Pattern.Figuren;

namespace TekenProject.Pattern.DrawStrategy
{
    public abstract class AStrategy : IStrategy
    {
        protected IFigure figuur;
        protected Helper helper;
        private Canvas canvas;

        public AStrategy(Helper helper, Canvas canvas)
        {
            this.helper = helper;
            this.canvas = canvas;
        }

        // Figuur opvragen
        public abstract IFigure GetFigure();


        public virtual void MouseDown(Point p)
        {
            figuur = GetFigure(); //nieuwe figuur
            figuur.AddPoint(p);
        }

        public void MouseMove(Point p)
        {
            figuur?.AddPoint(p);   //enkel als er een figuur is 

            helper.Draw(canvas);
            figuur?.Draw(canvas);
        }

        public virtual void MouseUp(Point eind)
        {
            figuur?.AddPoint(eind);
            helper.AddFigure(figuur);
            helper.Draw(canvas);
            figuur = null;
        }
    }
}
