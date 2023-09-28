```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                      | Mean         | Error     | StdDev     |
|---------------------------- |-------------:|----------:|-----------:|
| ExecuteSynchronously        |     5.065 ms | 0.0484 ms |  0.0453 ms |
| ExecuteOnThread             |     5.203 ms | 0.0451 ms |  0.0400 ms |
| ExecuteOnThreadPool         |     5.009 ms | 0.0066 ms |  0.0055 ms |
| M_ExecuteSynchronously      | 1,003.176 ms | 1.4462 ms |  1.2821 ms |
| M_ExecuteOnThread           |    53.470 ms | 5.0082 ms | 14.7667 ms |
| M_ExecuteOnThreadPool       |    42.462 ms | 3.5998 ms | 10.5575 ms |
| M_ExecuteOnThreadPool_Tasks |    56.061 ms | 4.3294 ms | 12.6974 ms |
