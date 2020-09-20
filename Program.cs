using System;
using System.Collections.Generic;

namespace Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            // Currying
            Func<int, int> func = (int v) => Add(v, 50);

            // Build the pipeline
            var pipeline = new List<Func<int, int>>();

            pipeline.Add(AddTen);
            pipeline.Add(MultiplyByTwo);
            pipeline.Add(DivideByTwo);
            pipeline.Add(func);

            // Pipeline 
            var result = Pipe(0, pipeline);

            // Pipeline and Currying Result
            Console.WriteLine(string.Format("The pipe result is {0}", result));
        }

        static T Pipe<T>(T initialValue, IList<Func<T, T>> funcs)
        {
            T lastResult = initialValue;

            foreach (var func in funcs)
            {
                lastResult = func(lastResult);
            }

            return lastResult;
        }

        static int Add(int i, int j)
        {
            return i + j;
        }

        static int AddTen(int i)
        {
            return i + 10;
        }

        static int MultiplyByTwo(int i)
        {
            return i * 2;
        }

        static int DivideByTwo(int i)
        {
            return i / 2;
        }
    }
}
