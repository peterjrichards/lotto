using System.Diagnostics.Contracts;
using LottoService;

namespace Lotto
{
  sealed class Application
  {
    private ILottoService _service;
    private readonly ILottoConsoleWriter _writer;

    public Application(ILottoService service, ILottoConsoleWriter writer)
    {
      Contract.Assert(service != null);
      _service = service;
      Contract.Assert(writer != null);
      _writer = writer;
    }

    internal void Run()
    {
      var lottoNumbers = _service.GenerateNumbers();
      _writer.Write(lottoNumbers);
    }
  }
}