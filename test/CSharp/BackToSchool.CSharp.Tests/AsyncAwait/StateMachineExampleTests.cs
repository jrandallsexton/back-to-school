
using BackToSchool.CSharp.AsyncAwait;
using BackToSchool.CSharp.Tests.Misc;

using FluentAssertions;

using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.AsyncAwait
{
    public class StateMachineExampleTests
    {
        private Logger _logger;

        public StateMachineExampleTests(ITestOutputHelper helper)
        {
            _logger = new Logger(helper);
        }

        [Fact]
        public async void MyAsyncMethodTest()
        {
            var sut = new StateMachineExample(_logger);
            var result = await sut.MyAsyncMethod(500, 1000);

            result.Should().Be(42);
        }

        [Fact]
        public async void MyAsyncMethodStateMachineTest()
        {
            var result = await MyAsyncMethod(500, 1000);

            result.Should().Be(42);
        }

        private static Task<int> MyAsyncMethod(int firstDelay, int secondDelay)
        {
            var stateMachine = new MyAsyncMethodStateMachine(firstDelay, secondDelay, 0);
            stateMachine.MoveNext();
            return stateMachine.ResultTask;
        }
    }
}
