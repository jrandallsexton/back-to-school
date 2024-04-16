using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Linq
{
    /// <summary>
    /// https://www.meziantou.net/getting-all-exceptions-thrown-from-parallel-foreachasync.htm
    /// </summary>
    public static class ParallelExceptions
    {
        public static async Task CatchFirstExceptionOnly()
        {
            try
            {
                // This will throw multiple exception
                await Parallel.ForEachAsync(Enumerable.Range(1, 10), async (i, _) =>
                {
                    throw new Exception(i.ToString());
                });
            }
            catch (Exception ex) // Catch the first exception only, other exceptions are lost
            {
                // Prints a value between 1 and 10 depending on which exception was caught first.
                // Other exceptions are lost.
                Console.WriteLine(ex.ToString());
            }
        }

        public static async Task AggregateExceptions()
        {
            try
            {
                // Use WithAggregateException to get all exceptions
                await Parallel.ForEachAsync(Enumerable.Range(1, 10), async (i, _) =>
                {
                    throw new Exception(i.ToString());
                }).WithAggregateException();
            }
            catch (Exception ex)
            {
                // Prints all exceptions as ex is an AggregateException
                Console.WriteLine(ex.ToString());
            }
        }

        internal static async Task WithAggregateException(this Task task)
        {
            // Disable exception throwing using ConfigureAwaitOptions.SuppressThrowing as it
            // will be handled by `task.Wait()`
            await task.ConfigureAwait(ConfigureAwaitOptions.SuppressThrowing);

            // The task is already completed, so Wait only throws an AggregateException if the task failed
            task.Wait();
        }
    }
}
