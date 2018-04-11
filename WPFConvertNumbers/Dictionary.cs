using System;
using System.Collections.Generic;

namespace WPFConvertNumbers
{
    public enum NumberSringView
    {
        Default = 0,
        Single = 1,
        Plural = 2,
        Other = 3
    }

    /// <summary>
    /// Dictionary that store number in different plurar views
    /// </summary>
    public class NumberPlurarForms
    {
        private NumberSringView numView { get; set; }
        public string Name { get; set; }

        public Dictionary<NumberSringView, string> NumFormsDictionary { get; set; }
        public NumberPlurarForms()
        {
            NumFormsDictionary = new Dictionary<NumberSringView, string>();
        }

        public void Add(NumberSringView view, string value)
        {
            NumFormsDictionary.Add(view, value);
        }

        public void Clear()
        {
            NumFormsDictionary.Clear();
        }

        public NumberPlurarForms Clone()
        {
            NumberPlurarForms other = new NumberPlurarForms();
            other.NumFormsDictionary = new Dictionary<NumberSringView, string>(NumFormsDictionary);
            return other;
        }
    }

    /// <summary>
    /// Dictionary that store number in different plurar views in different languages
    /// </summary>
    public class LangStrDictionary
    {
        public Dictionary<Language, NumberPlurarForms> langDictionary { get; set; }

        public LangStrDictionary()
        {
            langDictionary = new Dictionary<Language, NumberPlurarForms>();
        }

        public void Add(Language lng, NumberPlurarForms value)
        {
            langDictionary.Add(lng, value);
        }

        public void Clear()
        {
            langDictionary.Clear();
        }

        public LangStrDictionary Clone()
        {
            LangStrDictionary other = new LangStrDictionary();
            other.langDictionary = new Dictionary<Language, NumberPlurarForms>(langDictionary);
            return other;
        }
    }
    
    /// <summary>
    /// Dictionary used to convert number to string
    /// </summary>
    public class ConvertNumbDictionary
    {
        public Dictionary<int, LangStrDictionary> ConvertDictionary { get; private set; }

        public ConvertNumbDictionary()
        {
            ConvertDictionary = new Dictionary<int, LangStrDictionary>();
            InitDictionary();
        }


        private void InitDictionary()
        {
            LangStrDictionary tempDict = new LangStrDictionary();
            NumberPlurarForms tempNumForms = new NumberPlurarForms();

            tempNumForms.Add(NumberSringView.Default, "zero");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "ноль");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(0, tempDict.Clone());
            tempDict.Clear();


            tempNumForms.Add(NumberSringView.Default, "one");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "одна");
            tempNumForms.Add(NumberSringView.Other, "один");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(1, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "two");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "дві");
            tempNumForms.Add(NumberSringView.Other, "два");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(2, tempDict.Clone());
            tempDict.Clear();


            tempNumForms.Add(NumberSringView.Default, "three");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "три");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(3, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "four");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "чотири");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(4, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "five");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "п'ять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(5, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "six");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "шість");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(6, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "seven");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "сім");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(7, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "eight");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "вісім");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(8, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "nine");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "дев'ять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(9, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "ten");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "десять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(10, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "eleven");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "одинадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(11, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "twelve");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "дванадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(12, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "thirteen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "тринадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(13, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "fourteen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "чотирнадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(14, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "fifteen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "п'ятнадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(15, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "sixteen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "шістнадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(16, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "seventeen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "сімнадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(17, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "eighteen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "вісімнадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(18, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "nineteen");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "дев'ятнадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(19, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "twenty");
            tempNumForms.Add(NumberSringView.Plural, "twenty-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "двадцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(20, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "thirty");
            tempNumForms.Add(NumberSringView.Plural, "thirty-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "тридцять");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(30, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "forty");
            tempNumForms.Add(NumberSringView.Plural, "forty-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "сорок");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(40, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "fifty");
            tempNumForms.Add(NumberSringView.Plural, "fifty-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "п'ятдесят");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(50, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "sixty");
            tempNumForms.Add(NumberSringView.Plural, "sixty-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "шістдесят");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(60, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "seventy");
            tempNumForms.Add(NumberSringView.Plural, "seventy-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "сімдесят");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(70, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "eighty");
            tempNumForms.Add(NumberSringView.Plural, "eighty-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "вісімдесят");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(80, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "ninety");
            tempNumForms.Add(NumberSringView.Plural, "ninety-");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "дев'яносто");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(90, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "one hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "сто");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(100, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "two hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "двісті");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(200, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "three hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "триста");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(300, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "four hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "чотириста");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(400, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "five hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "п'ятсот");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(500, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "six hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "шістсот");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(600, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "seven hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "сімсот");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(700, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "eight hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "вісімсот");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(800, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "nine hundred");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "дев'ятсот");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(900, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "thousand");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "тисяч");
            tempNumForms.Add(NumberSringView.Plural, "тисячі");
            tempNumForms.Add(NumberSringView.Single, "тисяча");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(1000, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "million");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "мільйонів");
            tempNumForms.Add(NumberSringView.Plural, "мільйони");
            tempNumForms.Add(NumberSringView.Single, "мільйон");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(1000000, tempDict.Clone());
            tempDict.Clear();

            tempNumForms.Add(NumberSringView.Default, "billion");
            tempDict.Add(Language.English, tempNumForms.Clone());
            tempNumForms.Clear();
            tempNumForms.Add(NumberSringView.Default, "мільярд");
            tempNumForms.Add(NumberSringView.Plural, "мільярди");
            tempDict.Add(Language.Ukrainian, tempNumForms.Clone());
            tempNumForms.Clear();
            ConvertDictionary.Add(1000000000, tempDict.Clone());
        }
    }
}
