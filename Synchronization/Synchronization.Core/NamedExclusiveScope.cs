using System;
using System.Threading;

namespace Synchronization.Core
{
    public class NamedExclusiveScope : IDisposable
    {
        private readonly Semaphore semaphore;
        private bool hasHandle = false;

        public NamedExclusiveScope(string name, bool isSystemWide)
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
}
