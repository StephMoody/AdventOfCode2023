using Autofac;
using Day1.Model;

namespace Day1.Autofac;

public class ContainerProvider
{
    public static IContainer GetContainer()
    {
        ContainerBuilder containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<Executor>().SingleInstance();
        containerBuilder.RegisterType<CalibrationInputReader>().SingleInstance();
        containerBuilder.RegisterType<CalibrationValueProvider>().SingleInstance();
        return containerBuilder.Build();
    }
}