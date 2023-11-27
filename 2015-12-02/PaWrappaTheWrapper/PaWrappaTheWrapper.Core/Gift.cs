using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PaWrappaTheWrapper.Core
{
  internal class Gift
  {
    public int Length
    {
      get; private set;
    }

    public int Width
    {
      get;
      private set;
    }

    public int Height
    {
      get;
      private set;
    }

    public Gift(string dimensions)
    {
      string parsePattern = @"^([1-9]\d*)x([1-9]\d*)x([1-9]\d*)$";
      // dimensions are of the form [1-9]\d*x[1-9]\d*x[1-9]\d*
      if (!Regex.IsMatch(dimensions, parsePattern))
      {
        throw new ArgumentException($"Dimension string \"{dimensions}\" does not match the format \"{{length}}x{{width}}x{{height}}\"", nameof(dimensions));
      }

      var matches = Regex.Matches(dimensions, parsePattern);
      this.Length = int.Parse(matches[0].Groups[1].Value);
      this.Width = int.Parse(matches[0].Groups[2].Value);
      this.Height = int.Parse(matches[0].Groups[3].Value);
    }

    private IEnumerable<int> GetFaceAreas()
    {
      return new[]
      {
        this.Length * this.Width,
        this.Length * this.Height,
        this.Width * this.Height
      };
    }

    public int GetWrappingSize()
    {
      var areas = this.GetFaceAreas();
      return areas.Sum() * 2 + areas.Min();
    }

    private IEnumerable<int> GetFacePerimeters()
    {
      return new[]
      {
        2 * (this.Length + this.Width),
        2 * (this.Length + this.Height),
        2 * (this.Width + this.Height)
      };
    }

    private int GetVolume()
    {
      return this.Length * this.Width * this.Height;
    }

    public int GetRibbonLength()
    {
      return this.GetFacePerimeters().Min() + this.GetVolume();
    }
  }
}
