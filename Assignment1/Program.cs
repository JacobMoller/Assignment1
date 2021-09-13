using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> lists)
        {
            foreach (var list in lists)
            {
                foreach (var item in list)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static bool IsOverHundred(int number) => number > 100 ? true : false;

        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            string pattern = @"[a-zA-Z0-9][^\s]*";
            RegexOptions options = RegexOptions.Multiline;
            foreach (var line in lines)
            {
                foreach (Match m in Regex.Matches(line, pattern, options))
                {
                    yield return m.Value;
                }
            }
        }

        public static IEnumerable<(int width, int height)> Resolutions(IEnumerable<string> resolutions)
        {
            List<(int, int)> list = new List<(int, int)>();

            Regex regex = new Regex(@"(?<first>[0-9][^\s,]*)x(?<second>[0-9][^\s,]*)", RegexOptions.IgnorePatternWhitespace);
            foreach (string test in resolutions)
            {
                foreach (Match ItemMatch in regex.Matches(test.ToString()))
                {
                    yield return (Int32.Parse(ItemMatch.Groups["first"].Value), Int32.Parse(ItemMatch.Groups["second"].Value));
                }
            }
        }
    }
}
