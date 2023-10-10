using System;
using System.Threading;
using Synchronization.Core;

namespace Synchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            var scopeSemaphoreName = "defaultSemaphore";
            var scopeMutexName = "defaultMutex";
            var isSystemWide = false;
            if (args.Length == 2)
            {
                scopeSemaphoreName = args[0];
                scopeMutexName = args[0];
                isSystemWide = bool.Parse(args[1]);
            }
            using (new NamedExclusiveSemaphoreScope(scopeSemaphoreName, isSystemWide))
            {
                Console.WriteLine("Hello world!");
                Console.WriteLine("With Semaphore");
                Thread.Sleep(300);
            }
            using (new NamedExclusiveMutexScope(scopeMutexName, isSystemWide))
            {
                Console.WriteLine("Hello world!");
                Console.WriteLine("With Mutex");
                Thread.Sleep(300);
            }
        }
    }
}
