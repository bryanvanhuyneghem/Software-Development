using Quiz.Pattern;
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

namespace QuizGUI
{
    /// <summary>
    /// Interaction logic for ShowQuiz.xaml
    /// </summary>
    public partial class ShowQuiz : UserControl
    {
        private IQuiz quiz;

        public ShowQuiz()
        {
            InitializeComponent();
        }

        private void LoadQuestion()
        {
            Question.Header = quiz.Vraag.Opgave;
            A0.Content = quiz.Vraag.Antwoorden[0];
            A1.Content = quiz.Vraag.Antwoorden[1];
            A2.Content = quiz.Vraag.Antwoorden[2];
            A3.Content = quiz.Vraag.Antwoorden[3];
        }

        private void btnA0_Click(object sender, RoutedEventArgs e)
        {
            check(0);
        }

        private void check(int nrAntwoord)
        {
            this.Answer(quiz.Vraag.Antwoorden[nrAntwoord]); // onderstaande methode
        }

        private void Answer(string answer)
        {
            quiz.Check(answer);
            lblScore.Content = "Score: " + quiz.Score;
            if (quiz.Level != null)
            {
                lblLevel.Content = string.Format("Level: {0} ", quiz.Level.Beschrijving);
            }
            if (quiz.NextLevel != null)
            {
                lblNextLevel.Content = string.Format("Next Level: {0} more points to go", quiz.NextLevel.Grens - quiz.Score);
            }
            else
            {
                lblNextLevel.Content = string.Empty;
            }
            LoadQuestion();
        }

        private void btnA1_Click(object sender, RoutedEventArgs e)
        {
            check(1);
        }

        private void btnA2_Click(object sender, RoutedEventArgs e)
        {
            check(2);
        }

        private void btnA3_Click(object sender, RoutedEventArgs e)
        {
            check(3);
        }

        internal void LoadQuiz(IQuiz quiz)
        {
            this.quiz = quiz;
            LoadQuestion();
            // Reset fields
            lblScore.Content = "Score: " + quiz.Score;
            lblLevel.Content = "Level: -";
            lblNextLevel.Content = string.Empty;
        }
    }
}
