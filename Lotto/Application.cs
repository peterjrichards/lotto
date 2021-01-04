using System;
using LottoService;

namespace Lotto
{
  sealed class Application
  {
    private ILottoService _lottoService;

    public Application(ILottoService lottoService)
    {
      _lottoService = lottoService;
    }

    internal void Run()
    {
      var lottoNumbers = _lottoService.GenerateNumbers();
      foreach (var num in lottoNumbers)
      {
        Console.Write(num);
        Console.Write(" ");
      }
    }
  }
}