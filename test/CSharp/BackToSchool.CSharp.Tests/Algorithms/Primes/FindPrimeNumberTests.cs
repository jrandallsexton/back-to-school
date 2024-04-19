using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToSchool.CSharp.Algorithms.Primes;
using FluentAssertions;
using Xunit;

namespace BackToSchool.CSharp.Tests.Algorithms.Primes
{
    public class FindPrimeNumberTests
    {
        [Fact]
        public void Foo()
        {
            var result = FindPrimeNumber.Find(5);

            result.Should().Be(11);
        }

        [Fact]
        public void Foo2()
        {
            var result = FindPrimeNumber.FindNthPrime(5);

            result.Should().Be(11);
        }
    }
}
