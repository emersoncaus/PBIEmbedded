using Microsoft.EntityFrameworkCore;
using PBIEmbedded.Domain;


namespace PBIEmbedded.Persistence.Contexts
{
    public class PBIEmbeddedContext : DbContext
    {
   
        public PBIEmbeddedContext(DbContextOptions<PBIEmbeddedContext> options) : base(options)
        {
            
        }
        public  DbSet<ServicePrincipal> ServicePrincipals { get; set; }
        public  DbSet<Dashboard> Dashboards { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<DashboardServicePrincipal> DashboardServicePrincipals { get; set; }
        public  DbSet<ServicePrincipalUser> ServicePrincipalUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<DashboardServicePrincipal>()
            .HasKey(DSP => new {DSP.DashboardId, DSP.ServicePrincipalId});

            modelBuilder.Entity<ServicePrincipalUser>()
            .HasKey(USP => new {USP.UserId, USP.ServicePrincipalId});

            modelBuilder.Entity<Dashboard>()
                        .HasMany(dsp => dsp.DashboardServicePrincipals)
                        .WithOne(d => d.Dashboard)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicePrincipal>()
                        .HasMany(dsp => dsp.DashboardServicePrincipals)
                        .WithOne(s => s.ServicePrincipal)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ServicePrincipal>()
                        .HasMany(spu => spu.ServicePrincipalsUser)
                        .WithOne(s => s.ServicePrincipal)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                        .HasMany(spu => spu.ServicePrincipalsUser)
                        .WithOne(u => u.User)
                        .OnDelete(DeleteBehavior.Cascade);
        }
 
    }
}