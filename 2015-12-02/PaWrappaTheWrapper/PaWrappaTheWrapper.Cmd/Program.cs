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
      var calc = new WrappingCalculator(reader.ReadFileByLines(filePath));
      
      Console.WriteLine(calc.GetTotalWrappingArea());
      _ = Console.ReadLine();
    }
  }
}
