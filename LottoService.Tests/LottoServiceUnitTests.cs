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

    [Fact]
    public void GenerateNumbers_ReturnsUniqueNumbers()
    {
      var service = (ILottoService)new LottoService();
      var result = service.GenerateNumbers();
      // Use group by to remove duplicates and compare expected length
      var unique = result.GroupBy(x => x).Select(x => x).ToArray();
      Assert.Equal(6, unique.Length);
    }
  }
}
