using System;
using System.Collections.Generic;

namespace Lotto
{
  public class LottoConsoleWriter : ILottoConsoleWriter
  {
    public void Write(IEnumerable<int> numbers)
    {
      foreach (var num in numbers)
      {
        Console.Write(num);
        Console.Write(" ");
      }
    }
  }
}