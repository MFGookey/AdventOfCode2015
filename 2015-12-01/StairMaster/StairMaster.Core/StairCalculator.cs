using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StairMaster.Core
{
  public static class StairCalculator
  {
    public static int Calculate(string data)
    {
      var currentFloor = 0;
      foreach (var step in data.ToCharArray().Where(c => c == '(' || c == ')').Select(c => c == '(' ? 1 : -1))
      {
        currentFloor += step;
      }

      return currentFloor;
    }

    public static int FindFirstBasement(string data)
    {
      var currentFloor = 0;
      var index = 0;
      foreach (var step in data.ToCharArray().Where(c => c == '(' || c == ')').Select(c => c == '(' ? 1 : -1))
      {
        currentFloor += step;
        index++;
        if (currentFloor == -1)
        {
          break;
        }
      }

      return index;
    }
  }
}
