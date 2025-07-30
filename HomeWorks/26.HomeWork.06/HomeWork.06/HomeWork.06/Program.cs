using System.Diagnostics;
using System.Text.Json;
using BenchmarkDotNet.Running;
using HomeWork._06;

var testInstance = SerializationExample.Get();
Console.WriteLine($"Исходный объект: {testInstance}");

var stopwatch = Stopwatch.StartNew();
var reflectionSerialized = ReflectionHelper.Serialize(testInstance);
stopwatch.Stop();
Console.WriteLine($"Reflection сериализация: {reflectionSerialized}");
Console.WriteLine($"Время reflection сериализации: {stopwatch.Elapsed.TotalMicroseconds:F2} мкс");
Console.WriteLine();

stopwatch.Restart();
var jsonSerialized = JsonSerializer.Serialize(testInstance);
stopwatch.Stop();
Console.WriteLine($"JSON сериализация: {jsonSerialized}");
Console.WriteLine($"Время JSON сериализации: {stopwatch.Elapsed.TotalMicroseconds:F2} мкс");
Console.WriteLine();

stopwatch.Restart();
var reflectionDeserialized = ReflectionHelper.Deserialize<SerializationExample>(reflectionSerialized);
stopwatch.Stop();
Console.WriteLine($"Reflection десериализация: {reflectionDeserialized}");
Console.WriteLine($"Время reflection десериализации: {stopwatch.Elapsed.TotalMicroseconds:F2} мкс");
Console.WriteLine();

// Тестируем JSON десериализацию
stopwatch.Restart();
var jsonDeserialized = JsonSerializer.Deserialize<SerializationExample>(jsonSerialized);
stopwatch.Stop();
Console.WriteLine($"JSON десериализация: {jsonDeserialized}");
Console.WriteLine($"Время JSON десериализации: {stopwatch.Elapsed.TotalMicroseconds:F2} мкс");
Console.WriteLine();

var summary = BenchmarkRunner.Run<ReflectionBenchmark>(new QuickBenchmarkConfig());