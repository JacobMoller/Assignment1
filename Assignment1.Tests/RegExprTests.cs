using Xunit;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void Is_line_split_on_all_whitespace()
        {
            var list = new List<string>() { "hej med dig", "gik en tur", "mangler et gruppemedlem" };

            var output = RegExpr.SplitLine(list);

            Assert.Equal(new List<string>() { "hej", "med", "dig", "gik", "en", "tur", "mangler", "et", "gruppemedlem" }, output);
        }

        [Fact]
        public void Resolution_input_returns_touple()
        {
            List<(int, int)> test = new List<(int, int)> { (1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960) };
            IEnumerable<string> input = new string[] { "1920x1080", "1024x768, 800x600, 640x480", "320x200, 320x240, 800x600", "1280x960" };
            var output = RegExpr.Resolutions(input);

            Assert.Equal(test, output);
        }

        [Fact]
        public void Return_inner_text_from_html_code()
        {
            string input = @"<p>This <b>is</b> <i>a</i> test</p>";
            IEnumerable<string> expected = new string[] { "This is a test" };

            var output = RegExpr.InnerText(input, "p");

            Assert.Equal(expected, output);
        }
    }
}
