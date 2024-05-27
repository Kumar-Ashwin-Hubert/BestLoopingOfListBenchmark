using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using ListLoopPerformance.BenchmarkStyling;
using System.Runtime.InteropServices;

namespace ListLoopPerformance
{
    public class ListSpanLoopingBenchmark
    {
        [SimpleJob(RuntimeMoniker.Net60, baseline: true)]
        [SimpleJob(RuntimeMoniker.Net80)]
        [SimpleJob(RuntimeMoniker.Net90)]
        [HideColumns("Error", "StdDev", "Median", "RatioSD")]
        [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByMethod)]
        [Config(typeof(StyleConfig))]
        [MemoryDiagnoser]
        public class ListLoopingPerformanceBenchmark
        {
            private readonly List<string> list = new List<string>();

            [Params(1_000_000, 10_000_000)]
            public int size;

            [GlobalSetup]
            public void Setup()
            {
                var random = new Random(580);
                for (int i = 0; i < size; i++)
                {
                    list.Add(random.Next().ToString());
                }
            }

            // Adding `for` loop as comparision with `span`.
            [Benchmark(Description = "for")]
            public string For()
            {
                var result = string.Empty;
                var size = list.Count;
                for (int i = 0; i < size; i++)
                {
                    result = list[i];
                }

                return result;
            }

            [Benchmark(Description = "Span")]
            public string Span()
            {
                var result = string.Empty;
                int size = list.Count;
                Span<string> span = CollectionsMarshal.AsSpan(list);

                for (var i = 0; i < size; i++)
                {
                    result = span[i];
                }

                return result;
            }
        }
    }
}
