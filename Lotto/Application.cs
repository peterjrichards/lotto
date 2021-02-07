using System;
using LottoService;

namespace Lotto
{
  sealed class Application
  {
    private ILottoService _service;
    private readonly ILottoConsoleWriter _writer;

    public Application(ILottoService service, ILottoConsoleWriter writer)
    {
      _service = service;
      _writer = writer;
    }

    internal void Run()
    {
      var lottoNumbers = _service.GenerateNumbers();
      _writer.Write(lottoNumbers);
    }
  }
}