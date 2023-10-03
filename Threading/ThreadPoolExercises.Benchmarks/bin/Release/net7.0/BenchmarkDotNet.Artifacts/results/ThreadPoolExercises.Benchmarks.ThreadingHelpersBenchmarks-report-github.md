```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3448/22H2/2022Update)
AMD Ryzen 5 3600, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2


```
| Method                          | Mean      | Error     | StdDev    | Median    |
|-------------------------------- |----------:|----------:|----------:|----------:|
| ExecuteSynchronously            | 49.489 ms | 0.1572 ms | 0.1394 ms | 49.510 ms |
| ExecuteOnThread                 |  9.628 ms | 0.1412 ms | 0.1321 ms |  9.615 ms |
| ExecuteOnThreadPool             |  4.949 ms | 0.0053 ms | 0.0047 ms |  4.949 ms |
| ExecuteOnThreadPool_Tasks       |  4.976 ms | 0.0067 ms | 0.0060 ms |  4.975 ms |
| Chunk_ExecuteSynchronously      | 99.744 ms | 0.0291 ms | 0.0258 ms | 99.738 ms |
| Chunk_ExecuteOnThread           |  1.878 ms | 0.0635 ms | 0.1874 ms |  1.930 ms |
| Chunk_ExecuteOnThreadPool       |  1.476 ms | 0.0741 ms | 0.2185 ms |  1.459 ms |
| Chunk_ExecuteOnThreadPool_Tasks |  1.496 ms | 0.0433 ms | 0.1275 ms |  1.515 ms |
