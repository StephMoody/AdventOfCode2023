// See https://aka.ms/new-console-template for more information

using Autofac;
using Common;
using Day4;
using Day4.Autofac;


ContainerProvider.GetContainer(new Day4Module()).Resolve<Executor>().Execute();