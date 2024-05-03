using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackToSchool.CSharp.Delegates;
using FluentAssertions;
using Xunit;

namespace BackToSchool.CSharp.Tests.Delegates
{
    public class DelegatePlaygroundTests
    {
        [Fact]
        public void DelegatePlayground()
        {
            // arrange
            var sut = new DelegatePlayground();

            // act
            var result = sut.TestMethodViaDelegate("foo");

            // assert
            result.Should().Be("From delegate invocation: foo");
        }
    }
}
