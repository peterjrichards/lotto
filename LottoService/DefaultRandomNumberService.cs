using System;

namespace LottoService
{
  /// <summary>A simple implementation of the IRandomNumberService using System.Random</summary>
  public sealed class DefaultRandomNumberService : IRandomNumberService<int>
  {
    private readonly Random _random;

    public DefaultRandomNumberService()
    {
      _random = new Random();
    }

    public int Next(int min, int max)
    {
      // add 1 to max to meet inferface specification
      return _random.Next(min, max + 1);
    }
  }
}