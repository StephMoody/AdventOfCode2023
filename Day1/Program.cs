// See https://aka.ms/new-console-template for more information

using Autofac;
using Day1;
using Day1.Autofac;

ContainerProvider.GetContainer().Resolve<Executor>().Execute();