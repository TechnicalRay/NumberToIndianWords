using System.Text;

namespace NumberToIndianWords
{
    public static class Program
    {
        /// <summary>
        /// Converts a decimal amount into its equivalent representation in Indian currency words.For decimal values
        /// </summary>
        /// <remarks>The method handles both rupee and paise components. If the amount has no fractional
        /// part, only the rupee component is included in the result. If the amount is zero, an empty string is
        /// returned.</remarks>
        /// <param name="amount">The amount to convert, where the integral part represents rupees and the fractional part represents paise.</param>
        /// <returns>A string representing the amount in Indian currency words. For example, an input of 123.45 will return "One
        /// hundred twenty-three rupees and forty-five paise".</returns>
        public static string ToIndianCurrencyWords(this decimal amount)
        {
            long rupees = (long)Math.Floor(amount);
            long paise = (long)((amount - rupees) * 100);

            var result = new StringBuilder();

            if (rupees > 0)
                result.Append($"{ToIndianWords(rupees)} rupee{(rupees > 1 ? "s" : "")}");

            if (paise > 0)
            {
                if (rupees > 0) result.Append(" and ");
                result.Append($"{ToIndianWords(paise)} paise");
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// Converts a float amount into its equivalent representation in Indian currency words.
        /// </summary>
        /// <remarks>
        /// Internally casts the float to decimal for precision and delegates to the decimal conversion method.
        /// </remarks>
        /// <param name="amount">The float amount to convert.</param>
        /// <returns>
        /// A string representing the amount in Indian currency words.
        /// </returns>
        public static string ToIndianCurrencyWords(this float amount)
        {
            return ToIndianCurrencyWords((decimal)amount);
        }

        /// <summary>
        /// Converts a long integer amount into its equivalent representation in Indian currency words.
        /// </summary>
        /// <remarks>
        /// Only the rupee component is considered since long represents whole numbers.
        /// </remarks>
        /// <param name="amount">The long integer amount to convert.</param>
        /// <returns>
        /// A string representing the amount in Indian currency words. For example, 10000000 returns "one crore rupees".
        /// </returns>
        public static string ToIndianCurrencyWords(this long amount)
        {
            return $"{ToIndianWords(amount)} rupee{(amount > 1 ? "s" : "")}";
        }

        /// <summary>
        /// Converts an integer amount into its equivalent representation in Indian currency words.
        /// </summary>
        /// <remarks>
        /// Delegates to the long overload for consistency.
        /// </remarks>
        /// <param name="amount">The integer amount to convert.</param>
        /// <returns>
        /// A string representing the amount in Indian currency words.
        /// </returns>
        public static string ToIndianCurrencyWords(this int amount)
        {
            return ToIndianCurrencyWords((long)amount);
        }

        /// <summary>
        /// Converts a short integer amount into its equivalent representation in Indian currency words.
        /// </summary>
        /// <remarks>
        /// Delegates to the long overload for consistency.
        /// </remarks>
        /// <param name="amount">The short integer amount to convert.</param>
        /// <returns>
        /// A string representing the amount in Indian currency words.
        /// </returns>
        public static string ToIndianCurrencyWords(this short amount)
        {
            return ToIndianCurrencyWords((long)amount);
        }

        /// <summary>
        /// Converts a numeric value into its equivalent representation in Indian numbering system words.
        /// </summary>
        /// <remarks>
        /// Supports Indian place values such as kharab, arab, crore, lakh, thousand, and hundred.
        /// </remarks>
        /// <param name="number">The number to convert.</param>
        /// <returns>
        /// A string representing the number in Indian words. For example, 123456789 returns "twelve crore thirty-four lakh fifty-six thousand seven hundred and eighty-nine".
        /// </returns>
        public static string ToIndianWords(long number)
        {
            if (number == 0) return "zero";

            bool isNegative = number < 0;
            number = Math.Abs(number);

            var parts = new StringBuilder();

            var kharab = number / 100000000000;
            number %= 100000000000;

            var arab = number / 1000000000;
            number %= 1000000000;

            var crore = number / 10000000;
            number %= 10000000;

            var lakh = number / 100000;
            number %= 100000;

            var thousand = number / 1000;
            number %= 1000;

            var hundred = number / 100;
            number %= 100;

            if (kharab > 0)
                parts.Append($"{ConvertToWords(kharab)} kharab ");
            if (arab > 0)
                parts.Append($"{ConvertToWords(arab)} arab ");
            if (crore > 0)
                parts.Append($"{ConvertToWords(crore)} crore ");
            if (lakh > 0)
                parts.Append($"{ConvertToWords(lakh)} lakh ");
            if (thousand > 0)
                parts.Append($"{ConvertToWords(thousand)} thousand ");
            if (hundred > 0)
                parts.Append($"{ConvertToWords(hundred)} hundred ");
            if (number > 0)
            {
                if (parts.Length > 0) parts.Append("and ");
                parts.Append($"{ConvertToWords(number)}");
            }
            return isNegative ? "negative " + parts.ToString().Trim() : parts.ToString().Trim();
        }

        /// <summary>
        /// Converts a number less than 100 into its English word representation.
        /// </summary>
        /// <remarks>
        /// Used internally for converting smaller segments of numbers.
        /// </remarks>
        /// <param name="number">The number to convert (should be less than 100).</param>
        /// <returns>
        /// A string representing the number in words. For example, 45 returns "forty five".
        /// </returns>
        private static string ConvertToWords(long number)
        {
            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                               "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                               "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                return units[number];
            else if (number < 100)
                return tens[number / 10] + (number % 10 > 0 ? " " + units[number % 10] : "");
            else
                return number.ToString(); // fallback
        }
    }
}
