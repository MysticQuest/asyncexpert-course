using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace AsyncExpert_1_Benchmark
{
    [MemoryDiagnoser]
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true)]
    public class FibonacciCalc
    {
        private Dictionary<ulong, ulong> memo1 = new Dictionary<ulong, ulong>();
        List<ulong> memo2;

        public FibonacciCalc()
        {
            const ulong maxN = 35;
            memo2 = new List<ulong>(new ulong[maxN + 1]);
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public ulong Recursive(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong RecursiveWithMemoizationDict(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            if (memo1.ContainsKey(n)) return memo1[n];

            ulong result = RecursiveWithMemoizationDict(n - 1) + RecursiveWithMemoizationDict(n - 2);
            memo1[n] = result;
            return result;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong RecursiveWithMemoizationList(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            if (memo2[(int)n] != 0) return memo2[(int)n];

            ulong result = RecursiveWithMemoizationList(n - 1) + RecursiveWithMemoizationList(n - 2);
            memo2[(int)n] = result; 
            return result;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong Iterative(ulong n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            ulong a = 0;
            ulong b = 1;

            for (ulong i = 2; i <= n; i++)
            {
                ulong temp = a + b;
                a = b;
                b = temp;
            }

            return b;
        }

        public IEnumerable<ulong> Data()
        {
            yield return 15;
            yield return 35;
        }
    }
}
