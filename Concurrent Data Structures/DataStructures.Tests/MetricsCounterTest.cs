using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DataStructures.Tests
{
    [TestFixture(typeof(LockingMetricsCounter))]
    [TestFixture(typeof(ConcurrentDictionaryWithCounterMetricsCounter))]
    [TestFixture(typeof(ConcurrentDictionaryOnlyMetricsCounter))]
    public class MetricsCounterTest<TMetricCounter>
        where TMetricCounter : IMetricsCounter, new()
    {
        const int KeyCount = 16;
        const int ValueCount = 1000000;
        const int ConcurrentWriters = 2;

        [Test]
        public async Task CountingTest()
        {
            string[] originalKeys = Enumerable.Range(0, KeyCount).Select(i => i.ToString()).ToArray();
            string[] keys = Enumerable.Repeat(originalKeys, ConcurrentWriters).SelectMany(m => m).ToArray();

            var starterTCS = new TaskCompletionSource<object>();
            var counter = new TMetricCounter();

            // run two tasks per key
            Task[] tasks = keys.Select(key => Task.Run(async () =>
            {
                await starterTCS.Task;
                for (var i = 0; i < ValueCount; i++)
                {
                    counter.Increment(key);
                }
            })).ToArray();

            // start it
            starterTCS.SetResult(starterTCS);
            await Task.WhenAll(tasks).ConfigureAwait(false);

            // assert
            var toObserve = new HashSet<string>(keys);

            foreach (var (key, count) in counter)
            {
                Assert.AreEqual(ValueCount * ConcurrentWriters, count);
                Assert.IsTrue(toObserve.Remove(key), "A key that does not exist!");
            }

            CollectionAssert.IsEmpty(toObserve);

            foreach (var (key, count) in counter)
            {
                TestContext.WriteLine($"{key}: {count}");
            }
        }
    }
}