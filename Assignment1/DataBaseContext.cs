using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
    public class DataBaseContext : DbContext
    {
        public DbSet<MyEntity> MyEntity { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("server=.; DataBase=Assignment1Db; Integrated Security=true");
        }
    }

}
