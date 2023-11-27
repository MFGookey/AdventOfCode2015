using System;
using Common.Utilities.IO;
using PaWrappaTheWrapper.Core;

namespace PaWrappaTheWrapper.Cmd
{
  /// <summary>
  /// The entrypoint for PaWrappaTheWrapper.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// PaWrappaTheWrapper.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();
      var testCalc = new WrappingCalculator(new[] { "2x3x4", "1x1x10" });
      Console.WriteLine(testCalc.GetTotalWrappingArea());
      Console.WriteLine(testCalc.GetTotalRibbonLength());

      var calc = new WrappingCalculator(reader.ReadFileByLines(filePath));
      
      Console.WriteLine(calc.GetTotalWrappingArea());
      Console.WriteLine(calc.GetTotalRibbonLength());
      _ = Console.ReadLine();
    }
  }
}
