using System;
using System.Threading;

namespace Synchronization.Core
{
    /*
     * Implement very simple wrapper around Mutex or Semaphore (remember both implement WaitHandle) to
     * provide a exclusive region created by `using` clause.
     *
     * Created region may be system-wide or not, depending on the constructor parameter.
     *
     * Any try to get a second systemwide scope should throw an `System.InvalidOperationException` 
     * with `Unable to get a global lock {name}.`
     */
    public class NamedExclusiveScope : IDisposable
    {
        Semaphore semaphore;
        public NamedExclusiveScope(string name, bool isSystemWide)
        {
            if (isSystemWide == false)
            {
                semaphore = new Semaphore(1, 1);
                semaphore.WaitOne();
            }
            else
            {
                semaphore = new Semaphore(1, 1, name);
                semaphore.WaitOne();
            }
            bool acquired = semaphore.WaitOne(0);
            if (!acquired)
            {
                throw new InvalidOperationException($"Unable to get a global lock {name}.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                semaphore.Release();
            }
        }
    }
}