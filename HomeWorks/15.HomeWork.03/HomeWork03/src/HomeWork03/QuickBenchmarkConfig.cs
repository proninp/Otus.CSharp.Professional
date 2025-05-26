using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace HomeWork03;

public class QuickBenchmarkConfig : ManualConfig
{
    public QuickBenchmarkConfig()
    {
        AddJob(Job.Default
            .WithIterationCount(5)
            .WithWarmupCount(2));
        
        AddLogger(ConsoleLogger.Default);
        AddExporter(MarkdownExporter.Default);
        AddColumnProvider(DefaultColumnProviders.Instance);
    }
}