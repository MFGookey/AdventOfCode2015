using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Utilities.TwoD;

namespace CaretNavigation.Core
{
  public class Navigator
  {
    private ICollection<Point> _visitedHouses;

    public Navigator(string route) : this(route, 0, 0)
    { }

    public Navigator(string route, int startingRow, int startingColumn)
    {
      _visitedHouses = new List<Point>();
      var lastPoint = new Point(startingRow, startingColumn);
      _visitedHouses.Add(lastPoint);
      foreach (var step in route.ToCharArray())
      {
        switch (step)
        {
          case '^':
            lastPoint = new Point(lastPoint.Row - 1, lastPoint.Column);
            break;
          case 'v':
            lastPoint = new Point(lastPoint.Row + 1, lastPoint.Column);
            break;
          case '>':
            lastPoint = new Point(lastPoint.Row, lastPoint.Column + 1);
            break;
          case '<':
            lastPoint = new Point(lastPoint.Row, lastPoint.Column - 1);
            break;
          default:
            throw new ArgumentException($"Route step \'{step}\' is not a valid step.", nameof(route));
        }

        _visitedHouses.Add(lastPoint);
      }
    }

    public IEnumerable<Point> GetRoutePoints()
    {
      return _visitedHouses;
    }

    public int GetDistinctPoints()
    {
      return _visitedHouses.Distinct().Count();
    }
  }
}
