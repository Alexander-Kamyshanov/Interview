using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultiThreadQueue.Collections;

namespace MultiThreadQueue
{
    class Program
    {
        static int interationsCount = 3;
        static readonly ThreadSafetyQueue<int> queue = new ThreadSafetyQueue<int>();
        static void Main(string[] args)
        {

            for (int i = 0; i < interationsCount; i++)
            {
                Thread thread;
                if (i % 2 == 1)
                {
                    thread = new Thread(new ParameterizedThreadStart(Populate));
                    thread.Start(i);
                }
                else
                {
                    thread = new Thread(new ParameterizedThreadStart(Remove));
                    thread.Start(i);
                }

            }
            Console.ReadKey();

        }

        public static void Populate(object index)
        {
            int ind = (int)index;
            string name = $"Thread {ind}";
            for (int i = ind; i < interationsCount + ind; i++)
            {
                Console.WriteLine($"{name} is trying to push {i}");
                queue.Push(i);
                Console.WriteLine($"Populate result: {queue}");
                Thread.Sleep(i * 100);
            }
        }

        public static void Remove(object index)
        {
            string name = $"Thread {(int) index}";
            Console.WriteLine($"{name} is trying to pop");
            var result = queue.Pop();
            Console.WriteLine($"{name} result: {result}");
            Thread.Sleep(100 + (int)index * 100);
        }
    }
}
