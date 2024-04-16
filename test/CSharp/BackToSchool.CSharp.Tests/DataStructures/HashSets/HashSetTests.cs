using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.DataStructures.HashSets
{
    public class HashSetTests
    {
        private readonly ITestOutputHelper _output;

        public HashSetTests(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }

        [Fact]
        public void OddsEvens()
        {
            // arrange
            var hs = new CSharp.DataStructures.HashSets.HashSets();

            // act
            var result = hs.OddEvensMerge(10);

            // assert
            foreach (var e in result)
            {
                _output.WriteLine(e.ToString());
            }
        }
    }
}
