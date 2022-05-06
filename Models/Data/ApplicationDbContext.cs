using Microsoft.EntityFrameworkCore;

namespace examCreator.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IWebHostEnvironment _environment;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment environment) : base(options)
        {
            _environment = environment;
            //I know this is the worst place to keep db.
            DbPath = _environment.WebRootPath + "\\sqlite\\examCreator.db";
        }
        public DbSet<ApplicationUser>? ApplicationUser { get; set; }

        public DbSet<Exam>? Exam { get; set; }

        public DbSet<Question>? Question { get; set; }

        public string? DbPath { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasIndex(x=>x.UserName).IsUnique();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    UserId = Guid.Parse("ea5ae113-c88e-4b4b-a7b2-dae9d34840aa"),
                    UserName ="admin",
                    Password ="Temp1234*"
                }
                );
            base.OnModelCreating(builder);
        }
        

    }
}
