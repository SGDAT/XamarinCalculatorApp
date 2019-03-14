using System;

namespace CalculatorApp.ViewModels.Extensions
{
    public static class NumberPadExtensions
    {
        public static string AppendNumber(string n, string i)
        {
            string newNum = $"{n}{i}";
            if (n.Contains("."))
                return newNum;

            newNum = float.Parse(newNum).ToString();
            return newNum;
        }

        public static string AppendPoint(string n)
        {
            if (n.Contains("."))
                return n;

            string newNum = $"{n}.";
            return newNum;
        }
    }
}
