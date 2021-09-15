using System;
using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_return_flat_list_from_lists_of_lists()
        {
            var list = new List<List<int>>();
            list.Add(new List<int>() { 1, 2 });
            list.Add(new List<int>() { 3, 4 });

            var output = Program.Flatten(list);


            Assert.Equal(new List<int> { 1, 2, 3, 4 }, output);
        }

        [Fact]
        public void Method_returns_list_if_predicate_true()
        {
            var list = new List<int>() { 1, 2, 3, 12, 126, 999 };

            Predicate<int> even = Program.IsOverHundred;

            var output = Program.Filter(list, even);

            Assert.Equal(new List<int>() { 126, 999 }, output);
        }

        [Fact]
        public void Method_returns_true_if_input_is_over_hundred()
        {
            var output = Program.IsOverHundred(101);
            var output2 = Program.IsOverHundred(100);

            Assert.True(output);
            Assert.False(output2);
        }

        [Fact]
        public void Is_line_split_on_all_whitespace()
        {
            var list = new List<string>() { "hej med dig", "gik en tur", "mangler et gruppemedlem" };

            var output = Program.SplitLine(list);

            Assert.Equal(new List<string>() { "hej", "med", "dig", "gik", "en", "tur", "mangler", "et", "gruppemedlem" }, output);
        }

        [Fact]
        public void Resolution_input_returns_touple()
        {
            List<(int, int)> test = new List<(int, int)> { (1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960) };
            IEnumerable<string> input = new string[] { "1920x1080", "1024x768, 800x600, 640x480", "320x200, 320x240, 800x600", "1280x960" };
            var output = Program.Resolutions(input);

            Assert.Equal(test, output);
        }

        [Fact]
        public void Return_inner_text_from_html_code()
        {
            string input = @"<div>
                                <p class="""">The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
                            </div> ";
            IEnumerable<string> expected = new string[] { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." };

            var output = Program.InnerText(input, "p");

            Assert.Equal(expected, output);
        }

    }
}
