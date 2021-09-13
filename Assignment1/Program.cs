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
            resolution2(@"1920x1080
1024x768, 800x600, 640x480
320x200, 320x240, 800x600
1280x960");
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

        public static IEnumerable<(int, int)> resolution(string input)
        {
            List<(int, int)> list = new List<(int, int)>();

            string pattern = @"(?P<first>[0-9][^\s,]*)x(?P<second>[0-9][^\s,]*)";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //Console.WriteLine(m.Groups[0]);
                //m.Groups["link"].Value
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                yield return (0, 0);//m.Value.Split("x");
            }
        }

        public static IEnumerable<(int, int)> resolution2(string input)
        {
            List<(int, int)> list = new List<(int, int)>();

            Regex regex = new Regex(@"(?<first>[0-9][^\s,]*)x(?<second>[0-9][^\s,]*)");

            foreach (Match ItemMatch in regex.Matches(input))
            {
                yield return (Int32.Parse(ItemMatch.Groups["first"].Value), Int32.Parse(ItemMatch.Groups["second"].Value));
            }
        }
    }
}
