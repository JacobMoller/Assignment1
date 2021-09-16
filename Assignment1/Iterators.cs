using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class Iterators
    {

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
    }
}
