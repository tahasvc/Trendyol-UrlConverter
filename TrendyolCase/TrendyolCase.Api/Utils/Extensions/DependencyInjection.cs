

using Microsoft.Extensions.DependencyInjection;
using TrendyolCase.Core.Interfaces.Repositories;
using TrendyolCase.Core.Interfaces.Services;
using TrendyolCase.Core.Repository;
using TrendyolCase.Infrastructure.Services;

namespace TrendyolCase.Api.Utils.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectsCollection(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IConverterService, ConverterService>()
                .AddScoped<IConverterRepository, ConverterRepository>()
                .AddScoped<IExceptionRepository,ExceptionRepository>();
        }
    }
}
