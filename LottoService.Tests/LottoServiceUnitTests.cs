using System;
using System.Linq;
using Moq;
using Xunit;

namespace LottoService.Tests
{
  // TODO: create setup method to avoid creating new service for each test
  // TODO: update to use Autofac
  // TODO: add tests for defensive checks
  public class LottoServiceUnitTests
  {
    [Fact]
    public void GenerateNumbers_ReturnsSixNumbers()
    {
      // arrange
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      // act
      var result = service.GenerateNumbers();
      // assert
      Assert.Equal(6, result.ToArray().Length);
    }

    [Fact]
    public void GenerateNumbers_ReturnsUniqueNumbers()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      var result = service.GenerateNumbers();
      // Use group by to remove duplicates and compare expected length
      var unique = result.GroupBy(x => x).Select(x => x).ToArray();
      Assert.Equal(6, unique.Length);
    }

    [Fact]
    public void GenerateNumbers_ReturnsOrderedNumbersAscending()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      var result = service.GenerateNumbers();
      var expectedOrder = result.OrderBy(x => x);
      Assert.Equal(expectedOrder, result);
    }

    [Fact]
    public void GenerateNumbers_NumToGenerateIsZero_ReturnsEmptyEnumerable()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      var result = service.GenerateNumbers(0);
      Assert.Empty(result);
    }

    [Fact]
    public void GenerateNumbers_NumToGenerateLessThanZero_ThrowsArgumentOutOfRangeException()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      Assert.Throws<ArgumentOutOfRangeException>(() => service.GenerateNumbers(-1));
    }

    [Fact]
    public void GenerateNumbers_MinLessThanOne_ThrowsArgumentOutOfRangeException()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      Assert.Throws<ArgumentOutOfRangeException>(() => service.GenerateNumbers(1, 0));
    }

    [Fact]
    public void GenerateNumbers_MaxLessThanOne_ThrowsArgumentOutOfRangeException()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      Assert.Throws<ArgumentOutOfRangeException>(() => service.GenerateNumbers(1, 1, 0));
    }

    [Fact]
    public void GenerateNumbers_MaxLessThanMin_ThrowsArgumentException()
    {
      var randNumSvc = BuildRandomNumberService();
      var service = (ILottoService)new LottoService(randNumSvc.Object);
      Assert.Throws<ArgumentException>(() => service.GenerateNumbers(1, 2, 1));
    }

    private Mock<IRandomNumberService<int>> BuildRandomNumberService()
    {
      var service = new Mock<IRandomNumberService<int>>();
      // Setup a mocked method which returns a sequence of numbers. It is out of order and contains duplicates
      service.SetupSequence(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(25).Returns(49).Returns(20).Returns(1).Returns(25).Returns(34).Returns(23).Returns(12);
      return service;
    }
  }
}
