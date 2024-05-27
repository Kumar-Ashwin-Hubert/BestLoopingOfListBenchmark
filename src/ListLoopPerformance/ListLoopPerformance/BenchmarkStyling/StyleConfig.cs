using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Reports;

namespace ListLoopPerformance.BenchmarkStyling
{
    public class StyleConfig : ManualConfig
    {
        public StyleConfig()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
            AddExporter(CsvMeasurementsExporter.Default);
            AddExporter(RPlotExporter.Default);
            Orderer = new RuntimeMonikerOrderer();
        }
    }
}
