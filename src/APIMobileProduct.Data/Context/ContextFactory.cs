using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace APIMobileProduct.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<OraContext>
    {
        public OraContext CreateDbContext(string[] args)
        {
            //Usado para criar Migrações
            //172.16.0.11
            var connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.0.11)(PORT=1522))(CONNECT_DATA=(SERVICE_NAME=GEO)));User Id=sde;Password=SDE#ctc+2021;";
            var optionsBuilder = new DbContextOptionsBuilder<OraContext>();
            optionsBuilder.UseOracle(connectionString);
            // var db = new ContextNameContext(optionsBuilder.Options)
            return new OraContext(optionsBuilder.Options);
        }
    }
}
