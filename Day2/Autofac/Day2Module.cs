
using Autofac;
using Day2.Data;
using Day2.Model;

namespace Day2;

public class Day2Module : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GameDataProvider>().SingleInstance();
        builder.RegisterType<GrabValidator>().SingleInstance();
        builder.RegisterType<Executor>().SingleInstance();
        
        base.Load(builder);
    }
}