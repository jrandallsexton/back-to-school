using System;

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
            //BenchmarkRunner.Run<NumberCrunchingBenchmarks>();
            //BenchmarkRunner.Run<SwitchExpressionsBenchmarks>();
            //BenchmarkRunner.Run<SpottingMetricsBenchmarks>();
            //BenchmarkRunner.Run<RomanNumeralConverterBenchmarks>();
            BenchmarkRunner.Run<PhoneNumberWordsBenchmarks>();
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
