using System;

namespace Fat.Umbraco.Admin
{
    public static class StringExtensions
    {
        public static DateTime? ToDate(this string value)
        {
            DateTime result;
            if (DateTime.TryParse(value, out result))
                return result;
            return null;
        }

        public static double ToDouble(this string value)
        {
            double result;
            double.TryParse(value, out result);
            return result;
        }

        public static decimal ToDecimal(this string value)
        {
            decimal result;
            decimal.TryParse(value, out result);
            return result;
        }
    }
}