# Async expert course
### A series of exercises on async programming/multithreading in .NET

[Exercise repository](https://github.com/dotnetos/asyncexpert-course/tree/master)

### 1. Benchmark Dot Net
The code benchmarks four methods of calculating Fibonacci numbers: naive recursion, recursion with memoization (using a dictionary or list), and an iterative approach. Produces two result files (assembly & benchmarks).

### 2. Threading
- The project benchmarks different threading strategies in .NET for computing SHA256 hashes, using direct threading, thread pool, and task-based asynchronous pattern. Produces a result file.
- More functions have been added to the original course, using parallel threads on benchmark repetitions for single hash functions, and single threads with parallel for on data chuncks hash functions, for the heck of it.
- Tests them with Moq and XUnit.

### 2. Basic Async
- The project emulates an async call to a url and retries if unsuccessful.
- Many calls were added to the original course, so that async will use multiple threads. 
- Tests it with XUnit and MockHttp, logs TID after every request.
