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
