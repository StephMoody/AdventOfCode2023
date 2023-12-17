

using Autofac;
using Day3.Model;

namespace Day3.Autofac;

public class Day3Module : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Executor>().AsSelf();
        builder.RegisterType<MachineDataReader>().AsSelf();
        builder.RegisterType<MachineDataCalculator>().AsSelf();
        builder.RegisterType<Part2MachineDataReader>().AsSelf();
        base.Load(builder);
    }
}