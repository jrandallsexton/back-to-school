using System;
using BackToSchool.CSharp.Misc;

using BenchmarkDotNet.Running;

namespace BackToSchool.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BinaryPatternMatchingBenchmarks>();
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
