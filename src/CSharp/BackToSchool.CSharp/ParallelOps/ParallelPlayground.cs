using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.ParallelOps
{
    public class ParallelPlayground
    {
        public async Task ExecuteAsync()
        {
            var tasks = new List<Task>();
            for (var i = 0; i < 100_000; i++)
            {
                tasks.Add(Task.Run(SomeCpuBoundOperation));
            }
            await Task.WhenAll(tasks);
        }

        public void ExecuteParallel()
        {
            Parallel.For(0, 10_000, i =>
            {
                SomeCpuBoundOperation();
            });
        }

        private void SomeCpuBoundOperation()
        {
            var x = 0;
            for (var i = 0; i < 10_000; i++)
            { // Increased from 100
                for (var j = 0; j < 1_000; j++)
                { // Increased from 10
                    x += i + j;
                }
            }
        }
    }
}
