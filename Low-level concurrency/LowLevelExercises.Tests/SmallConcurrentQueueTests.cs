using System.Threading;
using NUnit.Framework;
using SmallConcurrentQueue;

namespace LowLevelExercises.Tests
{
    public class SmallConcurrentQueueTests
    {
        [Test]
        public void Load_Test()
        {
            const int count = 1000_000;

            var queue = new SmallConcurrentQueue<int>();

            var publisher = new Thread(() =>
            {
                for (var i = 0; i < count; i++)
                {
                    if (queue.TryEnqueue(i) == false)
                    {
                        // queue is full: dummy fast retry
                        i--;
                    }
                }
            });

            var consumer = new Thread(() =>
            {
                for (var i = 0; i < count; i++)
                {
                    if (queue.TryDequeue(out var value))
                    {
                        Assert.AreEqual(i, value);
                    }
                    else
                    {
                        // queue is empty: dummy fast retry
                        i--;
                    }
                }
            });

            publisher.Start();
            consumer.Start();

            publisher.Join();
            consumer.Join();
        }

        [Test]
        public void Two_Consumers_Dequeue_From_Empty_Queue_Returns_False()
        {
            var queue = new SmallConcurrentQueue<int>();
            var signal = new ManualResetEvent(false);

            var consumer1 = new Thread(() =>
            {
                signal.WaitOne();
                Assert.IsFalse(queue.TryDequeue(out var _));
            });

            var consumer2 = new Thread(() =>
            {
                signal.WaitOne();
                Assert.IsFalse(queue.TryDequeue(out var _));
            });

            consumer1.Start();
            consumer2.Start();

            // signals the threads to start
            signal.Set();

            consumer1.Join();
            consumer2.Join();
        }

        [Test]
        public void Two_Publishers_Cannot_Enqueue_More_Than_Capacity()
        {
            var queue = new SmallConcurrentQueue<int>();
            int successfulEnqueues = 0;

            var publisher1 = new Thread(() =>
            {
                for (int i = 0; i < SmallConcurrentQueue<int>.Size; i++)
                {
                    if (queue.TryEnqueue(i))
                    {
                        Interlocked.Increment(ref successfulEnqueues);
                    }
                }
            });

            var publisher2 = new Thread(() =>
            {
                for (int i = 0; i < SmallConcurrentQueue<int>.Size; i++)
                {
                    if (queue.TryEnqueue(i))
                    {
                        Interlocked.Increment(ref successfulEnqueues);
                    }
                }
            });

            publisher1.Start();
            publisher2.Start();

            publisher1.Join();
            publisher2.Join();

            Assert.AreEqual(SmallConcurrentQueue<int>.Size, successfulEnqueues);
        }


    }
}
