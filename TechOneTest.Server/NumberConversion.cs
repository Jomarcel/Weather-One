namespace TechOneTest.Server
{
    public class NumberConversion
    {

        private readonly Dictionary<int, string> dict = new Dictionary<int, string>
        {
             { 0, "" }, { 1, "ONE" }, { 2, "TWO" }, { 3, "THREES" }, { 4, "FOUR" },
             { 5, "FIVE" }, { 6, "SIX" }, { 7, "SEVEN" }, { 8, "EIGHT" }, { 9, "NINE" },
             { 10, "TEN" }, { 11, "ELEVEN" }, { 12, "TWELVE" }, { 13, "THIRTEEN" },
             { 14, "FOURTEEN" }, { 15, "FIFTEEN" }, { 16, "SIXTEEN" }, { 17, "SEVENTEEN" },
             { 18, "EIGHTEEN" }, { 19, "NINETEEN" }, { 20, "TWENTY" }, { 30, "THIRTY" }, { 40, "FORTY" }, { 50, "FIFTY" },
             { 60, "SIXTY" }, { 70, "SEVENTY" }, { 80, "EIGHTY" }, { 90, "NINETY" },  {100, "HUNDRED" }, {1000, "THOUSAND" },     { 1000000, "MILLION" }, {1000000000, "BILLION" }
        };


        public string NumberToWords(double num)
        {
             
            int dollars = (int)Math.Floor(num);
            int cents = (int)Math.Round((num - dollars) * 100);

            string dollarsWords = ConvertNumToWords(dollars);
            string centsWords = ConvertNumToWords(cents);

            string result = dollarsWords + " DOLLARS";

            if (!string.IsNullOrEmpty(centsWords))
            {
                result += " AND " + centsWords + " CENTS";
            }

            return result;
        }

        public string ConvertNumToWords(int num)
        {
            string str = "";

            if (num < 20)
            {
                str = dict[num];
            }
            else if (num < 100)
            {
                str = dict[num / 10 * 10]; // Get the base word (e.g., "twenty")
                int remainder = num % 10;
                if (remainder > 0)
                {
                    str += "-" + dict[remainder]; // Add the remainder (e.g., "five")
                }
            }
            else if (num < 1000)
            {
                str = dict[num / 100] + " HUNDRED ";
                if (num % 100 != 0)
                {
                    str += "AND ";
                }
                str += ConvertNumToWords(num % 100);
            }
            else if (num < 1000000) // million
            {
                str = ConvertNumToWords(num / 1000) + " THOUSAND ";
                if (num % 1000 != 0)
                {
                    str += "AND ";
                }
                str += ConvertNumToWords(num % 1000);
            }
            else if (num < 1000000000) // billion
            {
                str = ConvertNumToWords(num / 1000000) + " MILLION ";
                if (num % 1000000 != 0)
                {
                    str += "AND ";
                }
                str += ConvertNumToWords(num % 1000000);
            }
            else // Over billion
            {
                str = ConvertNumToWords(num / 1000000000) + " BILLION ";
                if (num % 1000000000 != 0)
                {
                    str += "AND ";
                }
                str += ConvertNumToWords(num % 1000000000);
            }

            return str.Trim();
        }
    }

    }
