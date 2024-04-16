using BackToSchool.CSharp.Algorithms.Searching;
using BackToSchool.CSharp.DataStructures.Trees;

using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.Algorithms.Searching
{
    public class BfsTests
    {
        private readonly ITestOutputHelper _output;

        public BfsTests(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }

        [Fact]
        public void BfsTest()
        {
            // arrange
            var root = new Node<int>(0);
            for (var i = 1; i < 20; i++)
            {
                root.Add(i);
            }

            var bfs = new Bfs();

            // act
            var result = bfs.GenerateTraversal(root);

            // assert
            Assert.NotNull(result);
            _output.WriteLine(result);
        }
    }
}