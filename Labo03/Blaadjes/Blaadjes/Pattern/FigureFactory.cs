using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blaadjes.Pattern
{
    public enum FigureType { blad, groenBlad, roodBlad, pluim}

    public class FigureFactory 
    {
        // Deze dictionary mapt een figuurtype op een IFigure object.
        Dictionary<FigureType, IFigure> figures;

        public FigureFactory()
        {
            figures = new Dictionary<FigureType, IFigure>();
            // Eigenlijke mappen in de dictionary:
            figures.Add(FigureType.blad, new Leaf(@"\Images\blad.png"));
            figures.Add(FigureType.groenBlad, new Leaf(@"\Images\groenBlad.png"));
            figures.Add(FigureType.roodBlad, new Leaf(@"\Images\roodBlad.png"));
            figures.Add(FigureType.pluim, new Feather());
        }

        // Iterator om een IFigure snel te vinden.
        public IFigure this[FigureType type]
        {
            get { return figures[type]; }
        }


        // Zet de enum om naar een array om snel het type op te halen van een figuurtje.
        // Wordt gebruikt in MainWindow constructor.
        public FigureType[] GetFiguurTypes()
        {
            FigureType[] types = { FigureType.blad, FigureType.groenBlad, FigureType.roodBlad, FigureType.pluim };
            return types;
        }


    }
}
