// See https://aka.ms/new-console-template for more information

using Autofac;
using Common;
using Day3;
using Day3.Autofac;


ContainerProvider.GetContainer(new Day3Module()).Resolve<Executor>().Execute();