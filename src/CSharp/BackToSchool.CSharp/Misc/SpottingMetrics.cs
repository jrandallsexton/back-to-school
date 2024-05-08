
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using System;
using System.Linq;
using DotNext;

namespace BackToSchool.CSharp.Misc
{
    public class SpottingMetrics
    {
        public static double GetSpottingMetric_StripZeros(int[] results)
        {
            var result = double.MaxValue;

            // couldn't we just strip out all the zeros?
            results = results.ToList().Where(x => x != 0).ToArray();
            var max = results.Length - 3;

            for (var i = 0; i <= max; i++)
            {
                // get each window of 3
                var window = results[i..(3 + i)];
                var windowResult = window.Sum() / 3.00;
                if (windowResult < result)
                {
                    result = windowResult;
                }
            }

            return result;
        }

        public static double GetSpottingMetric_TwoPointers(int[] results, int targetWindowSize)
        {
            // seems to be a two-pointer situation
            // need all recorded "3 successful measurements" (i.e. non-zero)

            var result = double.MaxValue;

            var left = 0;
            var right = 1;
            var windowLength = 0;

            var max = results.Length - targetWindowSize;

            while (left < max)
            {
                // if array value at left is non-zero, begin moving right pointer
                if (results[left] != 0)
                {
                    // begin creating windows of length = targetWindowSize with non-zero elements
                    while (windowLength < targetWindowSize && right < results.Length - 1)
                    {
                        right++;
                        if (results[right] != 0)
                        {
                            windowLength = right - left;
                        }
                    }

                    // we now have a window of length = targetWindowSize
                    // sum it and calculate the average of all values in the window
                    var windowSum = results.AsSpan(left, right - left + 1).ToArray().Sum();
                    var windowResult = windowSum / (double)targetWindowSize;
                    if (windowResult < result)
                    {
                        result = windowResult;
                    }
                }

                // advance the left pointer
                left++;

                // reset the current window length for the next iteration
                windowLength = 0;
            }

            return result;

        }
    

        public static double GetSpottingMetric_TwoPointers_Alt(int[] results, int targetWindowSize)
        {
            // seems to be a two-pointer situation
            // need all recorded "3 successful measurements" (i.e. non-zero)

            var result = double.MaxValue;

            var left = 0;
            var right = 1;
            var windowLength = 0;

            ReadOnlySpan<int> resultsSpan = results.AsSpan();

            var max = resultsSpan.Length - targetWindowSize;

            while (left < max)
            {
                // if array value at left is non-zero, begin moving right pointer
                if (resultsSpan[left] != 0)
                {
                    // begin creating windows of length = targetWindowSize with non-zero elements
                    while (windowLength < targetWindowSize && right < resultsSpan.Length - 1)
                    {
                        right++;
                        if (resultsSpan[right] != 0)
                        {
                            windowLength = right - left;
                        }
                    }

                    // we now have a window of length = targetWindowSize
                    // sum it and calculate the average of all values in the window
                    var tmpSum = 0;
                    var ttSpan = resultsSpan.Slice(left, right - left + 1);
                    foreach (var i in ttSpan)
                    {
                        tmpSum += i;
                    }

                    var windowResult = tmpSum / (double)targetWindowSize;
                    if (windowResult < result)
                    {
                        result = windowResult;
                    }
                }

                // advance the left pointer
                left++;

                // reset the current window length for the next iteration
                windowLength = 0;
            }

            return result;
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SpottingMetricsBenchmarks
    {
        private const int Iterations = 1;
        private const int ArraySize = 100_000;
        private Random rand = new();

        private const int TargetWindowSize = 3;

        [Benchmark(Baseline = true)]
        public void StripZeroes()
        {
            // generate the array
            var values = new int[ArraySize];

            for (var x = 0; x < ArraySize; x++)
            {
                values[x] = rand.Next(0, 9);
            }

            for (var i = 0; i < Iterations; i++)
            {
                SpottingMetrics.GetSpottingMetric_StripZeros(values);
            }
        }

        [Benchmark]
        public void TwoPointers()
        {
            // generate the array
            var values = new int[ArraySize];

            for (var x = 0; x < ArraySize; x++)
            {
                values[x] = rand.Next(0, 9);
            }

            for (var i = 0; i < Iterations; i++)
            {
                SpottingMetrics.GetSpottingMetric_TwoPointers(values, TargetWindowSize);
            }
        }
        [Benchmark]
        public void TwoPointersAlt()
        {
            // generate the array
            var values = new int[ArraySize];

            for (var x = 0; x < ArraySize; x++)
            {
                values[x] = rand.Next(0, 9);
            }

            for (var i = 0; i < Iterations; i++)
            {
                SpottingMetrics.GetSpottingMetric_TwoPointers_Alt(values, TargetWindowSize);
            }
        }
    }
}
