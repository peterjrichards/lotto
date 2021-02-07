using System;
using System.Collections.Generic;

namespace Lotto
{
  public class LottoConsoleWriter : ILottoConsoleWriter
  {
    public void Write(IEnumerable<int> numbers)
    {
      // Need to be able to reset the console afterwards
      var initialFgColor = Console.ForegroundColor;
      var initialBgColor = Console.BackgroundColor;

      Console.ForegroundColor = ConsoleColor.Black;

      foreach (var num in numbers)
      {
        Console.BackgroundColor = GetBackgroundColor(num);
        // Ensure each number has the same width 
        Console.Write($"{num,2}");
        Console.BackgroundColor = initialBgColor;
        Console.Write(" ");
      }

      // Reset console
      Console.ForegroundColor = initialFgColor;
      Console.BackgroundColor = initialBgColor;
    }
    private ConsoleColor GetBackgroundColor(int num)
    {
      // Determine the colour based on value. Using return statements to avoid checking lower bound multiple times
      switch (num)
      {
        case int i when (i <= 9):
          return ConsoleColor.Gray;
        case int i when (i <= 19):
          return ConsoleColor.Blue;
        case int i when (i <= 29):
          return ConsoleColor.Magenta;
        case int i when (i <= 39):
          return ConsoleColor.Green;
        default:
          return ConsoleColor.Yellow;
      }
    }
  }
}