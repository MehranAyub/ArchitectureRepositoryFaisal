using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Extensions
{
   public static class NumberExtension
    {

        /// <summary>
        /// Converts String to Int64. If string is not valid Int64 then returns null
        /// </summary>
        /// <param name="anyString"></param>
        /// <returns></returns>
        public static Int64? ToNumber64(this string anyString)
        {
            if (String.IsNullOrWhiteSpace(anyString))
                return null;

            Int64 outValue;


            if (Int64.TryParse(anyString, out outValue))
                return outValue;
            return null;
        }

        public static Int64 ToNumber64OrDefault(this string anyString, int defaultValue = 0)
        {
            return anyString.ToNumber64().GetValueOrDefault(defaultValue);
        }

        /// <summary>
        /// Converts String to Int32. If string is not valid Int32 then returns null
        /// </summary>
        /// <param name="anyString"></param>
        /// <returns></returns>
        public static Int32? ToNumber(this string anyString)
        {
            if (String.IsNullOrWhiteSpace(anyString))
                return null;

            Int32 outValue;


            if (Int32.TryParse(anyString, out outValue))
                return outValue;
            return null;
        }

        public static Int16 ToNumber16OrDefault(this string anyString, short defaultValue = 0)
        {
            if (String.IsNullOrWhiteSpace(anyString))
                return 0;

            Int16 outValue;
            Int16.TryParse(anyString, out outValue);

            return outValue;

        }

        public static Int32? ToNumberOrDefault(this string anyString, int defaultValue = 0)
        {
            return anyString.ToNumber().GetValueOrDefault(defaultValue);
        }
        /// <summary>
        /// Converts String to Decimal. If string is not valid Decimal then returns null
        /// </summary>
        /// <param name="anyString"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string anyString)
        {
            if (String.IsNullOrWhiteSpace(anyString))
                return null;

            decimal outValue;


            if (decimal.TryParse(anyString, out outValue))
                return outValue;
            return null;
        }


        public static decimal ToDecimal(this int number)
        {
            return Convert.ToDecimal(number);
        }

        public static decimal ToInt(this decimal number)
        {
            return Convert.ToDecimal(number);
        }
    
}
}
