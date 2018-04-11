using System.Collections.Generic;

namespace WPFConvertNumbers
{
    public enum Language
    {
        English = 0,
        Ukrainian = 1
    }

    public enum Plurar
    {
        Single = 1,
        Plurar = 2,
        Other = 0
    }

    public enum CurrencyPart
    {
        Currency = 0,
        Point = 1
    }
   
    /// <summary>    
    ///Currency dictionary that store possible descriptions for different languages
    ///
    public static class Currency
    {
        public static Dictionary<Language, CurrencyParts> CurrencyDictionary { get; set; }

        static Currency()
        {
            Initialize();
        }

        private static void Initialize()
        {
            CurrencyDictionary = new Dictionary<Language, CurrencyParts>();
            CurrencyPlurars tempCurrencyPlurars = new CurrencyPlurars();
            CurrencyParts tempCurrencyParts = new CurrencyParts();

            tempCurrencyPlurars.Add(Plurar.Single, "гривня");
            tempCurrencyPlurars.Add(Plurar.Other, "гривні");
            tempCurrencyPlurars.Add(Plurar.Plurar, "гривень");
            tempCurrencyParts.Add(CurrencyPart.Currency, tempCurrencyPlurars.Clone());
            tempCurrencyPlurars.Clear();
            tempCurrencyPlurars.Add(Plurar.Single, "копійка");
            tempCurrencyPlurars.Add(Plurar.Other, "копійки");
            tempCurrencyPlurars.Add(Plurar.Plurar, "копійок");
            tempCurrencyParts.Add(CurrencyPart.Point, tempCurrencyPlurars.Clone());
            CurrencyDictionary.Add(Language.Ukrainian, tempCurrencyParts.Clone());
            tempCurrencyPlurars.Clear();
            tempCurrencyParts.Clear();


            tempCurrencyPlurars.Add(Plurar.Single, "dollar");
            tempCurrencyPlurars.Add(Plurar.Plurar, "dollars");
            tempCurrencyParts.Add(CurrencyPart.Currency, tempCurrencyPlurars.Clone());
            tempCurrencyPlurars.Clear();
            tempCurrencyPlurars.Add(Plurar.Single, "cent");
            tempCurrencyPlurars.Add(Plurar.Plurar, "cents");
            tempCurrencyParts.Add(CurrencyPart.Point, tempCurrencyPlurars.Clone());
            CurrencyDictionary.Add(Language.English, tempCurrencyParts.Clone());
            tempCurrencyPlurars.Clear();
            tempCurrencyParts.Clear();
        }
    }

    /// <summary>
    /// CurrencyPlurars dictionay that store currency in different plurars
    /// </summary>
    public class CurrencyPlurars
    {
        public Dictionary<Plurar, string> CurrencyPlurarsDictionary { get; set; }
        public CurrencyPlurars()
        {
            CurrencyPlurarsDictionary = new Dictionary<Plurar, string>();
        }

        public void Add(Plurar plurar, string value)
        {
            CurrencyPlurarsDictionary.Add(plurar, value);
        }

        public void Clear()
        {
            CurrencyPlurarsDictionary.Clear();
        }
        public CurrencyPlurars Clone()
        {
            CurrencyPlurars other = new CurrencyPlurars();
            other.CurrencyPlurarsDictionary = new Dictionary<Plurar, string>(CurrencyPlurarsDictionary);
            return other;
        }
    }

    /// <summary>
    /// Dictionary that store Parts of the currency: Currency and its Points.
    /// </summary>
    public class CurrencyParts
    {
        public Dictionary<CurrencyPart, CurrencyPlurars> CurrencyPartsDictionary { get; set; }
        public CurrencyParts()
        {
            CurrencyPartsDictionary = new Dictionary<CurrencyPart, CurrencyPlurars>();
        }

        public void Add(CurrencyPart plurar, CurrencyPlurars value)
        {
            CurrencyPartsDictionary.Add(plurar, value);
        }

        public void Clear()
        {
            CurrencyPartsDictionary.Clear();
        }

        public CurrencyParts Clone()
        {
            CurrencyParts other = new CurrencyParts();
            other.CurrencyPartsDictionary = new Dictionary<CurrencyPart, CurrencyPlurars>(CurrencyPartsDictionary);
            return other;
        }
    }

}
