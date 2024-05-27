using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using ListLoopPerformance.BenchmarkStyling;

namespace ListLoopPerformance
{
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net90)]
    [HideColumns("Error", "StdDev", "Median", "RatioSD")]
    [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByMethod)]
    [Config(typeof(StyleConfig))]
    [MemoryDiagnoser]
    public class ListLoopingPerformanceBenchmark
    {
        private readonly List<string> list = new List<string>();

        // 10 million elements
        private readonly int size = 10_000_000;

        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(580);
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next().ToString());
            }
        }

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

        [Benchmark(Description = "foreach")]
        public string Foreach()
        {
            var result = string.Empty;
            foreach (var item in list)
            {
                result = item;
            }

            return result;
        }

        [Benchmark(Description = "ForEach")]
        public string ForEach()
        {
            var result = string.Empty;
            list.ForEach(item => result = item);

            return result;
        }

        [Benchmark(Description = "while")]
        public string While()
        {
            var result = string.Empty;
            int i = 0;
            int size = list.Count;
            while (i < size)
            {
                result = list[i];
                i++;
            }

            return result;
        }

        [Benchmark(Description = "do-while")]
        public string DoWhile()
        {
            var result = string.Empty;
            int i = 0;
            int size = list.Count;
            do
            {
                result = list[i];
                i++;
            } while (i < size);

            return result;
        }
    }
}
