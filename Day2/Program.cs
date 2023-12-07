// See https://aka.ms/new-console-template for more information

using Autofac;
using Common;
using Day2;


ContainerProvider.GetContainer(new Day2Module()).Resolve<Executor>().Execute();