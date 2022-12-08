using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sql de dahada geliştirme yapılmak istenirse "EF Fluent Mapping" yazarak bakabiliriz


            // Model oluşturulduğunda Brand nesnesi hangi tabloya karşılık gelmesi gerektiği yazılır "Brands"
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id); // Pk
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.Models); // Bir markanın birden çok modeli olabilir HasMany
            });

            modelBuilder.Entity<Model>(a =>
            {
                a.ToTable("Models").HasKey(k => k.Id); // Pk
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.BrandId).HasColumnName("BrandId"); // FK ( yabancıl anahtar / foreing key )
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

                a.HasOne(p => p.Brand); // Bir Modelin bir tane markası olur onu belirttik
            });



            Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") }; // Migrate ettiğimde bana bir iki tane test datası oluşturması için
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);


            Model[] modelEntitySeeds = { new(1, 1, "Series 4", 1500, ""), new(2, 1, "Series 3", 1200, ""), new(3, 2, "A180", 1000, "") };
            modelBuilder.Entity<Model>().HasData(modelEntitySeeds);


        }
    }
}
