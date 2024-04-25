using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToSchool.CSharp.Misc;
using Xunit;

namespace BackToSchool.CSharp.Tests.Misc
{
    /// <summary>
    /// This test class includes 10 tests.
    /// All have the same score.
    /// You are not allowed to modify this file,
    /// but feel free to read the source code
    /// to better understand the details of all test cases.
    /// </summary>
    [Collection("ContainerTests")]
    [TestCaseOrderer(
      "Container.Tests.Orderers.AlphabeticalOrderer",
      "Container.Tests"
    )]
    public class ContainerTests
    {
        private readonly IContainer _container;

        public ContainerTests()
        {
            _container = new Container();
        }

        /// <summary>
        /// Add 1, 2, 5, 7, 9 -> [1, 2, 5, 7, 9]
        /// Median of [1, 2, 5, 7, 9] is 5
        /// Add 3, 4 -> [1, 2, 3, 4, 5, 7, 9]
        /// Median of [1, 2, 3, 4, 5, 7, 9] is 4
        /// </summary>
        [Fact(DisplayName = "Test simple get odd length")]
        public void Test_01_SimpleGetOddLength()
        {
            Utility.CheckTimeout(() => {
                _container.Add(1);
                _container.Add(2);
                _container.Add(5);
                _container.Add(7);
                _container.Add(9);
                Assert.Equal(5, _container.GetMedian());
                _container.Add(3);
                _container.Add(4);
                Assert.Equal(4, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 30, 10 -> [10, 30]
        /// Median of [10, 30] is 10
        /// Add 12, 35 -> [10, 12, 30, 35]
        /// Median of [10, 12, 30, 35] is 12
        /// Double check of median
        /// Add 11, 40, 100, 90 -> [10, 11, 12, 30, 35, 40, 90, 100]
        /// Median of [10, 11, 12, 30, 35, 40, 90, 100] is 30
        /// </summary>
        [Fact(DisplayName = "Test simple get even length")]
        public void Test_02_SimpleGetEvenLength()
        {
            Utility.CheckTimeout(() => {
                _container.Add(30);
                _container.Add(10);
                Assert.Equal(10, _container.GetMedian());
                _container.Add(12);
                _container.Add(35);
                Assert.Equal(12, _container.GetMedian());
                Assert.Equal(12, _container.GetMedian());
                _container.Add(11);
                _container.Add(40);
                _container.Add(100);
                _container.Add(90);
                Assert.Equal(30, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Median of [] does not exist
        /// Double check of median
        /// Add 1 -> [1]
        /// Median of [1] is 1
        /// Add 3, 4, 2, 10, 30 -> [1, 2, 3, 4, 10, 30]
        /// Median of [1, 2, 3, 4, 10, 30] is 3
        /// Add 52, 53, 54, 55 -> [1, 2, 3, 4, 10, 30, 52, 53, 54, 55]
        /// Median of [1, 2, 3, 4, 10, 30, 52, 53, 54, 55] is 10
        /// Add 6, 7, 8, 9 -> [1, 2, 3, 4, 6, 7, 8, 9, 10, 30, 52, 53, 54, 55]
        /// Median of [1, 2, 3, 4, 6, 7, 8, 9, 10, 30, 52, 53, 54, 55] is 8
        /// Add 11 -> [1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 30, 52, 53, 54, 55]
        /// Median of [1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 30, 52, 53, 54, 55] is 9
        /// </summary>
        [Fact(DisplayName = "Test simple mixed add and get")]
        public void Test_03_SimpleMixedAddAndGet()
        {
            Utility.CheckTimeout(() => {
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
                _container.Add(1);
                Assert.Equal(1, _container.GetMedian());
                _container.Add(3);
                _container.Add(4);
                _container.Add(2);
                _container.Add(10);
                _container.Add(30);
                Assert.Equal(3, _container.GetMedian());
                _container.Add(52);
                _container.Add(53);
                _container.Add(54);
                _container.Add(55);
                Assert.Equal(10, _container.GetMedian());
                _container.Add(6);
                _container.Add(7);
                _container.Add(8);
                _container.Add(9);
                Assert.Equal(8, _container.GetMedian());
                _container.Add(11);
                Assert.Equal(9, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 1, 2, 3, 4, 5, 5, 5 -> [1, 2, 3, 4, 5, 5, 5]
        /// Median of [1, 2, 3, 4, 5, 5, 5] is 4
        /// Add 2 -> [1, 2, 2, 3, 4, 5, 5, 5]
        /// Median of [1, 2, 2, 3, 4, 5, 5, 5] is 3
        /// Add 3 -> [1, 2, 2, 3, 3, 4, 5, 5, 5]
        /// Median of [1, 2, 2, 3, 3, 4, 5, 5, 5] is 3
        /// Add 5, 5 -> [1, 2, 2, 3, 3, 4, 5, 5, 5, 5, 5]
        /// Median of [1, 2, 2, 3, 3, 4, 5, 5, 5, 5, 5] is 4
        /// </summary>
        [Fact(DisplayName = "Test repetitions 1")]
        public void Test_04_Repetitions1()
        {
            Utility.CheckTimeout(() => {
                _container.Add(1);
                _container.Add(2);
                _container.Add(3);
                _container.Add(4);
                _container.Add(5);
                _container.Add(5);
                _container.Add(5);
                Assert.Equal(4, _container.GetMedian());
                _container.Add(2);
                Assert.Equal(3, _container.GetMedian());
                _container.Add(3);
                Assert.Equal(3, _container.GetMedian());
                _container.Add(5);
                _container.Add(5);
                Assert.Equal(4, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 20 items of 42 -> [42] * 20
        /// Median of [42] * 20 is 42
        /// Add 0, 1, 2, ..., 29 -> [0, 1, ..., 29] + [42] * 20
        /// Median of [0, 1, ..., 29] + [42] * 20 is 24
        /// Add 50 items of 130 -> [0, 1, ..., 29] + [42] * 20 + [130] * 50
        /// Median of [0, 1, ..., 29] + [42] * 20 + [130] * 50 is 42
        /// Add 50 items of 170 -> [0, 1, ..., 29] + [42] * 20 +
        ///                        [130] * 50 + [170] * 50
        /// Median of [0, 1, ..., 29] + [42] * 20 + [130] * 50 + [170] * 50 is 130
        /// </summary>
        [Fact(DisplayName = "Test repetitions 2")]
        public void Test_05_Repetitions2()
        {
            Utility.CheckTimeout(() => {
                for (var i = 0; i < 20; ++i)
                {
                    _container.Add(42);
                }
                Assert.Equal(42, _container.GetMedian());
                for (var i = 0; i < 30; ++i)
                {
                    _container.Add(i);
                }
                Assert.Equal(24, _container.GetMedian());
                for (var i = 0; i < 50; ++i)
                {
                    _container.Add(130);
                }
                Assert.Equal(42, _container.GetMedian());
                for (var i = 0; i < 50; ++i)
                {
                    _container.Add(170);
                }
                Assert.Equal(130, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 10, 20, 30 -> [10, 20, 30]
        /// Delete 20 -> [10, 30]
        /// Median of [10, 30] is 10
        /// Add 5 -> [5, 10, 30]
        /// Median of [5, 10, 30] is 10
        /// Delete 30 -> [5, 10]
        /// Median of [5, 10] is 5
        /// </summary>
        [Fact(DisplayName = "Test simple deletes 1")]
        public void Test_06_SimpleDeletes1()
        {
            Utility.CheckTimeout(() => {
                _container.Add(10);
                _container.Add(20);
                _container.Add(30);
                Assert.True(_container.Delete(20));
                Assert.Equal(10, _container.GetMedian());
                _container.Add(5);
                Assert.Equal(10, _container.GetMedian());
                Assert.True(_container.Delete(30));
                Assert.Equal(5, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Median of [] does not exist
        /// Delete 5 -> []
        /// Median of [] does not exist
        /// Delete 5 -> []
        /// Add 5 -> [5]
        /// Median of [5] is 5
        /// Delete 5 -> []
        /// Median of [] does not exist
        /// Delete 5 -> []
        /// Add 5, 4, 3 -> [3, 4, 5]
        /// Median of [3, 4, 5] is 4
        /// Delete 5 -> [3, 4]
        /// Median of [3, 4] is 3
        /// Delete 5 -> [3, 4]
        /// Delete 3 -> [4]
        /// Median of [4] is 4
        /// </summary>
        [Fact(DisplayName = "Test simple deletes 2")]
        public void Test_07_SimpleDeletes2()
        {
            Utility.CheckTimeout(() => {
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
                Assert.False(_container.Delete(5));
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
                Assert.False(_container.Delete(5));
                _container.Add(5);
                Assert.Equal(5, _container.GetMedian());
                Assert.True(_container.Delete(5));
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
                Assert.False(_container.Delete(5));
                _container.Add(5);
                _container.Add(4);
                _container.Add(3);
                Assert.Equal(4, _container.GetMedian());
                Assert.True(_container.Delete(5));
                Assert.Equal(3, _container.GetMedian());
                Assert.False(_container.Delete(5));
                Assert.True(_container.Delete(3));
                Assert.Equal(4, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 3, 30, 30, 15 -> [3, 15, 30, 30]
        /// Median of [3, 15, 30, 30] is 15
        /// Delete 30 -> [3, 15, 30]
        /// Median of [3, 15, 30] is 15
        /// Delete 30 -> [3, 15]
        /// Median of [3, 15] is 3
        /// Add 30, 30, 30 -> [3, 15, 30, 30, 30]
        /// Median of [3, 15, 30, 30, 30] is 30
        /// Add 15 -> [3, 15, 15, 30, 30, 30]
        /// Median of [3, 15, 15, 30, 30, 30] is 15
        /// Delete 20 -> [3, 15, 15, 30, 30, 30]
        /// Delete 3 -> [15, 15, 30, 30, 30]
        /// Median of [15, 15, 30, 30, 30] is 30
        /// </summary>
        [Fact(DisplayName = "Test repetitions and deletes")]
        public void Test_08_RepetitionsAndDeletes()
        {
            Utility.CheckTimeout(() => {
                _container.Add(3);
                _container.Add(30);
                _container.Add(30);
                _container.Add(15);
                Assert.Equal(15, _container.GetMedian());
                Assert.True(_container.Delete(30));
                Assert.Equal(15, _container.GetMedian());
                Assert.True(_container.Delete(30));
                Assert.Equal(3, _container.GetMedian());
                _container.Add(30);
                _container.Add(30);
                _container.Add(30);
                Assert.Equal(30, _container.GetMedian());
                _container.Add(15);
                Assert.Equal(15, _container.GetMedian());
                Assert.False(_container.Delete(20));
                Assert.True(_container.Delete(3));
                Assert.Equal(30, _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 5, 3, 5, 7, 8, 9 -> [3, 5, 5, 7, 8, 9]
        /// Median of [3, 5, 5, 7, 8, 9] is 5
        /// Delete 5, 8 -> [3, 5, 7, 9]
        /// Median of [3, 5, 7, 9] is 5
        /// Delete 5, 5 -> [3, 7, 9]
        /// Median of [3, 7, 9] is 7
        /// Add 5 -> [3, 5, 7, 9]
        /// Median of [3, 5, 7, 9] is 5
        /// Delete 5, 5, 7, 3 -> [9]
        /// Median of [9] is 9
        /// Delete 9 -> []
        /// Median of [] does not exist
        /// Delete 9 -> []
        /// Median of [] does not exist
        /// </summary>
        [Fact(DisplayName = "Test mixed operations 1")]
        public void Test_09_MixedOperations1()
        {
            Utility.CheckTimeout(() => {
                _container.Add(5);
                _container.Add(3);
                _container.Add(5);
                _container.Add(7);
                _container.Add(8);
                _container.Add(9);
                Assert.Equal(5, _container.GetMedian());
                Assert.True(_container.Delete(5));
                Assert.True(_container.Delete(8));
                Assert.Equal(5, _container.GetMedian());
                Assert.True(_container.Delete(5));
                Assert.False(_container.Delete(5));
                Assert.Equal(7, _container.GetMedian());
                _container.Add(5);
                Assert.Equal(5, _container.GetMedian());
                Assert.True(_container.Delete(5));
                Assert.False(_container.Delete(5));
                Assert.True(_container.Delete(7));
                Assert.True(_container.Delete(3));
                Assert.Equal(9, _container.GetMedian());
                Assert.True(_container.Delete(9));
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
                Assert.False(_container.Delete(9));
                Assert.ThrowsAny<Exception>(() => _container.GetMedian());
            }, 100);
        }

        /// <summary>
        /// Add 0, 0, 1, 1, 2, 2, ..., 99, 99 -> [0, 0, 1, 1, ..., 99, 99]
        /// Median of [0, 0, 1, 1, ..., 99, 99] is 49
        /// Delete 3 items of i, median is 50 + i / 2, i in [0, 1, ..., 49]
        /// Container's integers are [50, 50, 51, 51, ..., 99, 99] now
        /// Delete 0, 1, 2, ..., 99 -> [50, 51, ..., 99]
        /// Median of [50, 51, ..., 99] is 74
        /// </summary>
        [Fact(DisplayName = "Test mixed operations 2")]
        public void Test_10_MixedOperations2()
        {
            Utility.CheckTimeout(() => {
                for (var i = 0; i < 100; ++i)
                {
                    _container.Add(i);
                    _container.Add(i);
                }
                Assert.Equal(49, _container.GetMedian());
                int[] answers = {
          50, 50, 51, 51, 52, 52, 53, 53, 54, 54, 55, 55, 56,
          56, 57, 57, 58, 58, 59, 59, 60, 60, 61, 61, 62, 62,
          63, 63, 64, 64, 65, 65, 66, 66, 67, 67, 68, 68, 69,
          69, 70, 70, 71, 71, 72, 72, 73, 73, 74, 74
        };
                for (var i = 0; i < 50; ++i)
                {
                    Assert.True(_container.Delete(i));
                    Assert.True(_container.Delete(i));
                    Assert.False(_container.Delete(i));
                    Assert.Equal(answers[i], _container.GetMedian());
                }

                for (var i = 0; i < 100; ++i)
                {
                    Assert.Equal(_container.Delete(i), i >= 50);
                }
                Assert.Equal(74, _container.GetMedian());
            }, 100);
        }
    }

    public static class Utility
    {
        public static void CheckTimeout(Action func, int timeInMilliseconds)
        {
            Task task = Task.Run(func);
            bool completedInTime = false;
            try
            {
                completedInTime = task.Wait(
                    TimeSpan.FromMilliseconds(timeInMilliseconds)
                );
            }
            catch
            {
                throw task.Exception.InnerExceptions[0];
            }

            if (!completedInTime)
            {
                throw new TimeoutException(
                    "The method failed to execute within a timeout of " +
                    timeInMilliseconds.ToString() + "ms"
                );
            }
        }
    }
}
