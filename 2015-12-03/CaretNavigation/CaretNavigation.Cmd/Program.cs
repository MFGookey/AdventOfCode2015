using System;
using CaretNavigation.Core;
using Common.Utilities.IO;

namespace CaretNavigation.Cmd
{
  /// <summary>
  /// The entrypoint for CaretNavigation.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// CaretNavigation.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();

      var testNavigator = new Navigator("^>v<");
      foreach(var point in testNavigator.GetRoutePoints())
      {
        Console.WriteLine(point);
      }

      Console.WriteLine(testNavigator.GetDistinctPoints());

      var navigator = new Navigator(reader.ReadFile(filePath));
      Console.WriteLine(navigator.GetDistinctPoints());
      _ = Console.ReadLine();
    }
  }
}
