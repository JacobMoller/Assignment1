using Xunit;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void Main_return_flat_list_from_lists_of_lists()
        {
            var list = new List<List<int>>();
            list.Add(new List<int>() { 1, 2 });
            list.Add(new List<int>() { 3, 4 });

            var output = Iterators.Flatten(list);


            Assert.Equal(new List<int> { 1, 2, 3, 4 }, output);
        }

        [Fact]
        public void Method_returns_list_if_predicate_true()
        {
            var list = new List<int>() { 1, 2, 3, 12, 126, 999 };

            Predicate<int> even = Iterators.IsOverHundred;

            var output = Iterators.Filter(list, even);

            Assert.Equal(new List<int>() { 126, 999 }, output);
        }

        [Fact]
        public void Method_returns_true_if_input_is_over_hundred()
        {
            var output = Iterators.IsOverHundred(101);
            var output2 = Iterators.IsOverHundred(100);

            Assert.True(output);
            Assert.False(output2);
        }
    }
}
