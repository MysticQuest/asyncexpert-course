using System;
using System.Runtime.CompilerServices;

namespace AwaitableExercises.Core
{
    public static class BoolExtensions
    {
        public static BoolAwaiter GetAwaiter(this bool boolValue)
        {
            return new BoolAwaiter(boolValue);
        }
    }

    public class BoolAwaiter : INotifyCompletion
    {
        private readonly bool _boolValue;

        internal BoolAwaiter(bool boolValue)
        {
            _boolValue = boolValue;
        }

        public bool IsCompleted => _boolValue;
        public void OnCompleted(Action continuation)
        {
            try
            {
                continuation();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool GetResult() => _boolValue;
    }
}
