using Autofac;
using Day1.Model;

namespace Day1.Autofac;

public class Day1Module : Module 
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Executor>().SingleInstance();
        builder.RegisterType<CalibrationValueProvider>().SingleInstance();
        base.Load(builder);
    }
}