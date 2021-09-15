using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static void Main(string[] args)
        { }
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
            Regex regex = new Regex(@"(?<first>[0-9][^\s,]*)x(?<second>[0-9][^\s,]*)", RegexOptions.IgnorePatternWhitespace);
            foreach (string test in resolutions)
            {
                foreach (Match ItemMatch in regex.Matches(test.ToString()))
                {
                    yield return (Int32.Parse(ItemMatch.Groups["first"].Value), Int32.Parse(ItemMatch.Groups["second"].Value));
                }
            }
        }
        public static IEnumerable<string> InnerText(string html, string tag)
        {
            foreach (Match match in Regex.Matches(html, @"(?<=>)[\w\s<>\/(),.]+(?=<\/p)", RegexOptions.Multiline))
            {
                yield return Regex.Replace(match.Value, "<[^>]*>", "");
            }
        }
    }
}
