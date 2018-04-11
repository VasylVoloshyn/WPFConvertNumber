using System;
using System.Globalization;
using System.Windows;

namespace WPFConvertNumbers
{
    /// <summary>
    /// Exception for entered value in incorrect format 
    /// </summary>
    public class IncorrectNumberException : Exception
    {
        public IncorrectNumberException()
        {
        }

        public IncorrectNumberException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Validate that input string is in correct format and it may be transform to string 
    /// </summary>
    public class ValidateNumber
    {
        private String inputNumber;
        private Language language;
        private const Decimal maxNumber = Int32.MaxValue;
        private const Decimal minNumber = 0;
        private const Decimal minDecimalPart = 0.01M;
        public Decimal Number { get; set; }

        public ValidateNumber(Language lng, string str)
        {
            inputNumber = str;
            language = lng;
        }

        public bool Validate()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            switch (language)
            {
                case Language.English:
                    nfi = new CultureInfo("en-US", false).NumberFormat;
                    break;
                case Language.Ukrainian:
                    nfi = new CultureInfo("uk-UA", false).NumberFormat;
                    nfi.CurrencyDecimalDigits = 2;
                    break;
            }

            try
            {
                Number = Convert.ToDecimal(inputNumber, nfi);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(String.Format("Incorrect Number {0} Format.", inputNumber) + Environment.NewLine + ex.StackTrace);
                return false;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(String.Format("Number {0} is greater then max Allowed number.", inputNumber) + Environment.NewLine + ex.StackTrace);
                return false;
            }

            if (Number < minNumber || Number > maxNumber || (Number - Math.Truncate(Number)).ToString().TrimEnd('0').Length > 4)
            {
                throw new IncorrectNumberException(String.Format("Sorry Number {0} is incorrect", inputNumber));
            }
            return true;
        }
    }
}
