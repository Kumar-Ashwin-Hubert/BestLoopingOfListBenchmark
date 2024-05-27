# List Loop Performance Benchmarks in .NET

This repository contains the source code and results for benchmarking different list loop constructs in various .NET target frameworks.

## Overview

In this project, we aim to determine the performance differences between various loop constructs (`for`, `foreach`, `List.ForEach`, `while`, and `do-while`) across different .NET versions (.NET Framework 4.7.2, .NET Core 3.1, .NET 6.0, .NET 8.0, and .NET 9.0-preview). We also explore the high-performance `CollectionsMarshal.AsSpan<T>` method introduced in .NET 5.

### Published Blog

For a detailed explanation of the benchmarks, findings, and conclusions, visit the [Comparing List Loop Performance in .NET]([https://your-blog-link-here](https://kumarashwinhubert.com/comparing-list-loop-performance-in-net-from-net-framework-to-net-9-preview)).

## Setup

### Prerequisites

- .NET SDK installed

### Running the Benchmarks

1. Clone the repository:
    ```sh
    git clone https://github.com/Kumar-Ashwin-Hubert/BestLoopingOfListBenchmark.git
    cd src
    ```

2. Restore the necessary packages:
    ```sh
    dotnet restore
    ```

3. Run the benchmarks:
    ```sh
    dotnet run -c Release --project ListLoopPerformance\ListLoopingPerformanceBenchmark.cs
    ```

## Results

The benchmark result images can be found in the `Benchmark Results` directory.

![](Benchmark%20Results/List%20Loop%20Summary.png)
![](Benchmark%20Results/List%20Loop%20Graph.png)
---
#### Span loop: 
![](Benchmark%20Results/List%20Span%20Loop%20Summary.png)
