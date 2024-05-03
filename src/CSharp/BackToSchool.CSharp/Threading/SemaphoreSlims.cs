
using System.Threading;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Threading
{
    public class SemaphoreSlims(IOutputHelper outputHelper)
    {
        private readonly SemaphoreSlim _gate = new(1);

        public async Task Gatekeeper()
        {
            for (var i = 0; i < 10; i++)
            {
                outputHelper.WriteLine("Start");
                await _gate.WaitAsync();
                outputHelper.WriteLine("Do some work ...");
                _gate.Release();
                outputHelper.WriteLine("Finish");
            }
        }
    }
}