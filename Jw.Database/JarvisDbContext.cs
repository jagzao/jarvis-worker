using Jw.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jw.Database
{
    public class JarvisDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public JarvisDbContext(DbContextOptions<JarvisDbContext> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Log> Loggers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<TenantProcess> TenantProcesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().ToTable("Logger");
            modelBuilder.Entity<Tenant>().ToTable("Tenant");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Process>().ToTable("Process");
            modelBuilder.Entity<TenantProcess>().ToTable("TenantProcess");
            modelBuilder.Entity<TenantProcess>()
                .HasKey(tp => tp.Id);

            modelBuilder.Entity<TenantProcess>()
                .HasOne(tp => tp.Tenant)
                .WithMany(t => t.TenantProcesses)
                .HasForeignKey(tp => tp.TenantId);

            modelBuilder.Entity<TenantProcess>()
                .HasOne(tp => tp.Process)
                .WithMany(p => p.TenantProcesses)
                .HasForeignKey(tp => tp.ProcessId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("JarvisConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
