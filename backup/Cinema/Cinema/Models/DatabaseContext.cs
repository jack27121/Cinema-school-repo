using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Models
{
    /// <summary>
    /// forbindelse til en database server
    /// </summary>
    public class DatabaseContext : DbContext
    {
        //metode der bliver kaldt når klassen bliver anvendt
        // :base() call to super ctor
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.Migrate();
        }

        // hvis vi gerne vil have tabellerne bliver oprettet skal vi huske vores DbSet<>
        //public DbSet<klassenavn> objektNavn { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public DbSet<Cinema.Models.Customer> Customer { get; set; }

        public DbSet<Cinema.Models.Movie> Movie { get; set; }
    }
}