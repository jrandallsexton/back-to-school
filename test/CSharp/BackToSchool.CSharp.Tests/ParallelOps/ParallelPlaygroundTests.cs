using BackToSchool.CSharp.ParallelOps;

using FluentAssertions;

using System;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace BackToSchool.CSharp.Tests.ParallelOps
{
    public class ParallelPlaygroundTests(ITestOutputHelper output)
    {
        [Fact]
        public async Task AsyncVsParallel()
        {
            var sut = new ParallelPlayground();

            var asyncTimer = System.Diagnostics.Stopwatch.StartNew();
            await sut.ExecuteAsync();
            asyncTimer.Stop();
            var asyncDuration = asyncTimer.ElapsedMilliseconds;

            var parallelTimer = System.Diagnostics.Stopwatch.StartNew();
            sut.ExecuteParallel();
            parallelTimer.Stop();
            var parallelDuration = parallelTimer.ElapsedMilliseconds;

            parallelDuration.Should().BeLessThan(asyncDuration);

            output.WriteLine($"async:\t{asyncDuration}");
            output.WriteLine($"parallel:\t{parallelDuration}");
        }
    }
}
