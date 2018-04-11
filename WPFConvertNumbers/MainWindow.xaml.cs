using System;
using System.Windows;

namespace WPFConvertNumbers
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

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            Language inputLanguage;
            Number number;

            if (cmbLanguage.Text == "English")
            {
                inputLanguage = WPFConvertNumbers.Language.English;
                number = new EnglishNumber();
            }
            else
            {
                inputLanguage = WPFConvertNumbers.Language.Ukrainian;
                number = new UkraineNumber();
            }

            String inputStr =  txtNumber.Text;
            ValidateNumber validateString = new ValidateNumber(inputLanguage, inputStr);
            try
            {
                bool isNumberValid = validateString.Validate();
                if (isNumberValid == true)
                {
                    number.InputNumber = validateString.Number;                    
                    textBlock.Text  = number.ConvertToString();
                }                
            }
            catch (IncorrectNumberException ex)
            {
                textBlock.Text = String.Empty;
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
