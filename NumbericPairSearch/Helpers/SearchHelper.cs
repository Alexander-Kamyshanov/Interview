using System;
using System.Collections.Generic;
using System.Linq;
using NumbericPairSearch.Model;

namespace NumbericPairSearch.Helpers
{
    public static class SearchHelper
    {
        public static List<Pair> FindPairs(List<int> source, int sum)
        {
            if (source == null)
            {
                throw new ArgumentException(nameof(source));
            }

            List<Pair> result = new List<Pair>();

            List<int> cleanedSource = SortAndClean(source);

            // nothing to check
            if (cleanedSource.Count < 2)
            {
                return result;
            }

            int leftIterator = 0;
            int rightIterator = cleanedSource.Count - 1;

            // if max elem + it's previous element < sum - nothing to search
            if ((cleanedSource[rightIterator] + cleanedSource[rightIterator - 1]) < sum)
            {
                return result;
            }

            while (leftIterator < rightIterator)
            {
                // current min
                int currentLeft = cleanedSource[leftIterator];
                // current max 
                int currentRight = cleanedSource[rightIterator];

                // skip each current max element if current max + current min > sum
                while ((currentRight + currentLeft) > sum && rightIterator > 0)
                {
                    currentRight = cleanedSource[--rightIterator];
                }

                if (currentLeft + currentRight == sum)
                {
                    result.Add(new Pair { Left = currentLeft, Right = currentRight });
                }

                leftIterator++;
            }

            return result;
        }

        private static List<int> SortAndClean(List<int> source)
        {
            List<int> result = new List<int>();
            int? last = null;
            foreach (int item in source.OrderBy(si => si))
            {
                if (last != item)
                {
                    result.Add(item);
                }
                last = item;
            }
            return result;
        }
    }
}
