﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCombinatorsExercises.Core
{
    public static class HttpClientExtensions
    {
        /*
         Write cancellable async method with timeout handling, that concurrently tries to get data from
         provided urls (first wins and its response is returned, rest is __cancelled__).
         
         Tips:
         * consider using HttpClient.GetAsync (as it is cancellable)
         * consider using Task.WhenAny
         * you may use urls like for testing https://postman-echo.com/delay/3
         * you should have problem with tasks cancellation -
            - how to merge tokens of operations (timeouts) with the provided token? 
            - Tip: you can link tokens with the help of CancellationTokenSource.CreateLinkedTokenSource(token)
         */

        public static async Task<string> ConcurrentDownloadAsync(this HttpClient httpClient,
            string[] urls, int millisecondsTimeout, CancellationToken token)
        {
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(token);
            using var timeoutCts = new CancellationTokenSource(millisecondsTimeout);
            using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(linkedCts.Token, timeoutCts.Token);

            var tasks = urls.Select(url => httpClient.GetAsync(url, combinedCts.Token)).ToList();

            Task<HttpResponseMessage> completedTask = await Task.WhenAny(tasks);

            combinedCts.Cancel();

            try
            {
                HttpResponseMessage response = await completedTask;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"Failed to download. Status code: {response.StatusCode}");
                }
            }
            catch (TaskCanceledException) when (timeoutCts.IsCancellationRequested)
            {
                throw new TimeoutException("The operation timed out.");
            }
        }
    }
}