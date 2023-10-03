using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitExercises.Core;

namespace AsyncAwaitExercises
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            var urls = Enumerable.Repeat("https://postman-echo.com/status/500", 100);

            try
            {
                AsyncHelpers.DumpThread("Before call");
                var tasks = urls.Select((url, index) => AsyncHelpers.GetStringWithRetries(client, url, requestId: index + 1));
                var results = await Task.WhenAll(tasks);
                AsyncHelpers.DumpThread("After call");

            }
            catch (Exception ex)
            {
                AsyncHelpers.DumpThread($"After exception {ex}");
            }
        }
    }
}