using System;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Timers;

namespace ThreadPoolExercises.Core
{
    public class ThreadingHelpers
    {
        public static void ExecuteOnThread(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            // * Create a thread and execute there `action` given number of `repeats` - waiting for the execution!
            //   HINT: you may use `Join` to wait until created Thread finishes
            // * In a loop, check whether `token` is not cancelled
            // * If an `action` throws and exception (or token has been cancelled) - `errorAction` should be invoked (if provided)

            Thread thread = new Thread(() =>
            {
                try
                {
                    for (int i = 0; i < repeats; i++)
                    {
                        token.ThrowIfCancellationRequested();
                        action();
                    }
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    errorAction?.Invoke(ex);
                }
                catch (OperationCanceledException)
                {
                    errorAction?.Invoke(new OperationCanceledException("Operation was canceled", token));
                }
            });

            thread.Start();
            thread.Join();

        }

        public static void ExecuteOnThreadPool(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            // * Queue work item to a thread pool that executes `action` given number of `repeats` - waiting for the execution!
            //   HINT: you may use `AutoResetEvent` to wait until the queued work item finishes
            // * In a loop, check whether `token` is not cancelled
            // * If an `action` throws and exception (or token has been cancelled) - `errorAction` should be invoked (if provided)

            AutoResetEvent autoEvent = new AutoResetEvent(false);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    for (int i = 0; i < repeats; i++)
                    {
                        token.ThrowIfCancellationRequested();
                        action();
                    }
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    errorAction?.Invoke(ex);
                }
                catch (OperationCanceledException)
                {
                    errorAction?.Invoke(new OperationCanceledException("Operation was canceled", token));
                }
                finally
                {
                    autoEvent.Set();  // signal the completion of the work item
                }
            });

            autoEvent.WaitOne();  //wait for the signal that the work item is complete
        }


        public static async Task ExecuteOnThreadPool_Tasks(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            await Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < repeats; i++)
                    {
                        token.ThrowIfCancellationRequested();
                        action();
                    }
                }
                catch (Exception ex)
                {
                    errorAction?.Invoke(ex);
                }
            }, token);  // pass the CancellationToken to Task.Run
        }
    }
}