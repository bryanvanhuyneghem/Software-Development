using System.Windows;
using FieldValidation.Pattern_reeks7;

namespace FieldValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// PATTERN: Strategy
    /// </summary>
    public partial class MainWindow : Window
    {
        private FieldEvaluator evaluator;


        public MainWindow()
        {
            InitializeComponent();
            evaluator = new FieldEvaluator(new NumberFieldEvaluation()); // default een numberfieldevaluation
        }


        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxType.SelectedValue != null)
            {
                switch ( (string) cbxType.SelectedValue)
                {
                    case "Number":
                        evaluator.SetEvaluation(new NumberFieldEvaluation());
                        break;
                    case "Email":
                        evaluator.SetEvaluation(new EmailFieldEvaluation());
                        break;
                    case "Bank Account":
                        evaluator.SetEvaluation(new BankFieldEvaluation());
                        break;
                }
            }
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            if (evaluator.Evaluate(txtInput.Text))
            {
                lblResult.Content = "OK";
            }
            else
            {
                lblResult.Content = "ERROR";
            }
        }

    }
}
