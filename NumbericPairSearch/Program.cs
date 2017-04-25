using System;
using System.Collections.Generic;
using NumbericPairSearch.Helpers;
using NumbericPairSearch.Model;

namespace NumbericPairSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            const int collectionLength = 100;
            const int collectionBound = 100;
            const int sum = 70;
            Console.WriteLine($"Collection length = {collectionLength}");
            Console.WriteLine($"Collection bound = {collectionBound}");
            Console.WriteLine($"Sum = {collectionLength}");
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<int> source = new List<int>();
            for (int i = 0; i < collectionLength; i++)
            {
                source.Add(rnd.Next(-collectionBound, collectionBound));
            }
            Console.WriteLine($"Collection: [{String.Join(", ", source)}]");

            foreach (Pair pair in SearchHelper.FindPairs(source, sum))
            {
                Console.WriteLine($"{pair.Left} + {pair.Right} = {sum}");
            }

            Console.ReadKey();
        }
    }
}
