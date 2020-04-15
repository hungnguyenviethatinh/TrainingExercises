using System;
using System.Text;

namespace Week1_OOP_Exercise2.Utils
{
    public static class Randomize
    {
        static Random random = new Random();
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GenerateString(int length = 7)
        {
            int maxValue = characters.Length;
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int position = random.Next(maxValue);
                builder.Append(characters[position]);
            }

            return builder.ToString();
        }

        public static int GenerateNumber(int minValue = 0, int maxValue = 10)
        {
            return random.Next(minValue, maxValue);
        }
    }
}
