using APIMobileProduct.Data.Mapping;
using APIMobileProduct.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIMobileProduct.Data.Context
{
    public class OraContext : DbContext
    {
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<FunctionEntity> Functions { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<PermitEntity> Permits { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BasemapEntity> Basemaps { get; set; }
        public DbSet<OfflinemapEntity> Offlinemaps { get; set; }
        public DbSet<EventTypeEntity> EventType { get; set; }
        public DbSet<EventAliasEntity> EventAlias { get; set; }


        public OraContext(DbContextOptions<OraContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyEntity>(new CompanyMap().Configure);
            modelBuilder.Entity<FunctionEntity>(new FunctionMap().Configure);
            modelBuilder.Entity<ProfileEntity>(new ProfileMap().Configure);
            modelBuilder.Entity<PermitEntity>(new PermitMap().Configure);
            modelBuilder.Entity<GroupEntity>(new GroupMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<BasemapEntity>(new BasemapMap().Configure);
            modelBuilder.Entity<OfflinemapEntity>(new OfflinemapMap().Configure);
            modelBuilder.Entity<EventTypeEntity>(new EventTypeMap().Configure);
            modelBuilder.Entity<EventAliasEntity>(new EventAliasMap().Configure);
        }

    }
}

