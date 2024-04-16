using BackToSchool.CSharp.Algorithms.Searching;
using BackToSchool.CSharp.DataStructures.Trees;

using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.Algorithms.Searching
{
    public class DfsTests
    {
        private readonly ITestOutputHelper _output;

        public DfsTests(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }

        [Fact]
        public void DfsTest()
        {
            // arrange
            var root = new Node<int>(0);
            for (var i = 1; i < 20; i++)
            {
                root.Add(i);
            }

            var dfs = new DFS();

            // act
            dfs.GenerateTraversal(root);
            var result = dfs.Logs;

            // assert
            _output.WriteLine(result.ToString());
        }
    }
}
