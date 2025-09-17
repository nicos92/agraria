using System;
using System.Globalization;

namespace Agraria.Util
{
    /// <summary>
    /// Provides utilities for formatting decimal numbers according to Argentina's culture (es-AR).
    /// This class centralizes decimal formatting to ensure consistency across the application
    /// and follows SOLID principles by having a single responsibility.
    /// </summary>
    public static class DecimalFormatter
    {
        /// <summary>
        /// Argentina culture used for formatting decimal numbers with comma as decimal separator
        /// and period as thousand separator.
        /// </summary>
        public static readonly CultureInfo ArgentinaCulture = new CultureInfo("es-AR");

        /// <summary>
        /// Formats a decimal value as currency using Argentina's culture settings.
        /// Example: 1234.56 -> "$1.234,56"
        /// </summary>
        /// <param name="value">The decimal value to format</param>
        /// <returns>A string representation of the value formatted as currency</returns>
        public static string ToCurrency(decimal value)
        {
            return value.ToString("C", ArgentinaCulture);
        }

        /// <summary>
        /// Formats a decimal value with two decimal places using Argentina's culture settings.
        /// Example: 1234.567 -> "1.234,57"
        /// </summary>
        /// <param name="value">The decimal value to format</param>
        /// <returns>A string representation of the value with two decimal places</returns>
        public static string ToDecimal(decimal value)
        {
            return value.ToString("N2", ArgentinaCulture);
        }

        /// <summary>
        /// Parses a string representation of a decimal number using Argentina's culture settings.
        /// Example: "1.234,56" -> 1234.56m
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <returns>The decimal value represented by the string</returns>
        public static decimal ParseDecimal(string value)
        {
            return decimal.Parse(value, ArgentinaCulture);
        }

        /// <summary>
        /// Tries to parse a string representation of a decimal number using Argentina's culture settings.
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <param name="result">When this method returns, contains the decimal value equivalent to the number contained in value, if the conversion succeeded, or zero if the conversion failed.</param>
        /// <returns>true if value was converted successfully; otherwise, false.</returns>
        public static bool TryParseDecimal(string value, out decimal result)
        {
            return decimal.TryParse(value, NumberStyles.Number, ArgentinaCulture, out result);
        }
    }
}