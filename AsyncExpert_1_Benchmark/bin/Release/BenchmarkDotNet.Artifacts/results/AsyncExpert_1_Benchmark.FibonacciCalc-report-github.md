```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT


```
| Method                       | n  | Mean              | Error           | StdDev         | Ratio | Code Size | Allocated | Alloc Ratio |
|----------------------------- |--- |------------------:|----------------:|---------------:|------:|----------:|----------:|------------:|
| **Recursive**                    | **15** |      **3,145.722 ns** |       **5.4512 ns** |      **4.8323 ns** | **1.000** |     **105 B** |         **-** |          **NA** |
| RecursiveWithMemoizationDict | 15 |         16.346 ns |       0.0717 ns |      0.0599 ns | 0.005 |     983 B |         - |          NA |
| RecursiveWithMemoizationList | 15 |          1.563 ns |       0.0265 ns |      0.0248 ns | 0.000 |     364 B |         - |          NA |
| Iterative                    | 15 |         10.592 ns |       0.3309 ns |      0.4530 ns | 0.003 |     152 B |         - |          NA |
|                              |    |                   |                 |                |       |           |           |             |
| **Recursive**                    | **35** | **47,812,172.078 ns** | **100,384.3651 ns** | **88,988.1250 ns** | **1.000** |     **105 B** |         **-** |          **NA** |
| RecursiveWithMemoizationDict | 35 |         16.311 ns |       0.0741 ns |      0.0619 ns | 0.000 |     983 B |         - |          NA |
| RecursiveWithMemoizationList | 35 |          1.543 ns |       0.0435 ns |      0.0363 ns | 0.000 |     364 B |         - |          NA |
| Iterative                    | 35 |         25.292 ns |       0.3890 ns |      0.3037 ns | 0.000 |     152 B |         - |          NA |
