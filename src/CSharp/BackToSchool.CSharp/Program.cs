﻿using System;

using BackToSchool.CSharp.Algorithms.Summations;
using BackToSchool.CSharp.Linq;
using BackToSchool.CSharp.Misc;

using BenchmarkDotNet.Running;

namespace BackToSchool.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<BinaryPatternMatchingBenchmarks>();
            //BenchmarkRunner.Run<LazyEnumerableBenchmarks>();
            //BenchmarkRunner.Run<YieldingBenchmarks>();
            BenchmarkRunner.Run<NumberCrunchingBenchmarks>();
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
