using System;
using System.Collections.Generic;

namespace LottoService
{
  public class LottoService : ILottoService
  {
    protected readonly Random _random;

    public LottoService()
    {
      _random = new Random();
    }

    public IEnumerable<int> GenerateNumbers(int count = 6, int min = 1, int max = 49)
    {
      var numbers = new HashSet<int>();
      while (numbers.Count < count)
      {
        var num = _random.Next(min, max);
        // Check and exclude duplicate
        if (!numbers.Contains(num))
        {
          numbers.Add(num);
        }
      }
      return numbers;
    }
  }
}
