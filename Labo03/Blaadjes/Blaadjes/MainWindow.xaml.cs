using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Blaadjes.Pattern;

namespace Blaadjes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Deze klasse voorziet ook de randomness voor het aanmaken van een locatie voor een veertje of een blaadje.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variabelen
        // --------------------
        FigureFactory factory;                                  // Factory-object
        Random random;                                          // Random-object
        public static int groottePrentje;                       // Grootte van een image (assume: hoogte = breedte)
        Dictionary<IFigure, IList<Punt>> positiesFigurenDict;   // Een Dictionary die een IFigure mapt op een lijst met punten.
        DispatcherTimer timer;                                  // The usual WPF timer
        // --------------------

        public MainWindow()
        {
            // Initialisation
            InitializeComponent();
            factory = new FigureFactory();
            random = new Random();
            groottePrentje = 20;
            positiesFigurenDict = new Dictionary<IFigure, IList<Punt>>();

            // ******************* Extra
            // Set the background
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"s:\Documents\Universiteit Gent\Jaar 3\Semester V\Softwareontwikkeling II\Labo 2018\Labo\Labo03\Blaadjes\Blaadjes\Images\autumn.jpg", UriKind.RelativeOrAbsolute));
            //ib.ImageSource = new BitmapImage(new Uri(@"s:\Documents\Universiteit Gent\Jaar 3\Semester V\Softwareontwikkeling II\Labo 2018\Labo\Labo03\Blaadjes\Blaadjes\Images\chester.jpg", UriKind.RelativeOrAbsolute));
            canvas.Background = ib;
            // *******************

            // Gebruik een foreach-loop om alle types in de enum FigureType
            // te overlopen en elk toe te kennen aan één IFigure.
            // De enum werd "gemapt" op een array in de FigureFactory klasse om dit snel te laten gebeuren.
            foreach (FigureType type in factory.GetFiguurTypes())
            {
                // Iterator geeft juiste figure uit FigureFactory z'n dictionary
                // terug. Die dictionary geeft mij een juiste object (een van
                // de vier) terug.
                IFigure figure = factory[type]; 

                // Voeg elk type figure toe aan een dictionary en map op een list
                // die een lijst van alle posities (punten) bijhouden die van dat
                // type zijn.
                positiesFigurenDict.Add(figure, new List<Punt>());
            }


            // TIMER
            // -----
            // In WPF gebruikt men meestal de DispatchTimer om iets periodisch uit te laten voeren.
            timer = new DispatcherTimer();
            // Men moet Interval, Tick en Start oproepen op het timer-object.
            timer.Interval = new TimeSpan(0,0,0,0,30); // lengte van een Interval; elke 30 ms
            timer.Tick += new EventHandler(Play); // Tick is een event die plaatsvindt elk Interval.
                                                  // Koppel er een EventHandler aan.
            timer.Start(); // timer starten
        }


        // EventHandler: wat moet er elk interval uitgevoerd worden?
        private void Play(object sender, EventArgs e)
        {
            // Probeer een Leaf of een Feather aan te maken.
            // Afhankelijk van al dan niet slagen van de if-test in de methodes, wordt er iets aangemaakt.
            CreateALeaf();
            CreateAFeather();

            // Wis alles van het scherm om indruk van verplaatsen na te bootsen.
            canvas.Children.Clear(); 

            // Teken alles in de dictionary opnieuw op het scherm, mits een Move-update.
            foreach (IFigure figuurtje in positiesFigurenDict.Keys)
            {
                IList<Punt> puntPos = positiesFigurenDict[figuurtje]; // hulplijstje met alle punten van figure in
                for (int i = 0; i < puntPos.Count; i++)
                {
                    // Updaten met Move en dan tekenen met Draw
                    // Geef de window (this) mee zodat je in de individuele klasse aan de window kan
                    puntPos[i] = figuurtje.Move(puntPos[i], this); // this = de window
                    // Controleer nu de coordinaten van het figuurtje
                    // Als het figuurtje aan de onderkant komt en geen Feather is, dan:
                    if (puntPos[i].Y == 600 && (figuurtje.GetType() != typeof(Feather)))
                    {
                        // Verwijder geassocieerd punt uit Dictionary
                        positiesFigurenDict[figuurtje].Remove(puntPos[i]);
                    }
                    // Als het figuurtje aan de linkerkant komt en een Feather is, dan:
                    else if(puntPos[i].X == 0 && (figuurtje.GetType() == typeof(Feather)))
                    {
                        // Verwijder geassocieerd punt uit Dictionary
                        positiesFigurenDict[figuurtje].Remove(puntPos[i]);
                    }
                    else
                    {
                        // Teken het figuurtje
                        figuurtje.Draw(puntPos[i], this); // this = de window
                    }
                    
                }
            }
        }

        // Een nieuwe leaf aanmaken
        private void CreateALeaf()
        {
            FigureType typeOfLeaf = (FigureType) random.Next(3); // getal in interval [0,3[
                                                                 // dus: 0, 1 of 2
                                                                 // om type Leaf random te generen
            if(random.Next(1) == 0) // kans: P(x) = 1/2
            {
                // Genereer een random x positie om te spawnen.
                int xPositie = random.Next(0, (int)this.Width - 40);  // indien je hier niet this.Width schrijft, 
                                                                      // dan zal hij bij verlengen scherm niet op nieuwe ruimte tekenen.
                // Maak een punt dat de locatie bijhoudt van de Leaf.
                Punt punt = new Punt(xPositie, 0); // bovenaan canvas op afstand groottePrentje van rand
                // Voeg het punt toe aan de lijst van punten bij het genereerde type van een Leaf.
                positiesFigurenDict[factory[typeOfLeaf]].Add(punt);
            }
        }
       
        // Een nieuwe feather aanmaken
        private void CreateAFeather()
        {
            if(random.Next(5) == 0) // kans: P(x) = 1/5
            {
                // Genereer een random y positie om te spawnen.
                int YPos = random.Next(20, (int) 400 - 40); // indien je hier this.Height schrijft, 
                                                            // dan zal hij bij verlengen scherm op nieuwe ruimte tekenen.
                // Maak een punt die de locatie bijhoudt van de Leaf.
                Punt punt = new Punt((int)(this.Width - groottePrentje*2), YPos); // indien je hier niet this.Width schrijft, 
                                                                                  // dan zal hij bij verlengen scherm niet op nieuwe ruimte tekenen.
                // Voeg het punt toe aan de lijst van punten van het type Feather.
                positiesFigurenDict[factory[FigureType.pluim]].Add(punt);
            }
        }

        // Tekenen van de image op het canvas
        public void DrawImage(Punt punt, BitmapImage bitmapImage)
        {
            Image image = new Image();
            image.Source = bitmapImage; // Source Property van een Image setten met een BitmapImage.
            image.Width = groottePrentje; // Image width setten
            image.Height = groottePrentje;  // Image height setten

            // Zet de offset in relatie tot de bovenkant en de linkerkant van het canvas.
            // Dus waar hij getekend moet worden. 
            // Bv: 
            //  ____________
            // |      |
            // |      |
            // |------x
            // |
            // |
            Canvas.SetLeft(image, punt.X);
            Canvas.SetTop(image, punt.Y);
            // Voeg de image toe aan de kinderen van het canvas.
            canvas.Children.Add(image);
        }
    }
}
