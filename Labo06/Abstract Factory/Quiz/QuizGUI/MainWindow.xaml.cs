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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QuizFactoryProvider provider;

        public MainWindow()
        {
            InitializeComponent();
            loadQuiz.btnCSV.Checked += LoadCategories;
            loadQuiz.btnTXT.Checked += LoadCategories;
            loadQuiz.btnLoadQuiz.Click += btnLoadQuiz_Click;
            UpdateCategories();
            showQuiz.IsEnabled = false;
        }

        private void btnLoadQuiz_Click(object sender, RoutedEventArgs e)
        {
            IQuizFactory factory = provider[((ICategory)loadQuiz.SelectCategory.SelectedItem)];
            showQuiz.LoadQuiz(new Quiz.Pattern.Quiz(factory));
            showQuiz.IsEnabled = true;
        }

        private void UpdateCategories()
        {
            if (loadQuiz.btnCSV.IsChecked.Value)
            {
                provider = new QuizFactoryProvider("csv");
            }
            else if ((bool)loadQuiz.btnTXT.IsChecked)
            {
                provider = new QuizFactoryProvider("txt");
            }
            loadQuiz.SelectCategory.Items.Clear();
            foreach (ICategory category in provider.Categories)
            {
                loadQuiz.SelectCategory.Items.Add(category);
            }
        }

        private void LoadCategories(object sender, RoutedEventArgs e)
        {
            UpdateCategories();
        }

    }
}
