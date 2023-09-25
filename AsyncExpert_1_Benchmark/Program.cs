using System;
using System.Reflection;
using BenchmarkDotNet.Running;

namespace AsyncExpert_1_Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
        }
    }
}
