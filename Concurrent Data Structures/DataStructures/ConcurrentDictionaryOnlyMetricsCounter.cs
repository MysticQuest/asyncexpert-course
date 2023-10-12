using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace DataStructures
{
    public class ConcurrentDictionaryOnlyMetricsCounter : IMetricsCounter
    {
        // Implement this class using only ConcurrentDictionary.
        // Use methods that change the state atomically to ensure that everything is counted properly.
        // This task does not require using any Interlocked, or Volatile methods. The only required API is provided by the ConcurrentDictionary

        readonly ConcurrentDictionary<string, int> counters = new ConcurrentDictionary<string, int>();

        public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public void Increment(string key)
        {
            if (counters.TryGetValue(key, out var counter))
            {
                counters.TryUpdate(key, counter + 1, counter);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}