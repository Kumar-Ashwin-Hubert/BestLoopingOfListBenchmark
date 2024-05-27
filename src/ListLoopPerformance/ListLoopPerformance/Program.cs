using BenchmarkDotNet.Running;

namespace ListLoopPerformance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ListLoopingPerformanceBenchmark>();

            /* IMPORTANT: Before enabling below benchmark for span, ensure the .csproj 
             * target framework is changed to remove the net472 & netcoreapp3.1 
             * as CollectionsMarshal.AsSpan is available only from .NET 5.0
            */

            // BenchmarkRunner.Run<ListSpanLoopingBenchmark>();
        }
    }
}
