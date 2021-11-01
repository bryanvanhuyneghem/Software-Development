using Microsoft.Win32;
using SorteerBestanden;
using Sorteren;
using System;
using System.IO;
using System.Windows;

namespace SorteerProgramma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            TxtInputFile.Text = BrowseFile();
        }

        private void BtnOutput_Click(object sender, RoutedEventArgs e)
        {
            TxtOutputFile.Text = BrowseFile();
    }


    private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TypeSchool.IsChecked == true)
                {
                    BestandSorteerder<School> bs = null;
                    SchoolSorteerder vergelijker = new SchoolSorteerder();
                    if (SortSelection.IsChecked.Value)
                    {
                        bs = new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.SelectionSort, vergelijker);
                    }
                    else if (SortBubble.IsChecked == true)
                    {
                        bs = new BestandSorteerder<School>(SchoolLezer.LeesSchool, SorteerBib<School>.BubbleSort, vergelijker);
                    }
                    bs.Parse(TxtInputFile.Text, TxtOutputFile.Text);
                    TxtResult.Text = "Scholen gesorteerd";
                }
                else if( TypePark.IsChecked == true)
                {
                    BestandSorteerder<Park> bs = null;
                    ParkSorteerder vergelijker = new ParkSorteerder();
                    if (SortSelection.IsChecked.Value)
                    {
                        bs = new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.SelectionSort, vergelijker);
                    }
                    else if (SortBubble.IsChecked == true)
                    {
                        bs = new BestandSorteerder<Park>(ParkLezer.LeesPark, SorteerBib<Park>.BubbleSort, vergelijker);
                    }
                    bs.Parse(TxtInputFile.Text, TxtOutputFile.Text);
                    TxtResult.Text = "Scholen gesorteerd";
                }
            }
            catch (Exception exception)
            {
                TxtResult.Text = exception.Message;
            }
        }

        private string BrowseFile()
        {
            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files (*.csv)|*.csv|TXT Filess (*.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                return dlg.FileName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
