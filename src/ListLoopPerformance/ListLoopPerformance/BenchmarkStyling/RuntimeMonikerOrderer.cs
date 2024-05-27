using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Collections.Immutable;

namespace ListLoopPerformance.BenchmarkStyling
{
    public class RuntimeMonikerOrderer : DefaultOrderer
    {
        protected override IEnumerable<BenchmarkCase> GetSummaryOrderForGroup(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary)
        {
            return benchmarksCase.OrderBy(b => b.Job.Environment.Runtime.RuntimeMoniker);
        }
    }
}
