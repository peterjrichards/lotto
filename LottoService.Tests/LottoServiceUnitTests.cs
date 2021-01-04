using System.Linq;
using Xunit;

namespace LottoService.Tests
{
  public class LottoServiceUnitTests
  {
    [Fact]
    public void GenerateNumbers_ReturnsSixNumbers()
    {
      // arrange
      var service = (ILottoService)new LottoService();
      // act
      var result = service.GenerateNumbers();
      // assert
      Assert.Equal(6, result.ToArray().Length);
    }
  }
}
