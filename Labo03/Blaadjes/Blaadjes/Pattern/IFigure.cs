namespace Blaadjes.Pattern
{
    public interface IFigure
    {
        void Draw(Punt punt, MainWindow window);
        Punt Move(Punt punt, MainWindow window);
    }
}
