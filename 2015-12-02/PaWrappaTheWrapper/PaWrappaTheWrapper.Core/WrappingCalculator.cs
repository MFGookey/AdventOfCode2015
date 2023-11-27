using System;
using System.Collections.Generic;
using System.Text;

namespace PaWrappaTheWrapper.Core
{
  public class WrappingCalculator
  {
    private readonly ICollection<Gift> _gifts;

    public WrappingCalculator(IEnumerable<string> giftDimensions)
    {
      _gifts = new List<Gift>();
      foreach(string gift in giftDimensions)
      {
        _gifts.Add(new Gift(gift));
      }
    }

    public long GetTotalWrappingArea()
    {
      long result = 0;
      foreach (var gift in _gifts)
      {
        result += gift.GetWrappingSize();
      }

      return result;
    }

    public long GetTotalRibbonLength()
    {
      long result = 0;
      foreach (var gift in _gifts)
      {
        result += gift.GetRibbonLength();
      }

      return result;
    }
  }
}
