# Async expert course
### A series of exercises on async programming/multithreading in .NET

[Exercise repository](https://github.com/dotnetos/asyncexpert-course/tree/master)

### 1. Benchmark Dot Net
The code benchmarks four methods of calculating Fibonacci numbers: naive recursion, recursion with memoization (using a dictionary or list), and an iterative approach. Produces two result files (assembly & benchmarks).

### 2. Threading
- The project benchmarks different threading strategies in .NET for computing SHA256 hashes, using direct threading, thread pool, and task-based asynchronous pattern. Produces a result file.
- More functions have been added to the original course, using parallel threads on benchmark repetitions for single hash functions, and single threads with parallel for on data chuncks hash functions, for the heck of it.
- Unit tests with Moq and XUnit.

### 3. Basic Async
- The project emulates an async call to a url and retries if unsuccessful.
- Many calls were added to the original course, so that async will use multiple threads. 
- Unit tests with XUnit and MockHttp, logs TID after every request.

### 4. Async 2
  - #### Awaitables
     - The project extends the bool type with a custom Awaiter and awaits it.
     - Unit tests with XUnit.
  
  - #### TaskCompletionSource
     - The project executes an external program (ExampleApp.exe) synchronously and asynchronously.
     - The async method handles and logs output and exceptions.
     - Unit tests with XUnit.
       
### 5. Async 3
- The project executes mock download operations asynchronously, with a timeout delay and combined cancellation token.
- Unit tests with XUnit and MockHttp, logs operations and exceptions. 

### 6. Low-Level Concurrency
- The project tests a concurrent queue and a class with number calculations against a multithreaded environment.
- Locks have been replaced with Volatile/Interlocked and more tests have been added for the queue. 
- Unit tests with NUnit.

### 7. Synchronization
- The project implements Mutex and Semaphore synchronization primitives within custom wrapper classes for managing resource access.
- Defines their scope with the "using" keyword. Uses system-wide or localized synchronization.
- Unit tests with XUnit.

### 8. Concurrent Data Structures
- The project implements atomic operations on a Dictionary and ConcurrentDictionary. 
- Compares lock-based Dictionary and ConcurrentDictionary operations and ConcurrentDictionary that delegates the operations to a lock-free atomic counter class.  
- Unit tests with NUnit.
