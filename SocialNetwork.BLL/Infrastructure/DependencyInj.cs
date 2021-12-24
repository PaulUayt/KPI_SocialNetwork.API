using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Infrastructure
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        //{
        //    services.AddScoped<IChatService, ChatService>();
        //    services.AddScoped<IFriendsService, FriendsService>();
        //    services.AddScoped<IMainPageService, MainPageService>();
        //    services.AddScoped<IMessListService, MessListService>();
        //    services.AddScoped<IAutorizationService, AutorizationService>();
        //    services.AddScoped<IRegistrationService, RegistrationService>();
        //    services.AddScoped<IUnitOfWork>(prov => new EFUnitOfWork(connectionString));
        //    return services;
        //}
    }
}
