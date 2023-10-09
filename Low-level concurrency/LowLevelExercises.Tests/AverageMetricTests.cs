using System.ComponentModel;
using System.Threading;
using LowLevelExercises.Core;
using NUnit.Framework;

namespace LowLevelExercises.Tests
{
    public class AverageMetricTests
    {
        [Test]
        public void Returns_NaN_when_nothing()
        {
            Assert.AreEqual(double.NaN, new AverageMetric().Average);
        }

        [Test]
        public void Returns_Average()
        {
            var metric = new AverageMetric();
            metric.Report(1);
            metric.Report(3);
            Assert.AreEqual(2, metric.Average);
        }

        [Test]
        [NUnit.Framework.Category("Long running")]
        [NUnit.Framework.Category("Threading")]
        public void Eventually_1_returns_value_when_multiple_threads()
        {
            const int threadCount = 8;
            const int spinCount = 1000_000;

            var threads = new Thread[threadCount];
            var wait = new ManualResetEvent(false);

            var metric = new AverageMetric();

            for (var i = 0; i < threadCount; i++)
            {
                var threadNo = i;
                threads[i] = new Thread(() =>
                {
                    wait.WaitOne();

                    for (var j = 0; j < spinCount; j++)
                    {
                        metric.Report(threadNo % 2); // report 0 or 1
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            wait.Set();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual(0.5d, metric.Average);
        }

        [Test]
        [NUnit.Framework.Category("Long running")]
        [NUnit.Framework.Category("Threading")]
        public async Task Eventually_2_returns_value_when_multiple_threads_using_tasks()
        {
            const int TaskCount = 8;
            const int SpinCount = 1000_000;
            const double ExpectedAverage = 0.5d;

            var metric = new AverageMetric();
            var tasks = new Task[TaskCount];

            for (var i = 0; i < TaskCount; i++)
            {
                var taskNo = i;
                tasks[i] = Task.Run(() =>
                {
                    for (var j = 0; j < SpinCount; j++)
                    {
                        metric.Report(taskNo % 2);
                    }
                });
            }

            await Task.WhenAll(tasks);

            Assert.AreEqual(ExpectedAverage, metric.Average);
        }

        [Test]
        [NUnit.Framework.Category("Long running")]
        [NUnit.Framework.Category("Threading")]
        public void Eventually_3_returns_value_when_multiple_threads_using_barrier()
        {
            const int threadCount = 8;
            const int spinCount = 1000_000;
            var threads = new Thread[threadCount];
            var barrier = new Barrier(threadCount + 1); 
            var metric = new AverageMetric();

            for (var i = 0; i < threadCount; i++)
            {
                var threadNo = i;
                threads[i] = new Thread(() =>
                {
                    barrier.SignalAndWait(); 

                    for (var j = 0; j < spinCount; j++)
                    {
                        metric.Report(threadNo % 2);  
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            barrier.SignalAndWait(); 

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual(0.5d, metric.Average);
        }

        [Test]
        [NUnit.Framework.Category("Long running")]
        [NUnit.Framework.Category("Threading")]
        public void Eventually_4_returns_value_when_multiple_threads_using_countdown()
        {
            const int threadCount = 8;
            const int spinCount = 1000_000;
            var threads = new Thread[threadCount];
            var countdown = new CountdownEvent(threadCount);
            var metric = new AverageMetric();

            for (var i = 0; i < threadCount; i++)
            {
                var threadNo = i;
                threads[i] = new Thread(() =>
                {
                    countdown.Signal();
                    countdown.Wait();  

                    for (var j = 0; j < spinCount; j++)
                    {
                        metric.Report(threadNo % 2); 
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            countdown.Wait();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual(0.5d, metric.Average);
        }

        [Test]
        [NUnit.Framework.Category("Long running")]
        [NUnit.Framework.Category("Threading")]
        public void Eventually_5_returns_value_when_multiple_threads_SLIM()
        {
            const int threadCount = 8;
            const int spinCount = 1000_000;

            var threads = new Thread[threadCount];
            var wait = new ManualResetEventSlim(false);

            var metric = new AverageMetric();

            for (var i = 0; i < threadCount; i++)
            {
                var threadNo = i;
                threads[i] = new Thread(() =>
                {
                    wait.Wait();

                    for (var j = 0; j < spinCount; j++)
                    {
                        metric.Report(threadNo % 2);
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            wait.Set();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.AreEqual(0.5d, metric.Average);
        }

    }
}
