using BenchmarkDotNet.Running;
using HomeWork03;

var summary = BenchmarkRunner.Run<ParallelBenchmark>(new QuickBenchmarkConfig());