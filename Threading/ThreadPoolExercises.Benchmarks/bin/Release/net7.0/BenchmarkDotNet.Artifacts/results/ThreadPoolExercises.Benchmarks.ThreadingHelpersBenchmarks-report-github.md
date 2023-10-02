```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                      | Mean        | Error     | StdDev    |
|---------------------------- |------------:|----------:|----------:|
| ExecuteSynchronously        | 79,644.2 μs | 610.77 μs | 510.02 μs |
| ExecuteOnThread             | 89,168.9 μs | 490.07 μs | 409.23 μs |
| ExecuteOnThreadPool         | 81,603.9 μs | 725.22 μs | 678.37 μs |
| ExecuteOnThreadPool_Tasks   | 79,588.7 μs | 162.07 μs | 151.60 μs |
| M_ExecuteOnThread           |    878.9 μs |  15.29 μs |  21.92 μs |
| M_ExecuteOnThreadPool       |    821.4 μs |  16.07 μs |  26.40 μs |
| M_ExecuteOnThreadPool_Tasks |    832.8 μs |  16.59 μs |  23.80 μs |
