using Microsoft.EntityFrameworkCore;
using Minunetcore.Models;

namespace Minunetcore.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext (DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        public DbSet<Datamodel> Mydata { get; set; }
    }
}
