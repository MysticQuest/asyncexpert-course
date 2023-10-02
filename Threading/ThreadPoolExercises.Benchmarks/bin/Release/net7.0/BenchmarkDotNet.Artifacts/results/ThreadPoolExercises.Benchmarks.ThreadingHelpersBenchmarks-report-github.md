```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                      | Mean        | Error     | StdDev    |
|---------------------------- |------------:|----------:|----------:|
| ExecuteSynchronously        | 5,007.43 ms | 18.997 ms | 16.840 ms |
| ExecuteOnThread             | 4,989.82 ms | 14.250 ms | 13.330 ms |
| ExecuteOnThreadPool         | 4,988.54 ms | 26.619 ms | 23.597 ms |
| ExecuteOnThreadPool_Tasks   | 4,952.91 ms | 16.430 ms | 13.720 ms |
| M_ExecuteSynchronously      |   198.78 ms |  0.850 ms |  0.795 ms |
| M_ExecuteOnThread           |    41.65 ms |  0.669 ms |  0.522 ms |
| M_ExecuteOnThreadPool       |    29.16 ms |  0.221 ms |  0.206 ms |
| M_ExecuteOnThreadPool_Tasks |    28.35 ms |  0.348 ms |  0.308 ms |
