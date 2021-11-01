
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using TekenProject.Pattern;
using TekenProject.Pattern.Command;
using TekenProject.Pattern.DrawStrategy;
using TekenProject.Pattern.Figuren;

namespace TekenProject
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStrategy strat;
        private Helper helper = new Helper();
        private StrategyFactory factory;

        private Dictionary<Key, Pattern.Command.ICommand> commands = new Dictionary<Key, Pattern.Command.ICommand>();
        private Pattern.Command.ICommand command;//huidige commando

        public MainWindow()
        {
            InitializeComponent();
            factory = new StrategyFactory(helper, canvas);
            strat = factory[2];
            InitCommands();
            canvas.Focus();
        }

        private void InitCommands()
        {
            commands.Add(Key.Cancel, new NoCommand(helper, this));
            commands.Add(Key.B, new BCommand(helper, this));
            commands.Add(Key.F, new FCommand(helper, this));
            commands.Add(Key.M, new MCommand(helper, this));
            commands.Add(Key.LeftCtrl, new ControlCommand(helper, this));
            commands.Add(Key.RightCtrl, new ControlCommand(helper, this));
            commands.Add(Key.R, new RCommand(helper, this));
            ResetCommand();
        }

        internal void ResetCommand()
        {
            command = commands[Key.Cancel];
        }

        #region MouseEvents       
        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            canvas.CaptureMouse();
            Point start = e.GetPosition(canvas);
            strat.MouseDown(start);
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            canvas.ReleaseMouseCapture();
            Point eind = e.GetPosition(canvas);
            strat.MouseUp(eind);

            //Teken(start, eind);
            //TekenLijn(start, eind);
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(canvas);
            strat.MouseMove(point);
        }
        #endregion

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {

            if (commands.ContainsKey(e.Key))
            {
                command = commands[e.Key];
                if (command.NumberKeys == 1)
                {
                    command.Execute(e.Key);//moet direct worden uitgevoegd bij R-toets
                }
            }
            else
            {
                command.Execute(e.Key);
                ResetCommand();
            }
        }


        #region Button_Click events
        private void btnStroke_Click(object sender, RoutedEventArgs e)
        {
            helper.StrokeNr++;
            brushStroke.Color = helper.StrokeColor.Color;
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            helper.FillNr++;
            brushFill.Color = helper.FillColor.Color;
        }

        private void btnPencil_Click(object sender, RoutedEventArgs e)
        {
            SetStrategy(1);
        }

        private void btnLine_Click(object sender, RoutedEventArgs e)
        {
            SetStrategy(2);
        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {
            SetStrategy(3);
        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            SetStrategy(4);
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            helper.RemoveLast();
            helper.Draw(canvas);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            helper.ClearAll();
            helper.Draw(canvas);
        }

        //toegankelijk gemaakt voor ICommand
        internal void SetStrategy(int nr)
        {
            strat = factory[nr];
        }
        #endregion


        // overbodig
        #region Draw methods
        /*
        private void DrawLine(Point start, Point eind)
        {
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = start.X;
            line.Y1 = start.Y;
            line.X2 = eind.X;
            line.Y2 = eind.Y;
            canvas.Children.Add(line);
        }

        private void DrawEllips(Point start, Point eind)
        {
            Shape shape = new Ellipse();
            shape.Width = Math.Abs(eind.X - start.X);
            shape.Height = Math.Abs(eind.Y - start.Y);
            shape.Stroke = Brushes.Black;
            shape.Fill = Brushes.Red;

            Canvas.SetLeft(shape, Math.Min(start.X, eind.X));
            Canvas.SetTop(shape, Math.Min(start.Y, eind.Y));
            canvas.Children.Add(shape);
        }
        */
        #endregion
    }
}
