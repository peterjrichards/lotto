using System;
using Autofac;

namespace Lotto
{
  // As Program is static then create an Application class so we can benefit from IoC / Dependency Injection using Autofac
  static class Program
  {
    private static IContainer CompositionRoot()
    {
      // Build the IoC container
      // TODO: introduce Autofac modules, i.e. CoreModule, ServiceModule
      var builder = new ContainerBuilder();
      builder.RegisterType<Application>();
      builder.RegisterType<LottoService.DefaultRandomNumberService>().As<LottoService.IRandomNumberService<int>>();
      builder.RegisterType<LottoService.LottoService>().As<LottoService.ILottoService>();
      return builder.Build();
    }

    static void Main(string[] args)
    {
      // Resolve the Application class and pass control
      // TODO: introduce CommandLineParser or similar NuGet package to add command line argument
      CompositionRoot().Resolve<Application>().Run();
    }
  }
}
