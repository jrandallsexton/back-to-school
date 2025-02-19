using BackToSchool.CSharp.Params;

using FluentAssertions;

using Xunit;

namespace BackToSchool.CSharp.Tests.Params
{
    public class ParamsPlaygroundTests
    {
        [Fact]
        public void Foo()
        {
            var sut = new ParamsPlayground();

            var a = 1;
            var b = 2;

            var result = sut.Add(a, b);

            result.Should().Be(3);

            result = sut.AddByRef(ref a, ref b);

            result.Should().Be(3);

            var cmd = new ParamsPlayground.ParamsPlaygroundCommand()
            {
                A = a,
                B = b
            };
            result = sut.Add(cmd);

            result.Should().Be(3);
        }
    }
}
