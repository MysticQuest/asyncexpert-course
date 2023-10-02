```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                      | Mean         | Error      | StdDev    |
|---------------------------- |-------------:|-----------:|----------:|
| ExecuteSynchronously        |    99.634 ms |  0.2232 ms | 0.1743 ms |
| ExecuteOnThread             |    99.998 ms |  0.6729 ms | 0.6294 ms |
| ExecuteOnThreadPool         |   101.109 ms |  1.2553 ms | 1.1742 ms |
| M_ExecuteSynchronously      | 1,985.619 ms | 10.7953 ms | 9.5698 ms |
| M_ExecuteOnThread           |     7.571 ms |  0.1984 ms | 0.5849 ms |
| M_ExecuteOnThreadPool       |     6.625 ms |  0.1752 ms | 0.5138 ms |
| M_ExecuteOnThreadPool_Tasks |   249.782 ms |  1.0430 ms | 0.9756 ms |
