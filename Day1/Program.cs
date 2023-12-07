// See https://aka.ms/new-console-template for more information

using Autofac;
using Common;
using Day1;
using Day1.Autofac;

ContainerProvider.GetContainer(new Day1Module()).Resolve<Executor>().Execute();