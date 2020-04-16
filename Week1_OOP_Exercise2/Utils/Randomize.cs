using System;
using System.Text;
using Week1_OOP_Exercise2.Core;

namespace Week1_OOP_Exercise2.Utils
{
    public static class Randomize
    {
        static Random random = new Random();

        public static string GenerateString(int length = 7)
        {
            int maxValue = Constants.Alphabet.Length;
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int position = random.Next(maxValue);
                builder.Append(Constants.Alphabet[position]);
            }

            return builder.ToString();
        }

        public static int GenerateNumber(int minValue = 0, int maxValue = 10)
        {
            return random.Next(minValue, maxValue);
        }
    }
}
