using APIMobileProduct.Data.Context;
using APIMobileProduct.Data.Repository;
using APIMobileProduct.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using APIMobileProduct.Domain.Repository;
using APIMobileProduct.Data.Implementations;

namespace APIMobileProduct.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped<IProfileRepository, ProfileImplementation>();
            serviceCollection.AddScoped<IPermitRepository, PermitImplementation>();
            serviceCollection.AddScoped<IGroupRepository, GroupImplementation>();
            serviceCollection.AddScoped<IBasemapRepository, BasemapImplementation>();
            serviceCollection.AddScoped<IOfflinemapRepository, OfflinemapImplementation>();
            serviceCollection.AddScoped<IEventAliasRepository, EventAliasImplementation>();
            //PRD-ORA-011
            serviceCollection.AddDbContext<OraContext>(options => options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522))(CONNECT_DATA=(SERVICE_NAME=GEO)));User Id=sde;Password=pass;"));
        }
    }
}
