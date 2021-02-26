using System.Diagnostics.CodeAnalysis;
using KHahn.ApplicationProcess.February2021.Data.DataAccess;
using KHahn.ApplicationProcess.February2021.Data.Persistence;
using KHahn.ApplicationProcess.February2021.Data.Persistence.Repositories;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace KHahn.ApplicationProcess.February2021.Data.ExtensionMethods
{
    public static class UnitOfWorkExtensionMethod
    {
        public static IServiceCollection SetupUnitOfWork([NotNullAttribute] this IServiceCollection serviceCollection)
        {
            //TODO: Find a way to inject the repositories and share the same context without creating a instance.
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(f =>
            {
                var scopeFactory = f.GetRequiredService<IServiceScopeFactory>();
                var context = f.GetService<KHahnApplicationProcessContext>();
                return new UnitOfWork(
                    context,
                    new AssetsRepository(context.Assets)
                );
            });
            return serviceCollection;
        }
    }
}