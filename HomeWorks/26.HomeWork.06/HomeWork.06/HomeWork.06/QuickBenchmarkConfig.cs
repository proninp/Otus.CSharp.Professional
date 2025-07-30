using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;

namespace HomeWork._06;

public class QuickBenchmarkConfig : ManualConfig
{
    public QuickBenchmarkConfig()
    {
        AddJob(Job.Default
            .WithIterationCount(100)
            .WithWarmupCount(2));
        
        AddLogger(ConsoleLogger.Default);
        AddExporter(MarkdownExporter.Default, HtmlExporter.Default);
        AddColumn(StatisticColumn.Mean, StatisticColumn.StdDev, StatisticColumn.Median);
        AddColumnProvider(DefaultColumnProviders.Instance);
    }
}