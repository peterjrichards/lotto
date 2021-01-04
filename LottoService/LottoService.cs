using System;
using System.Linq;
using System.Collections.Generic;

namespace LottoService
{
  public class LottoService : ILottoService
  {
    // Use Stategy pattern so a different random number generator can be used in future.
    protected readonly IRandomNumberService<int> _randomNumberService;

    public LottoService(IRandomNumberService<int> randomNumberService)
    {
      _randomNumberService = randomNumberService;
    }

    public IEnumerable<int> GenerateNumbers(int count = 6, int min = 1, int max = 49)
    {
      if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "cannot be negative");
      if (min < 1) throw new ArgumentOutOfRangeException(nameof(min), "must be greater than zero");
      if (max < 1) throw new ArgumentOutOfRangeException(nameof(min), "must be greater than zero");
      if (max <= min) throw new ArgumentException($"{nameof(max)} must be greater than {nameof(min)}");

      var numbers = new HashSet<int>();
      while (numbers.Count < count)
      {
        var num = _randomNumberService.Next(min, max);
        // Check and exclude duplicate
        if (!numbers.Contains(num))
        {
          numbers.Add(num);
        }
      }

      // Use Linq to return integers in ascending order
      return numbers.OrderBy(x => x);
    }
  }
}
