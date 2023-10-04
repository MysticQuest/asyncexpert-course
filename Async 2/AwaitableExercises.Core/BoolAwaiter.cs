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

        public BoolAwaiter(bool boolValue)
        {
            _boolValue = boolValue;
        }

        public bool IsCompleted => _boolValue;
        public void OnCompleted(Action continuation)
        {
            continuation();
        }
        public bool GetResult() => _boolValue;
    }
}
