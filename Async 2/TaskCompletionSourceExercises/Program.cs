using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskCompletionSourceExercises.Core;

namespace TaskCompletionSourceExercises
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    RunProgramSync();
        //}

        static async Task Main(string[] args)
        {
            await RunProgramAsync();
        }

        private static async Task RunProgramAsync()
        {
            var result = await AsyncTools.RunProgramAsync(@"..\..\..\..\ExampleApp\bin\Debug\net7.0\ExampleApp.exe", "argument");
            Console.WriteLine(result);
        }

        private static void RunProgramSync()
        {
            var process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = new ProcessStartInfo(@"..\..\..\..\ExampleApp\bin\Debug\net7.0\ExampleApp.exe")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            process.Exited += (sender, eventArgs) =>
            {
                var senderProcess = sender as Process;
                Console.WriteLine("----- program output -----");
                Console.WriteLine($"Exit code: {senderProcess?.ExitCode}");
                Console.WriteLine("Standard output:");
                Console.Write(senderProcess?.StandardOutput.ReadToEnd());
                Console.WriteLine("Standard error:");
                Console.Write(senderProcess?.StandardError.ReadToEnd());
                Console.WriteLine("----- program output -----");
                senderProcess?.Dispose();
            };
            process.Start();
            Console.WriteLine("Test");
            Console.ReadKey();
        }
    }
}