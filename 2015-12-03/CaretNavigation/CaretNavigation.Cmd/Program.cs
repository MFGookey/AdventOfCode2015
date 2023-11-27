using System;
using System.Collections.Generic;
using System.Linq;
using CaretNavigation.Core;
using Common.Utilities.IO;
using Common.Utilities.TwoD;

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

      var testOddNavigator = new Navigator(new string("^v".ToCharArray().Where((c, index) => { return index % 2 == 0; }).ToArray<char>()));
      var testEvenNavigator = new Navigator(new string("^v".ToCharArray().Where((c, index) => { return index % 2 == 1; }).ToArray<char>()));
      foreach (var point in testOddNavigator.GetRoutePoints())
      {
        Console.WriteLine(point);
      }
      Console.WriteLine();


      foreach (var point in testEvenNavigator.GetRoutePoints())
      {
        Console.WriteLine(point);
      }

      var testVisitedPoints = new List<Point>(testOddNavigator.GetRoutePoints());
      testVisitedPoints.AddRange(testEvenNavigator.GetRoutePoints());
      Console.WriteLine(testVisitedPoints.Distinct().Count());

      var oddNavigator = new Navigator(new string(reader.ReadFile(filePath).ToCharArray().Where((c, index) => { return index % 2 == 0; }).ToArray<char>()));
      var evenNavigator = new Navigator(new string(reader.ReadFile(filePath).ToCharArray().Where((c, index) => { return index % 2 == 1; }).ToArray<char>()));

      var visitedPoints = new List<Point>(oddNavigator.GetRoutePoints());
      visitedPoints.AddRange(evenNavigator.GetRoutePoints());
      Console.WriteLine(visitedPoints.Distinct().Count());

      _ = Console.ReadLine();
    }
  }
}
