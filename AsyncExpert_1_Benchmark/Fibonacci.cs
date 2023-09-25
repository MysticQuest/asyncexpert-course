using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace AsyncExpert_1_Benchmark
{
    [MemoryDiagnoser]
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true)]
    public class FibonacciCalc
    {
        // Objectives:
        // 1. Write implementations for RecursiveWithMemoization and Iterative solutions
        // 2. Add MemoryDiagnoser to the benchmark
        // 3. Run with release configuration and compare results
        // 4. Open disassembler report and compare machine code

        private Dictionary<ulong, ulong> memo = new Dictionary<ulong, ulong>();

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public ulong Recursive(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong RecursiveWithMemoization(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            if (memo.ContainsKey(n)) return memo[n];

            ulong result = RecursiveWithMemoization(n - 1) + RecursiveWithMemoization(n - 2);
            memo[n] = result;
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
