using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using TaskCombinatorsExercises.Core;
using Xunit;

namespace TaskCombinatorsExercises.Tests
{
    public class HttpClientExtensionsTests
    {
        [Fact]
        public async Task GivenSingleCall_ThenSucceeds()
        {
            var mockHttp = new MockHttpMessageHandler();
            var mockedRequest1 = GivenDelayUrl(mockHttp, 700);

            var result = await mockHttp.ToHttpClient().ConcurrentDownloadAsync(new[]
            {
                "https://local/delay/700"
            }, 10_000, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("700", result);
            Assert.Equal(1, mockHttp.GetMatchCount(mockedRequest1));
        }
    }
}
