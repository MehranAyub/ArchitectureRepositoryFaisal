using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Extensions
{
  public static  class StringExtensions
    { /// <summary>
      /// Gets the value or default.
      /// </summary>
      /// <param name="value">The value.</param>
      /// <param name="defaultValue">The default value.</param>
      /// <returns>System.String.</returns>
        public static string GetValueOrDefault(this string value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value;
        }

        /// <summary>
        /// Determines whether [is not empty] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is not empty] [the specified value]; otherwise, <c>false</c>.</returns>
        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }

        /// <summary>
        /// Determines whether the specified value is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the specified value is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Lefts the specified length.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="length">The length.</param>
        /// <param name="appendContinutiy">if set to <c>true</c> [append continutiy].</param>
        /// <returns>System.String.</returns>
        public static string Left(this string param, int length, bool appendContinutiy = false)
        {

            string result = param;
            if (param.Length > length)
            {
                result = param.Substring(0, length);
                if (appendContinutiy)
                    result += "...";


            }
            return result;
        }
        /// <summary>
        /// Rights the specified length.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string Right(this string param, int length)
        {
            if (param.IsNotEmpty())
            {
                string result = param.Substring(param.Length - length, length);

                return result;
            }
            return string.Empty;
        }


        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string ToTitleCase(this string value)
        {

            System.Globalization.TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(value); //War And Peace
        }

        /// <summary>
        /// To the date.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? ToDate(this string param)
        {
            DateTime date;

            bool result = DateTime.TryParse(param, out date);
            if (result && date.Year > 1950)
                return date;

            return null;


        }

        /// <summary>
        /// Checks if the given string is a valid date or Empty
        /// </summary>
        /// <param name="param">The parameter.</param>
        public static bool IsDateOrEmpty(this string param)
        { 
            return param.IsEmpty() || ToDate(param).HasValue;


        }


        /// <summary>
        /// Checks if the given string is a valid date or Empty
        /// </summary>
        /// <param name="param">The parameter.</param>
        public static bool IsValidDate(this string param)
        {
            return ToDate(param).HasValue;
        }
    }
}
