using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pipelines
{
    // Calculate how many lines (end of line characters `\n`) are in the network stream
    // To practice, use a pattern where you have the Pipe, Writer and Reader tasks
    // Read about SequenceReader<T>, https://docs.microsoft.com/en-us/dotnet/api/system.buffers.sequencereader-1?view=netcore-3.1
    // This struct h has a method that can be very useful for this scenario :)

    // Good luck and have fun with pipelines!

    public class PipeLineCounter
    {
        public async Task<int> CountLines(Uri uri)
        {
            using var client = new HttpClient();
            await using var stream = await client.GetStreamAsync(uri);
            var pipe = new Pipe();

            var writing = FillPipeAsync(stream, pipe.Writer);
            var reading = ReadPipeAsync(pipe.Reader);

            await Task.WhenAll(reading, writing);

            return reading.Result;
        }

        private async Task FillPipeAsync(Stream stream, PipeWriter writer)
        {
            const int minimumBufferSize = 512;
            while (true)
            {
                var memory = writer.GetMemory(minimumBufferSize);
                var bytesRead = await stream.ReadAsync(memory);
                if (bytesRead == 0)
                {
                    break; // Stream is completed
                }
                writer.Advance(bytesRead);
                var result = await writer.FlushAsync();
                if (result.IsCompleted)
                {
                    break; // Reader is completed
                }
            }
            await writer.CompleteAsync();
        }

        private async Task<int> ReadPipeAsync(PipeReader reader)
        {
            int lineCount = 0;
            while (true)
            {
                var result = await reader.ReadAsync();
                var buffer = result.Buffer;
                lineCount += CountLinesInBuffer(buffer);
                reader.AdvanceTo(buffer.End);
                if (result.IsCompleted)
                {
                    break;
                }
            }
            await reader.CompleteAsync();
            return lineCount;
        }

        private int CountLinesInBuffer(in ReadOnlySequence<byte> buffer)
        {
            int lineCount = 0;
            foreach (var segment in buffer)
            {
                var span = segment.Span;
                for (var i = 0; i < span.Length; i++)
                {
                    if (span[i] == '\n')
                    {
                        lineCount++;
                    }
                }
            }
            return lineCount;
        }
    }
}