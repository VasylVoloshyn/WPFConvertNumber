using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFConvertNumbers
{

    public enum CameFrom
    {
        Dozens = 0,
        Hundreds = 1,
        Thousans = 2,
        Millions = 3,
        Billions = 4
    }
    /// <summary>
    /// Class that convert number to string
    /// </summary>
    public class ConvertNumber
    {
        private const int million = 1000000;
        private const int billion = 1000000000;
        private ConvertNumbDictionary convertNumbDictionary;
        public ConvertNumber()
        {
            convertNumbDictionary = new ConvertNumbDictionary();
        }

        /// <summary>
        /// Convert number that is less 100 to string
        /// </summary>
        /// <param name="language"></param>
        /// <param name="number"></param>
        /// <param name="cameFrom"></param>
        /// <returns></returns>
        private string CalculateStringDozens(Language language, int number, CameFrom cameFrom = CameFrom.Dozens)
        {
            NumberSringView internalView = NumberSringView.Default;
            NumberSringView intsInternalView = NumberSringView.Default;
            NumberSringView dozensInternalView = NumberSringView.Default;
            String internalSeparator = " ";
            string numberStr = String.Empty;

            if (number <= 20)
            {
                if (language == Language.Ukrainian && (cameFrom == CameFrom.Millions || cameFrom == CameFrom.Billions))
                {
                    if (number == 1 || number == 2)
                    {
                        internalView = NumberSringView.Other;
                    }
                }
                numberStr = convertNumbDictionary.ConvertDictionary[number].langDictionary[language].NumFormsDictionary[internalView];
            }
            else if (number <= 100)
            {

                int dozrens = number - (number % 10);
                int ints = (number % 10);
                if (language == Language.English && ints != 0)
                {
                    dozensInternalView = NumberSringView.Plural;
                    internalSeparator = String.Empty;
                }
                if (language == Language.Ukrainian && (cameFrom == CameFrom.Millions || cameFrom == CameFrom.Billions))
                {
                    if (ints == 1 || ints == 2)
                    {
                        intsInternalView = NumberSringView.Other;
                    }
                }

                numberStr = convertNumbDictionary.ConvertDictionary[dozrens].langDictionary[language].NumFormsDictionary[dozensInternalView] + internalSeparator +
                         convertNumbDictionary.ConvertDictionary[ints].langDictionary[language].NumFormsDictionary[intsInternalView];
            }
            return numberStr;
        }

        /// <summary>
        /// Convert number that is less 1000 to string
        /// </summary>
        /// <param name="language"></param>
        /// <param name="number"></param>
        /// <param name="cameFrom"></param>
        /// <returns></returns>
        private string CalculateStringHundreds(Language language, int number, CameFrom cameFrom = CameFrom.Hundreds )
        {
            NumberSringView view = NumberSringView.Default;
            string numberStr = String.Empty;
            if (number <= 100)
            {
                numberStr = CalculateStringDozens(language, number, cameFrom);
            }
            else
            {
                int hundreds = number - number % 100;
                numberStr = convertNumbDictionary.ConvertDictionary[hundreds].langDictionary[language].NumFormsDictionary[view] + " " +
                    CalculateStringDozens(language, number - hundreds, cameFrom);
            }

            return numberStr;
        }

        /// <summary>
        /// Convert number that is less million to string
        /// </summary>
        /// <param name="language"></param>
        /// <param name="number"></param>
        /// <param name="cameFrom"></param>
        /// <returns></returns>
        private string CalculateStringThousands(Language language, int number, CameFrom cameFrom = CameFrom.Thousans)
        {
            string numberStr = String.Empty;
            NumberSringView internalView = NumberSringView.Default;
            if (number < 1000)
            {
                numberStr = CalculateStringHundreds(language, number);
            }
            else if (number < million)
            {
                int thousands = number - number % 1000;
                int hundreds = number - thousands;
                thousands = thousands / 1000;

                if (language == Language.Ukrainian)
                {
                    if (thousands.ToString().EndsWith("1") && !thousands.ToString().EndsWith("11"))
                    {
                        internalView = NumberSringView.Single;
                    }
                    else if ((thousands.ToString().EndsWith("2") || thousands.ToString().EndsWith("3") || thousands.ToString().EndsWith("4")) &&
                        !(thousands.ToString().EndsWith("12") || thousands.ToString().EndsWith("13") || thousands.ToString().EndsWith("14")))
                    {
                        internalView = NumberSringView.Plural;
                    }
                }

                numberStr = CalculateStringHundreds(language, thousands) + " " +
                         convertNumbDictionary.ConvertDictionary[1000].langDictionary[language].NumFormsDictionary[internalView] + " " +
                         CalculateStringHundreds(language, hundreds);
            }
            return numberStr;
        }

        /// <summary>
        /// Convert number that is less Billion to string
        /// </summary>
        /// <param name="language"></param>
        /// <param name="number"></param>
        /// <param name="cameFrom"></param>
        /// <returns></returns>
        private string CalculateStringMillions(Language language, int number, CameFrom cameFrom = CameFrom.Millions)
        {
            string numberStr = String.Empty;
            NumberSringView internalView = NumberSringView.Default;
            if (number < million)
            {
                numberStr = CalculateStringThousands(language, number);
            }
            else if (number < billion)
            {
                int millions = number - number % million;
                int thousands = number - millions;
                millions = millions / million;

                if (language == Language.Ukrainian)
                {
                    if (millions.ToString().EndsWith("1") && !millions.ToString().EndsWith("11"))
                    {
                        internalView = NumberSringView.Single;
                    }
                    else if ((millions.ToString().EndsWith("2") || millions.ToString().EndsWith("3") || millions.ToString().EndsWith("4")) &&
                        !(millions.ToString().EndsWith("12") || millions.ToString().EndsWith("13") || millions.ToString().EndsWith("14")))
                    {
                        internalView = NumberSringView.Plural;
                    }
                }
                numberStr = CalculateStringHundreds(language, millions, CameFrom.Millions) + " " +
                         convertNumbDictionary.ConvertDictionary[million].langDictionary[language].NumFormsDictionary[internalView] + " " +
                         CalculateStringThousands(language, thousands);
            }
            return numberStr;
        }

        /// <summary>
        /// Convert numver to string
        /// </summary>
        /// <param name="language"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private string CalculateStringNumber(Language language, int number)
        {
            string numberStr = String.Empty;
            NumberSringView internalView = NumberSringView.Default;
            if (number < billion)
            {
                numberStr = CalculateStringMillions(language, number);
            }
            else
            {
                int billions = number - number % 1000000000;
                int millions = number - billions;
                billions = billions / billion;
                if (language == Language.Ukrainian && billions > 1)
                {
                    internalView = NumberSringView.Plural;
                }
                numberStr = CalculateStringHundreds(language, billions, CameFrom.Billions) + " " +
                         convertNumbDictionary.ConvertDictionary[billion].langDictionary[language].NumFormsDictionary[internalView] + " " +
                         CalculateStringMillions(language, millions);
            }

            return numberStr;
        }

        /// <summary>
        /// Convert number (integer) to string and add currency description
        /// </summary>
        /// <param name="language"></param>
        /// <param name="currencyPart"></param>
        /// <param name="numberToConvert"></param>
        /// <returns></returns>
        private string ConvertNumberToString(Language language, CurrencyPart currencyPart, int numberToConvert)
        {

            Plurar currency = Plurar.Plurar;
            string currencyStr = String.Empty;

            if (language == Language.Ukrainian)
            {
                if (numberToConvert.ToString().EndsWith("1") && !numberToConvert.ToString().EndsWith("11"))
                {
                    currency = Plurar.Single;
                }
                else if ((numberToConvert.ToString().EndsWith("2") || numberToConvert.ToString().EndsWith("3") || numberToConvert.ToString().EndsWith("4")) &&
                    !(numberToConvert.ToString().EndsWith("12") || numberToConvert.ToString().EndsWith("13") || numberToConvert.ToString().EndsWith("14")))
                {
                    currency = Plurar.Other;
                }
            }
            else if (language == Language.English)
            {
                if (numberToConvert == 1)
                    currency = Plurar.Single;
            }

            currencyStr = Currency.CurrencyDictionary[language].CurrencyPartsDictionary[currencyPart].CurrencyPlurarsDictionary[currency];

            return CalculateStringNumber(language, numberToConvert) + " " + currencyStr;
        }

        /// <summary>
        /// Convert number to string rerurns number in string with its currency
        /// </summary>
        /// <param name="language"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public string Convert(Language language, decimal number)
        {
            string fractionalPartStr = String.Empty;
            string integerPartStr = String.Empty;
            string pointsStr = String.Empty;
            string currencyStr = String.Empty;
            
            if (number - Math.Truncate(number) > 0)
            {
                // convert number that have points to string
                int fractionalPrt = System.Convert.ToInt32((number - Math.Truncate(number)) * 100);
                fractionalPartStr = ConvertNumberToString(language, CurrencyPart.Point, fractionalPrt);

                int integerPart = System.Convert.ToInt32(Math.Truncate(number));
                if (integerPart > 0)
                {
                    integerPartStr = ConvertNumberToString(language, CurrencyPart.Currency, integerPart);
                }

            }
            else
            {
                //convert number without points to string
                int integerPart = System.Convert.ToInt32(Math.Truncate(number));
                integerPartStr = ConvertNumberToString(language, CurrencyPart.Currency, integerPart);

            }

            return integerPartStr + " " + fractionalPartStr;
        }
    }
}

