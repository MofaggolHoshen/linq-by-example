```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 11.0.100-preview.2.26159.112
  [Host] : .NET 11.0.0 (11.0.26.16012), X64 AOT AVX2

Toolchain=InProcessNoEmitToolchain  RunStrategy=Throughput  

```
| Method                | Size   | Mean      | Error     | StdDev    | Median    | Allocated |
|---------------------- |------- |----------:|----------:|----------:|----------:|----------:|
| **List_Any**              | **10**     | **0.8661 ns** | **0.0261 ns** | **0.0204 ns** | **0.8562 ns** |         **-** |
| Array_Any             | 10     | 0.0186 ns | 0.0160 ns | 0.0142 ns | 0.0148 ns |         - |
| List_Count_Method     | 10     | 0.2932 ns | 0.0214 ns | 0.0167 ns | 0.2889 ns |         - |
| Array_Count_Method    | 10     | 0.0257 ns | 0.0225 ns | 0.0211 ns | 0.0232 ns |         - |
| List_Count_Property   | 10     | 0.0107 ns | 0.0171 ns | 0.0152 ns | 0.0024 ns |         - |
| Array_Length_Property | 10     | 0.0047 ns | 0.0052 ns | 0.0046 ns | 0.0046 ns |         - |
| **List_Any**              | **1000**   | **0.8241 ns** | **0.0128 ns** | **0.0107 ns** | **0.8245 ns** |         **-** |
| Array_Any             | 1000   | 0.0088 ns | 0.0241 ns | 0.0248 ns | 0.0000 ns |         - |
| List_Count_Method     | 1000   | 0.2790 ns | 0.0258 ns | 0.0216 ns | 0.2750 ns |         - |
| Array_Count_Method    | 1000   | 0.0635 ns | 0.0492 ns | 0.0936 ns | 0.0237 ns |         - |
| List_Count_Property   | 1000   | 0.0141 ns | 0.0144 ns | 0.0135 ns | 0.0067 ns |         - |
| Array_Length_Property | 1000   | 0.0092 ns | 0.0134 ns | 0.0126 ns | 0.0005 ns |         - |
| **List_Any**              | **100000** | **0.8006 ns** | **0.0250 ns** | **0.0209 ns** | **0.7924 ns** |         **-** |
| Array_Any             | 100000 | 0.0076 ns | 0.0077 ns | 0.0069 ns | 0.0059 ns |         - |
| List_Count_Method     | 100000 | 0.2577 ns | 0.0153 ns | 0.0120 ns | 0.2571 ns |         - |
| Array_Count_Method    | 100000 | 0.0358 ns | 0.0353 ns | 0.0313 ns | 0.0231 ns |         - |
| List_Count_Property   | 100000 | 0.0880 ns | 0.0617 ns | 0.1699 ns | 0.0109 ns |         - |
| Array_Length_Property | 100000 | 0.0044 ns | 0.0074 ns | 0.0066 ns | 0.0000 ns |         - |
