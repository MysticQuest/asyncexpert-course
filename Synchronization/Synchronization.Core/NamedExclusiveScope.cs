using System;
using System.Diagnostics.Metrics;
using System.Threading;

namespace Synchronization.Core
{

/*
 * Implement very simple wrapper around Mutex or Semaphore (remember both implement WaitHandle) to
 * provide a exclusive region created by `using` clause.
 *
 * Created region may be system-wide or not, depending on the constructor parameter.
 *
 * Any try to get a second systemwide scope should throw an `System.InvalidOperationException` with `Unable to get a global lock {name}.`
 */

    public class NamedExclusiveSemaphoreScope : IDisposable
    {
        private readonly Semaphore semaphore;
        private bool hasHandle = false;

        public NamedExclusiveSemaphoreScope(string name, bool isSystemWide)
        {
            if (isSystemWide)
            {
                semaphore = new Semaphore(1, 1, name, out bool createdNew);
                hasHandle = semaphore.WaitOne(0);

                if (!createdNew && !hasHandle)
                {
                    throw new InvalidOperationException($"Unable to get a global lock {name}.");
                }
            }
            else
            {
                semaphore = new Semaphore(1, 1);
                hasHandle = semaphore.WaitOne(0);
            }
        }

        public void Dispose()
        {
            if (hasHandle)
            {
                semaphore.Release();
            }
            semaphore.Dispose();
        }
    }


    public class NamedExclusiveMutexScope : IDisposable
    {
        private readonly Mutex? mutex;
        private bool hasHandle = false;

        public NamedExclusiveMutexScope(string name, bool isSystemWide)
        {
            if (isSystemWide)
            {
                if (!Mutex.TryOpenExisting(name, out mutex))
                {
                    try
                    {
                        mutex = new Mutex(false, name, out bool createdNew);
                    }
                    catch (WaitHandleCannotBeOpenedException)
                    {
                        throw new InvalidOperationException($"Unable to get a global lock {name}.");
                    }
                }
                hasHandle = mutex.WaitOne(0);
                if (!hasHandle)
                {
                    throw new InvalidOperationException($"Unable to get a global lock {name}.");
                }
            }
            else
            {
                mutex = new Mutex();
                hasHandle = mutex.WaitOne(0);
            }
        }

        public void Dispose()
        {
            if (hasHandle)
            {
                mutex?.ReleaseMutex();
            }
            mutex?.Dispose();
        }
    }
}
