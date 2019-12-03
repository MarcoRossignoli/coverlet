using Coverlet.Core.Abstracts;
using Coverlet.Core.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Coverlet.MSbuild.Tasks
{
    internal class ServiceProviderFactory
    {
        public static IServiceProvider Build(string mapPath)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IRetryHelper, RetryHelper>();
            serviceCollection.AddTransient<IProcessExitHandler, ProcessExitHandler>();
            serviceCollection.AddTransient<IFileSystem, FileSystem>();

            // We need to keep singleton/static semantics
            serviceCollection.AddSingleton<IInstrumentationHelper, InstrumentationHelper>(serviceProvider =>
            new InstrumentationHelper(
            serviceProvider.GetService<IProcessExitHandler>(),
            serviceProvider.GetService<IRetryHelper>(),
            serviceProvider.GetService<IFileSystem>(),
            mapPath));

            return serviceCollection.BuildServiceProvider();
        }
    }
}