

using Autofac;
using Day4.Model;

namespace Day4.Autofac;

public class Day4Module : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Executor>().AsSelf();
        builder.RegisterType<CardReader>().AsSelf();
        builder.RegisterType<CardCounter>().AsSelf();
        builder.RegisterType<GamePointCalculator>().AsSelf();
        base.Load(builder);
    }
}