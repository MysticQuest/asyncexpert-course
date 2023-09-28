```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                      | Mean         | Error     | StdDev    |
|---------------------------- |-------------:|----------:|----------:|
| ExecuteSynchronously        |    99.154 ms | 0.7835 ms | 0.7329 ms |
| ExecuteOnThread             |    98.458 ms | 0.1713 ms | 0.1431 ms |
| ExecuteOnThreadPool         |    98.983 ms | 0.8591 ms | 0.8036 ms |
| M_ExecuteSynchronously      | 1,984.434 ms | 7.8068 ms | 7.3025 ms |
| M_ExecuteOnThread           |     9.502 ms | 0.3817 ms | 1.1254 ms |
| M_ExecuteOnThreadPool       |     8.091 ms | 0.3967 ms | 1.1697 ms |
| M_ExecuteOnThreadPool_Tasks |   243.593 ms | 0.9209 ms | 0.8615 ms |
