using Microsoft.EntityFrameworkCore;
using MyApp.DataLayer.Entities;


namespace MyApp.DataLayer
{
    public class AppDbContext : DbContext
    {
      
        public  DbSet<UserEntity> Users { get; set; }
        public  DbSet<BookEntity> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MyApp.db");
        }
    }
}
