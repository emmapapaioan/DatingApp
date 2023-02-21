using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    // This class inherits from the DbContext class, which provides methods for interacting with the database
    // The DataContext class includes a constructor that accepts a DbContextOptions object, which is used to 
    // configure the database connection. The constructor calls the base constructor to initialize the DbContext
    // The DataContext class also includes a DbSet property for the AppUser class, which represents the user data in the database
    // The DbSet allows the DataContext to interact with the user data by providing methods for querying, adding, updating, and 
    // deleting user data.
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        public DbSet<AppUser> Users {get; set;}
    }
}