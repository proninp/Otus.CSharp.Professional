using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace HomeWork._06;

[Config(typeof(QuickBenchmarkConfig))]
[MemoryDiagnoser]
[HideColumns("StdDev", "Median", "Gen0", "Gen1")]
public class ReflectionBenchmark
{
    private SerializationExample? _instance;
    private string? _reflectionSerialized;
    private string? _jsonSerialized;
    
    [GlobalSetup]
    public void Setup()
    {
        _instance = SerializationExample.Get();
        _reflectionSerialized = ReflectionHelper.Serialize(_instance);
        _jsonSerialized = JsonSerializer.Serialize(_instance);
    }

    [Benchmark]
    public string ReflectionSerialization()
    {
        return ReflectionHelper.Serialize(_instance!);
    }
    
    [Benchmark]
    public string JsonSerialization()
    {
        return JsonSerializer.Serialize(_instance!);
    }
    
    [Benchmark]
    public SerializationExample ReflectionDeserialization()
    {
        return ReflectionHelper.Deserialize<SerializationExample>(_reflectionSerialized!);
    }
    
    [Benchmark]
    public SerializationExample? JsonDeserialization()
    {
        return JsonSerializer.Deserialize<SerializationExample>(_jsonSerialized!);
    }
}