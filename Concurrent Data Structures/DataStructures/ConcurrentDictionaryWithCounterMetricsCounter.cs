using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace DataStructures
{
    public class ConcurrentDictionaryWithCounterMetricsCounter : IMetricsCounter
    {
        readonly ConcurrentDictionary<string, AtomicCounter> counters = new();

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            foreach (var kvp in counters)
                yield return new KeyValuePair<string, int>(kvp.Key, kvp.Value.Count);
        }

        // Avoids dictionary lock-based operations and lamda overhead, compared to ConcurrentDictionaryOnlyMetricsCounter
        public void Increment(string key)
        {
            var atomicCounter = counters.GetOrAdd(key, k => new AtomicCounter());
            atomicCounter.Increment();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public class AtomicCounter
        {
            int value;

            public void Increment() => Interlocked.Increment(ref value);

            public int Count => Volatile.Read(ref value);
        }
    }
}
