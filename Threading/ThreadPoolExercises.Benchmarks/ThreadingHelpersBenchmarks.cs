using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using ThreadPoolExercises.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ThreadPoolExercises.Benchmarks
{
    public class ThreadingHelpersBenchmarks
    {
        private SHA256 sha256 = SHA256.Create();

        private byte[] data = new byte[100000];
        private ConcurrentBag<byte[]> dataChunks = new ConcurrentBag<byte[]>();
        private byte[] chunk = new byte[100000];

        public ThreadingHelpersBenchmarks()
        {
            Setup();
        }

        [GlobalSetup]
        public void Setup()
        {
            new Random(42).NextBytes(data);

            for (int i = 0; i < 20; i++)
            {
                new Random(42 + i).NextBytes(chunk);
                dataChunks.Add(chunk);
            }
        }

        [Benchmark]
        public void ExecuteSynchronously() 
        {
            for (int i = 0; i < 100; i++)
            {
                sha256.ComputeHash(data);
            }
        }

        [Benchmark]
        public void ExecuteOnThread()
        {
            ThreadingHelpers.ExecuteOnThread(() => sha256.ComputeHash(data), 100);
        }

        [Benchmark]
        public void ExecuteOnThreadPool()
        {
            ThreadingHelpers.ExecuteOnThreadPool(() => sha256.ComputeHash(data), 100);
        }

        [Benchmark]
        public async Task ExecuteOnThreadPool_Tasks()
        {
            await ThreadingHelpers.ExecuteOnThreadPool_Tasks(() => sha256.ComputeHash(data), 100);
        }

        [Benchmark]
        public void M_ExecuteSynchronously()
        {
            for (int i = 0; i < 100; i++)
            {
                foreach (var chunk in dataChunks)
                {
                    sha256.ComputeHash(chunk);
                }
            }
        }

        [Benchmark]
        public void M_ExecuteOnThread()
        {
            ThreadingHelpers.ExecuteOnThread(() =>
            {
                Parallel.ForEach(dataChunks, chunk =>
                {
                    sha256.ComputeHash(chunk);
                });
            }, 100);
        }

        [Benchmark]
        public void M_ExecuteOnThreadPool()
        {
            ThreadingHelpers.ExecuteOnThreadPool(() =>
            {
                Parallel.ForEach(dataChunks, chunk =>
                {
                    sha256.ComputeHash(chunk);
                });
            }, 100);
        }

        [Benchmark]
        public async Task M_ExecuteOnThreadPool_Tasks()
        {
            await ThreadingHelpers.ExecuteOnThreadPool_Tasks(() =>
            {
                Parallel.ForEach(dataChunks, chunk =>
                {
                    sha256.ComputeHash(chunk);
                });
            }, 100);
        }
    }
}
