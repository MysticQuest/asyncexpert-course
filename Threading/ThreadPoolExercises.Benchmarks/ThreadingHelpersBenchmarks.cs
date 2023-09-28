using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using ThreadPoolExercises.Core;

namespace ThreadPoolExercises.Benchmarks
{
    public class ThreadingHelpersBenchmarks
    {
        private SHA256 sha256 = SHA256.Create();
        private ConcurrentBag<byte[]> dataChunks;

        [GlobalSetup]
        public void Setup()
        {
            dataChunks = new ConcurrentBag<byte[]>();

            for (int i = 0; i < 100; i++)
            {
                byte[] chunk = new byte[10000000];
                new Random(42 + i).NextBytes(chunk);
                dataChunks.Add(chunk);
            }
        }

        [Benchmark]
        public void ExecuteSynchronously()
        {
            foreach (var chunk in dataChunks)
            {
                sha256.ComputeHash(chunk);
            }
        }

        [Benchmark]
        public void ExecuteOnThread()
        {
            ThreadingHelpers.ExecuteOnThread(() =>
            {
                Parallel.ForEach(dataChunks, chunk =>
                {
                    sha256.ComputeHash(chunk);
                });
            }, 1);
        }

        [Benchmark]
        public void ExecuteOnThreadPool()
        {
            ThreadingHelpers.ExecuteOnThreadPool(() =>
            {
                Parallel.ForEach(dataChunks, chunk =>
                {
                    sha256.ComputeHash(chunk);
                });
            }, 1);
        }

        [Benchmark]
        public async Task ExecuteOnThreadPool_Tasks()
        {
            await ThreadingHelpers.ExecuteOnThreadPool_Tasks(() =>
            {
                Parallel.ForEach(dataChunks, chunk =>
                {
                    sha256.ComputeHash(chunk);
                });
            }, 1);
        }
    }
}
