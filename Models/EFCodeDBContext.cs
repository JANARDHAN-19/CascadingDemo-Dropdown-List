using Microsoft.EntityFrameworkCore;
namespace CascadingDemo.Models
{
    public class EFCodeDBContext : DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public EFCodeDBContext() : base()
        {
        }

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=HP\SQLSERVERDEV;Database=EFCoreDemoDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        //Adding Domain Classes as DbSet Properties
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}