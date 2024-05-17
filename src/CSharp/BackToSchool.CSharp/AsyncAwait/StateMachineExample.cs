using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.AsyncAwait
{
    /// <summary>
    /// https://vkontech.com/exploring-the-async-await-state-machine-conceptual-implementation/
    /// </summary>
    public class StateMachineExample
    {
        private readonly IOutputHelper _outputHelper;

        public StateMachineExample(IOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public async Task<int> MyAsyncMethod(int firstDelay, int secondDelay)
        {
            _outputHelper.WriteLine("Before first await.");

            await Task.Delay(firstDelay);

            _outputHelper.WriteLine("Before second await.");

            await Task.Delay(secondDelay);

            _outputHelper.WriteLine("Done.");

            return 42;
        }
    }

    public class MyAsyncMethodStateMachine
    {
        private readonly TaskCompletionSource<int> _taskBuilder = new TaskCompletionSource<int>();

        private readonly int _firstDelay;
        private readonly int _secondDelay;

        private int _state;
        private TaskAwaiter _awaiter;

        public MyAsyncMethodStateMachine(int firstDelay, int secondDelay, int initialState)
        {
            _firstDelay = firstDelay;
            _secondDelay = secondDelay;
            _state = initialState;
        }

        public void MoveNext()
        {
            try
            {
                if (_state == 0)
                {
                    Console.WriteLine("Before first await.");
                    _state = 1;
                    _awaiter = Task.Delay(_firstDelay).GetAwaiter();
                    if (!_awaiter.IsCompleted)
                    {
                        _awaiter.OnCompleted(MoveNext);
                        return;
                    }
                }

                if (_state == 1)
                {
                    _awaiter.GetResult();
                    Console.WriteLine("Before second await.");
                    _state = 2;
                    _awaiter = Task.Delay(_secondDelay).GetAwaiter();
                    if (!_awaiter.IsCompleted)
                    {
                        _awaiter.OnCompleted(MoveNext);
                        return;
                    }
                }

                Console.WriteLine("Done.");
                _taskBuilder.SetResult(42);
            }
            catch (Exception ex)
            {
                _taskBuilder.SetException(ex);
            }
        }

        public Task<int> ResultTask => _taskBuilder.Task;
    }
}
