﻿// Copyright (c) Toni Solarin-Sodara
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Threading.Tasks;
using Coverlet.Core;
using Coverlet.Core.CoverageSamples.Tests;
using Coverlet.Core.Tests;
using Coverlet.Tests.Utils;
using Xunit;

namespace Coverlet.CoreCoverage.Tests
{
  public partial class CoverageTests
  {

    [Fact]
    public void NoBranches_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                  {
                    try { instance.NoBranches(); }
                    catch (Exception) { }
                    return Task.CompletedTask;

                  }, persistPrepareResultToFile: pathSerialize[0], doesNotReturnAttributes: _ => ["DoesNotReturnAttribute"]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 12, 13, 14)
            .AssertNonInstrumentedLines(BuildConfiguration.Debug, 15, 16);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact(Skip = "xunit.v3 '(Explicit=true)' (System.Console.ReadKey, Instrumentation.DoesNotReturn.cs line 22) ")]
    public void If_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.If(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 19, 20, 22, 23, 24, 25, 29, 30, 26, 27);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact(Skip = "xunit.v3 '(Explicit=true)' (System.Console.ReadKey, Instrumentation.DoesNotReturn.cs line 36) ")]
    public void Switch_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.Switch(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 33, 34, 36, 39, 40, 44, 45, 49, 50, 52, 53, 55, 56, 58, 59, 61, 62, 64, 65, 68, 69, 41, 42);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact(Skip = "xunit.v3 '(Explicit=true)' (System.Console.ReadKey, Instrumentation.DoesNotReturn.cs line 37) ")]
    public void Subtle_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.Subtle(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 72, 73, 75, 78, 82, 83, 86, 87, 91, 92, 95, 101, 102, 103, 79, 80, 88, 96, 98, 99);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact(Skip = "xunit.v3 '(Explicit=true)' (System.Console.ReadKey, Instrumentation.DoesNotReturn.cs line 107) ")]
    public void UnreachableBranch_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.UnreachableBranch(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 106, 107, 108, 110, 111, 112, 113, 114);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact]
    public void CallsGenericMethodDoesNotReturn_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.CallsGenericMethodDoesNotReturn(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0], doesNotReturnAttributes: _ => ["DoesNotReturnAttribute"]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 118, 119, 124, 125, 126)
            .AssertNonInstrumentedLines(BuildConfiguration.Debug, 127, 128);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact]
    public void CallsGenericClassDoesNotReturn_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.CallsGenericClassDoesNotReturn(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0], doesNotReturnAttributes: _ => ["DoesNotReturnAttribute"]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 134, 135, 140, 141, 142)
            .AssertNonInstrumentedLines(BuildConfiguration.Debug, 143, 144);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact]
    public void WithLeave_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.WithLeave(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0], doesNotReturnAttributes: _ => ["DoesNotReturnAttribute"]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 147, 149, 150, 151, 152, 153, 154, 155, 156, 159, 161, 166, 167, 168)
            .AssertNonInstrumentedLines(BuildConfiguration.Debug, 163, 164);
      }
      finally
      {
        File.Delete(path);
      }
    }

    [Fact]
    public void FiltersAndFinally_DoesNotReturnAttribute_InstrumentsCorrect()
    {
      string path = Path.GetTempFileName();
      try
      {
        FunctionExecutor.Run(async (string[] pathSerialize) =>
        {
          CoveragePrepareResult coveragePrepareResult = await TestInstrumentationHelper.Run<DoesNotReturn>(instance =>
                      {
                        try { instance.FiltersAndFinally(); }
                        catch (Exception) { }
                        return Task.CompletedTask;

                      }, persistPrepareResultToFile: pathSerialize[0], doesNotReturnAttributes: _ => ["DoesNotReturnAttribute"]);

          return 0;

        }, [path]);

        CoverageResult result = TestInstrumentationHelper.GetCoverageResult(path);

        result.Document("Instrumentation.DoesNotReturn.cs")
            .AssertInstrumentLines(BuildConfiguration.Debug, 7, 8, 171, 173, 174, 175, 179, 180, 181, 182, 185, 186, 187, 188, 192, 193, 194)
            .AssertNonInstrumentedLines(BuildConfiguration.Debug, 176, 177, 183, 184, 189, 190, 195, 196, 197);
      }
      finally
      {
        File.Delete(path);
      }
    }
  }
}
