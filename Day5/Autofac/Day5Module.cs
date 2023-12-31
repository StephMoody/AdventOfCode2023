

using Autofac;
using Day5.Model;

namespace Day5.Autofac;

public class Day5Module : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Executor>().AsSelf();
        builder.RegisterType<PuzzleInputDivider>().AsSelf();
        builder.RegisterType<CategoryReader>().AsSelf();
        builder.RegisterType<LowestLocationCalculator>().AsSelf();
        base.Load(builder);
    }
}