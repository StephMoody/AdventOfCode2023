using Autofac;

namespace Common;

public class ContainerProvider
{
    public static IContainer GetContainer(Module? module)
    {
        ContainerBuilder containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<PuzzleInputReader>().SingleInstance();
        if (module != null) 
            containerBuilder.RegisterModule(module);
        
        return containerBuilder.Build();
    }
}