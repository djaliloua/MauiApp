using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    internal class Utility
    {
        public static ConversionPercentage ApplyPercentage(string value)
        {
            ConversionPercentage percentage = new ConversionPercentage();

            for (int i = 0; i < value.Length; i++)
            {
                try
                {
                    percentage.Value = (float.Parse(value.Substring(i, value.Length)) / 100).ToString().Replace(',', '.');
                    break;
                }
                catch
                {

                }
            }
            return percentage;
        }
        public static object[] IsParsable(string value)
        {
            object[] result = new object[3];
            string d = null;
            int? startindex = null;
            int r = 0;
            for (int i = 0; i < value.Length; i++)
            {
                try
                {
                    r = value.Length - i;
                    d = float.Parse(value.Substring(i, r)).ToString();
                    startindex = i;

                    // Console.WriteLine(d);
                    break;
                }
                catch
                {

                }
            }
            result[0] = d;
            result[1] = startindex;
            result[2] = r;
            return result;
        }
        public static string LastValue(string value)
        {
            object[] result = new object[3];
            string d = null;
            int r = 0;
            for (int i = 0; i < value.Length; i++)
            {
                try
                {
                    r = value.Length - i;
                    d = float.Parse(value.Substring(i, r)).ToString();
                    

                    // Console.WriteLine(d);
                    break;
                }
                catch
                {

                }
            }
           
            return d;
        }
        public static string RemainingValue(string value)
        {
            object[] result = new object[3];
            string d = null;
            int startindex = 0;
            int r = 0;
            for (int i = 0; i < value.Length; i++)
            {
                try
                {
                    r = value.Length - i;
                    d = float.Parse(value.Substring(i, r)).ToString();
                    startindex = i;

                    // Console.WriteLine(d);
                    break;
                }
                catch
                {

                }
            }
            
            return value.Remove(startindex, d.Length);
        }
    }
    
    public class ConversionPercentage
    {
        public string Value { get; set; }
    }
}
