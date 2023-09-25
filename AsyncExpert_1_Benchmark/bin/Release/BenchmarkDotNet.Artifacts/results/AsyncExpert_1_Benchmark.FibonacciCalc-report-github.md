```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT


```
| Method                   | n  | Mean             | Error          | StdDev         | Ratio | Code Size | Allocated | Alloc Ratio |
|------------------------- |--- |-----------------:|---------------:|---------------:|------:|----------:|----------:|------------:|
| **Recursive**                | **15** |      **3,140.45 ns** |      **13.133 ns** |      **11.642 ns** | **1.000** |     **105 B** |         **-** |          **NA** |
| RecursiveWithMemoization | 15 |         18.77 ns |       0.219 ns |       0.183 ns | 0.006 |     983 B |         - |          NA |
| Iterative                | 15 |         10.33 ns |       0.175 ns |       0.163 ns | 0.003 |     152 B |         - |          NA |
|                          |    |                  |                |                |       |           |           |             |
| **Recursive**                | **35** | **47,781,416.08 ns** | **470,394.124 ns** | **392,800.398 ns** | **1.000** |     **105 B** |         **-** |          **NA** |
| RecursiveWithMemoization | 35 |         18.88 ns |       0.143 ns |       0.119 ns | 0.000 |     983 B |         - |          NA |
| Iterative                | 35 |         25.48 ns |       0.390 ns |       0.345 ns | 0.000 |     152 B |         - |          NA |
