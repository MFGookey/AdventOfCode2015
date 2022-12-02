using System;
using Common.Utilities.IO;
using StairMaster.Core;

namespace StairMaster.Cmd
{
  /// <summary>
  /// The entrypoint for StairMaster.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// StairMaster.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();
      var data = reader.ReadFile(filePath);
      Console.WriteLine(StairCalculator.Calculate(data));
      Console.WriteLine(StairCalculator.FindFirstBasement(data));
      _ = Console.ReadLine();
    }
  }
}
