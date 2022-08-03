using System;
using APIMobileProduct.Domain.Interfaces.Services.Company;
using APIMobileProduct.Domain.Interfaces.Services.Function;
using APIMobileProduct.Domain.Interfaces.Services.Group;
using APIMobileProduct.Domain.Interfaces.Services.Profile;
using APIMobileProduct.Domain.Interfaces.Services.User;
using APIMobileProduct.Domain.Interfaces.Services.Basemap;
using APIMobileProduct.Domain.Interfaces.Services.Event;
using APIMobileProduct.Domain.Interfaces.Services.Offlinemap;
using APIMobileProduct.Service.Services;
using Microsoft.Extensions.DependencyInjection;



namespace APIMobileProduct.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICompanyService, CompanyService>();
            serviceCollection.AddTransient<IFunctionService, FunctionService>();
            serviceCollection.AddTransient<IProfileService, ProfileService>();
            serviceCollection.AddTransient<IGroupService, GroupService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IBasemapService, BasemapService>();
            serviceCollection.AddTransient<IOfflinemapService, OfflinemapService>();
            serviceCollection.AddTransient<IEventTypeService, EventTypeService>();
            serviceCollection.AddTransient<IEventAliasService, EventAliasService>();
        }

    }
}
