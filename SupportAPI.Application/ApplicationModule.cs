using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupportAPI.Application.Services;
using SupportAPI.Domain.Interfaces.Application;

namespace SupportAPI.Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITeamworkTicketService, TeamworkTicketService>();
            services.AddSingleton<ITeamhoodTaskService, TeamhoodTaskService>();
        }
    }
}