using System;

namespace WPFConvertNumbers
{
    /// <summary>
    /// Base class number 
    /// </summary>
    public class Number
    {
        public decimal InputNumber { get; set; }

        public Number() { }
        public Number(decimal number)
        {
            InputNumber = number;
        }

        public virtual string ConvertToString()
        {
            return String.Empty;
        }        
    }

    /// <summary>
    /// Number that convert its value to ukrainian
    /// </summary>
    public class UkraineNumber: Number
    {        
        public override string ConvertToString()
        {
            ConvertNumber convertNumber = new ConvertNumber();
            return convertNumber.Convert(Language.Ukrainian, InputNumber);            
        }
    }

    /// <summary>
    /// Number that convert its value to english 
    /// </summary>
    public class EnglishNumber: Number
    {        
        public override string ConvertToString()
        {
            ConvertNumber convertNumber = new ConvertNumber();
            return convertNumber.Convert(Language.English, InputNumber);
        }
    }


   
}
