```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.6199/23H2/2023Update/SunValley3)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 11.0.100-preview.3.26207.106
  [Host] : .NET 11.0.0 (11.0.26.20806), X64 AOT AVX2

Toolchain=InProcessNoEmitToolchain  RunStrategy=Throughput  

```
| Method                    | Size  | Mean           | Error       | StdDev        | Median         | Allocated |
|-------------------------- |------ |---------------:|------------:|--------------:|---------------:|----------:|
| **List_Count**                | **10**    |      **0.2429 ns** |   **0.0185 ns** |     **0.0173 ns** |      **0.2353 ns** |         **-** |
| Array_Count               | 10    |      0.0101 ns |   0.0143 ns |     0.0127 ns |      0.0066 ns |         - |
| List_Count_WithPredicate  | 10    |      8.4224 ns |   0.1729 ns |     0.1850 ns |      8.3946 ns |         - |
| Array_Count_WithPredicate | 10    |     30.9857 ns |   0.2465 ns |     0.2305 ns |     30.9193 ns |         - |
| List_Sum                  | 10    |      6.5030 ns |   0.0605 ns |     0.0537 ns |      6.4889 ns |         - |
| Array_Sum                 | 10    |      6.8625 ns |   0.1791 ns |     0.1676 ns |      6.8113 ns |         - |
| List_Sum_ManualLoop       | 10    |      9.7922 ns |   0.0393 ns |     0.0329 ns |      9.7861 ns |         - |
| Array_Sum_ManualLoop      | 10    |      4.5004 ns |   0.1132 ns |     0.1004 ns |      4.4588 ns |         - |
| List_Min                  | 10    |      9.9041 ns |   0.0581 ns |     0.0543 ns |      9.9041 ns |         - |
| Array_Min                 | 10    |      9.0853 ns |   0.1839 ns |     0.1435 ns |      9.0331 ns |         - |
| List_Max                  | 10    |      7.0768 ns |   0.1863 ns |     0.1556 ns |      6.9848 ns |         - |
| Array_Max                 | 10    |      9.6370 ns |   1.2632 ns |     3.6849 ns |      7.7974 ns |         - |
| List_Average              | 10    |      4.8839 ns |   0.1490 ns |     0.1716 ns |      4.8228 ns |         - |
| Array_Average             | 10    |      6.2157 ns |   0.0736 ns |     0.0653 ns |      6.2015 ns |         - |
| List_Aggregate_Product    | 10    |      7.9439 ns |   0.1423 ns |     0.1188 ns |      7.9039 ns |         - |
| Array_Aggregate_Product   | 10    |     29.5470 ns |   0.1776 ns |     0.1575 ns |     29.5032 ns |         - |
| **List_Count**                | **1000**  |      **0.2432 ns** |   **0.0142 ns** |     **0.0126 ns** |      **0.2436 ns** |         **-** |
| Array_Count               | 1000  |      0.0201 ns |   0.0342 ns |     0.0303 ns |      0.0011 ns |         - |
| List_Count_WithPredicate  | 1000  |  3,424.4590 ns |  84.0783 ns |   246.5873 ns |  3,508.6485 ns |         - |
| Array_Count_WithPredicate | 1000  |  2,868.7855 ns |  54.4196 ns |   137.5252 ns |  2,808.0805 ns |         - |
| List_Sum                  | 1000  |    101.6717 ns |   1.3651 ns |     1.1399 ns |    101.5063 ns |         - |
| Array_Sum                 | 1000  |    105.4815 ns |   3.1941 ns |     9.1129 ns |    100.5412 ns |         - |
| List_Sum_ManualLoop       | 1000  |    601.8901 ns |   4.8097 ns |     4.0163 ns |    600.7339 ns |         - |
| Array_Sum_ManualLoop      | 1000  |    397.6442 ns |   2.1163 ns |     1.7672 ns |    396.9249 ns |         - |
| List_Min                  | 1000  |     58.7138 ns |   0.7264 ns |     0.6795 ns |     58.4169 ns |         - |
| Array_Min                 | 1000  |     83.6417 ns |   0.9532 ns |     0.8450 ns |     83.2699 ns |         - |
| List_Max                  | 1000  |     82.6151 ns |   0.3497 ns |     0.2920 ns |     82.5688 ns |         - |
| Array_Max                 | 1000  |     81.4035 ns |   0.7898 ns |     0.7388 ns |     81.1411 ns |         - |
| List_Average              | 1000  |    196.0864 ns |   3.4794 ns |     3.0844 ns |    195.1056 ns |         - |
| Array_Average             | 1000  |    194.7804 ns |   1.2727 ns |     1.1282 ns |    194.5010 ns |         - |
| List_Aggregate_Product    | 1000  |    866.8194 ns |   1.9472 ns |     1.5203 ns |    867.2361 ns |         - |
| Array_Aggregate_Product   | 1000  |  2,950.3035 ns | 114.3820 ns |   324.4828 ns |  2,853.2633 ns |         - |
| **List_Count**                | **10000** |      **0.5973 ns** |   **0.1495 ns** |     **0.4216 ns** |      **0.5262 ns** |         **-** |
| Array_Count               | 10000 |      0.1639 ns |   0.1232 ns |     0.3456 ns |      0.0000 ns |         - |
| List_Count_WithPredicate  | 10000 | 36,465.1670 ns | 723.4921 ns | 1,060.4855 ns | 36,494.1528 ns |         - |
| Array_Count_WithPredicate | 10000 | 28,102.8059 ns | 344.0601 ns |   305.0003 ns | 28,026.1749 ns |         - |
| List_Sum                  | 10000 |  1,054.1135 ns |  17.8718 ns |    16.7173 ns |  1,045.9655 ns |         - |
| Array_Sum                 | 10000 |  1,354.8908 ns |  86.0029 ns |   250.8745 ns |  1,308.6656 ns |         - |
| List_Sum_ManualLoop       | 10000 |  7,083.3391 ns | 270.1171 ns |   770.6593 ns |  6,981.8428 ns |         - |
| Array_Sum_ManualLoop      | 10000 |  4,699.1384 ns | 192.9203 ns |   550.4126 ns |  4,663.8252 ns |         - |
| List_Min                  | 10000 |    549.3535 ns |  28.1867 ns |    80.4183 ns |    519.3754 ns |         - |
| Array_Min                 | 10000 |    948.3497 ns |  71.6783 ns |   210.2200 ns |    845.7347 ns |         - |
| List_Max                  | 10000 |    905.8603 ns |  46.1435 ns |   127.8635 ns |    872.9744 ns |         - |
| Array_Max                 | 10000 |    874.9838 ns |  42.7301 ns |   118.4050 ns |    853.1398 ns |         - |
| List_Average              | 10000 |  2,127.2563 ns |  95.0022 ns |   272.5791 ns |  2,091.7347 ns |         - |
| Array_Average             | 10000 |  1,873.0152 ns |  28.2475 ns |    25.0406 ns |  1,868.5076 ns |         - |
| List_Aggregate_Product    | 10000 |  8,793.5015 ns |  43.0022 ns |    38.1203 ns |  8,776.8791 ns |         - |
| Array_Aggregate_Product   | 10000 | 26,363.0112 ns |  89.8273 ns |    70.1313 ns | 26,354.1550 ns |         - |
