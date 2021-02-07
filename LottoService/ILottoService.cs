using System.Collections.Generic;

namespace LottoService
{
  public interface ILottoService
  {
    /// <summary>Returns an IEnumerable of integers within a range, of the specified size (count).</summary>
    /// <param name="count">The number of integers to generate.</param>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The inclusive upper bound of the random number returned.</param>
    /// <returns>Returns an IEnumerable of integers within specified range.</returns>
    IEnumerable<int> GenerateNumbers(int count = 6, int min = 1, int max = 49);
  }
}