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
            
            for (int i = 0; i < repeats; i++)
            {
                var thread = new Thread(_ =>
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();
                        action();
                    }
                    catch (Exception ex)
                    {
                        errorAction?.Invoke(ex);
                    }
                });

                thread.Start();
                thread.Join();
            }
        }

        public static void ExecuteOnThreadPool(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            // * Queue work item to a thread pool that executes `action` given number of `repeats` - waiting for the execution!
            //   HINT: you may use `AutoResetEvent` to wait until the queued work item finishes
            // * In a loop, check whether `token` is not cancelled
            // * If an `action` throws and exception (or token has been cancelled) - `errorAction` should be invoked (if provided)

            AutoResetEvent autoEvent = new AutoResetEvent(false);

            for (int i = 0; i < repeats; i++)
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();
                        action();
                    }
                    catch (Exception ex)
                    {
                        errorAction?.Invoke(ex);
                    }
                    finally
                    {
                        autoEvent.Set();
                    }
                });
                autoEvent.WaitOne();
            }
        }


        public static async Task ExecuteOnThreadPool_Tasks(Action action, int repeats, CancellationToken token = default, Action<Exception>? errorAction = null)
        {
            for (int i = 0; i < repeats; i++)
            {
                await Task.Run(() =>
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();
                        action();
                    }
                    catch (Exception ex)
                    {
                        errorAction?.Invoke(ex);
                    }
                }, token);
            }
        }
    }
}