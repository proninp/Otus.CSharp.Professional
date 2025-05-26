
BenchmarkDotNet v0.15.0, Windows 11 (10.0.26100.4061/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  Job-SQLOGK : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2

IterationCount=5  WarmupCount=2  

 Method        | Size     | Mean         | Error        | Allocated |
-------------- |--------- |-------------:|-------------:|----------:|
 **SimpleForSum**  | **100000**   |     **45.43 μs** |     **0.955 μs** |         **-** |
 SimpleLinqSum | 100000   |    118.98 μs |    10.620 μs |      32 B |
 ParallelSum   | 100000   |     64.47 μs |    10.992 μs |    4572 B |
 PLinqSum      | 100000   |    138.50 μs |     6.355 μs |    7415 B |
 **SimpleForSum**  | **1000000**  |    **451.91 μs** |     **3.404 μs** |         **-** |
 SimpleLinqSum | 1000000  |  1,854.45 μs |   175.962 μs |      33 B |
 ParallelSum   | 1000000  |    498.93 μs |    97.263 μs |    4604 B |
 PLinqSum      | 1000000  |    886.09 μs |   148.010 μs |    7416 B |
 **SimpleForSum**  | **10000000** |  **4,798.48 μs** |    **84.874 μs** |       **5 B** |
 SimpleLinqSum | 10000000 | 17,028.33 μs | 8,260.599 μs |      54 B |
 ParallelSum   | 10000000 |  3,967.48 μs |   425.012 μs |    4650 B |
 PLinqSum      | 10000000 |  7,963.30 μs |   908.827 μs |    7427 B |
