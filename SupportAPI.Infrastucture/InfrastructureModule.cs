using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupportAPI.Domain;
using SupportAPI.Domain.Interfaces.Infrastructure;

namespace SupportAPI.Infrastucture
{
    public static class InfrastructureModule
    {
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITeamworkAdapter, TeamworkAdapter>();
            services.AddSingleton<ITeamhoodAdapter, TeamhoodAdapter>();

            services.AddHttpClient(Constants.HttpClientTeamwork)
                .ConfigureHttpClient(client =>
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Add("User-Agent", "SupportAPI");
                    client.BaseAddress = new Uri("");
                });

            services.AddHttpClient(Constants.HttpClientTeamhood)
                .ConfigureHttpClient(client =>
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    client.DefaultRequestHeaders.Add("User-Agent", "SupportAPI");
                    client.DefaultRequestHeaders.Add("X-ApiKey", "");
                    client.BaseAddress = new Uri("");
                });
        }
    }
}
