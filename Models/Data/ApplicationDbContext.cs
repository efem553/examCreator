using Microsoft.EntityFrameworkCore;

namespace examCreator.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IWebHostEnvironment _environment;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
            DbPath = _environment.WebRootPath + "\\sqlite\\examCreator.db";
        }
        public DbSet<ApplicationUser>? ApplicationUser { get; set; }

        public string? DbPath { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }
}
