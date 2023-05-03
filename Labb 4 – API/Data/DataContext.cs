using Labb_4___API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4___API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbys { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}
