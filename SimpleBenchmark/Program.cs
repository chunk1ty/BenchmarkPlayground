using System;
using BenchmarkDotNet.Running;

namespace SimpleBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
