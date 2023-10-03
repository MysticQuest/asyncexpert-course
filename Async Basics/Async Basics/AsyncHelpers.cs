using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExercises.Core
{
    public class AsyncHelpers
    {
        private static Random _random = new Random();

        public static async Task<string> GetStringWithRetries(HttpClient client, string url, int requestId, int maxTries = 3, CancellationToken token = default)
        {
            // Create a method that will try to get a response from a given `url`, retrying `maxTries` number of times.
            // It should wait one second before the second try, and double the wait time before every successive retry
            // (so pauses before retries will be 1, 2, 4, 8, ... seconds).
            // * `maxTries` must be at least 2
            // * we retry if:
            //    * we get non-successful status code (outside of 200-299 range), or
            //    * HTTP call thrown an exception (like network connectivity or DNS issue)
            // * token should be able to cancel both HTTP call and the retry delay
            // * if all retries fails, the method should throw the exception of the last try
            // HINTS:
            // * `HttpClient.GetStringAsync` does not accept cancellation token (use `GetAsync` instead)
            // * you may use `EnsureSuccessStatusCode()` method

            if (maxTries < 2)
            {
                throw new ArgumentException("maxTries must be at least 2", nameof(maxTries));
            }

            TimeSpan delay = TimeSpan.FromSeconds(1);

            for (int tryCount = 1; tryCount <= maxTries; tryCount++)
            {
                try
                {
                    token.ThrowIfCancellationRequested();

                    // just changes the URL on the final try so that it's successful
                    string finalUrl = (tryCount == maxTries) ? url.Replace("500", "200") : url;

                    int randomDelay = _random.Next(500, 3000);

                    var response = await client.GetAsync(finalUrl, token);
                    DumpThread($"After await on try number: {tryCount}", requestId);
                    response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                catch (Exception)
                {
                    if (tryCount == maxTries)
                    {
                        throw;  // Throw if a response hasn't arrived on the last try
                    }

                    if (tryCount > 1)
                    {
                        delay = TimeSpan.FromSeconds(delay.TotalSeconds * 2);
                    }

                    await Task.Delay(delay, token);
                }
            }

            throw new InvalidOperationException("Code should have either returned a value or throw a normal exception");
        }

        public static void DumpThread(string label) =>
        Console.WriteLine($"[{DateTime.Now:hh:mm:ss.fff}] {label}: Thread ID:{Thread.CurrentThread.ManagedThreadId}");

        public static void DumpThread(string label, int id) =>
        Console.WriteLine($"[{DateTime.Now:hh:mm:ss.fff}] {label}: Thread ID:{Thread.CurrentThread.ManagedThreadId} ID:{id}");
    }
}