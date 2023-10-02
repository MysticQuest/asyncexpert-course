```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                      | Mean         | Error      | StdDev     |
|---------------------------- |-------------:|-----------:|-----------:|
| ExecuteSynchronously        | 4,966.918 ms | 24.5722 ms | 21.7826 ms |
| ExecuteOnThread             | 5,007.381 ms | 58.6155 ms | 54.8290 ms |
| ExecuteOnThreadPool         | 4,985.373 ms | 25.1535 ms | 21.0043 ms |
| ExecuteOnThreadPool_Tasks   | 5,004.187 ms | 27.6760 ms | 24.5340 ms |
| M_ExecuteSynchronously      |   198.714 ms |  0.4765 ms |  0.4224 ms |
| M_ExecuteOnThread           |     1.149 ms |  0.0229 ms |  0.0472 ms |
| M_ExecuteOnThreadPool       |     1.101 ms |  0.0220 ms |  0.0616 ms |
| M_ExecuteOnThreadPool_Tasks |     1.063 ms |  0.0212 ms |  0.0448 ms |
