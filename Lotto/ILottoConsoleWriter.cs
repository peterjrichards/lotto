using System.Collections.Generic;

namespace Lotto
{
  public interface ILottoConsoleWriter
  {
    /// <summary>Write a enumerable set of integers to the Console.</summary>
    /// <param name="numbers">The numbers</param>
    void Write(IEnumerable<int> numbers);
  }
}