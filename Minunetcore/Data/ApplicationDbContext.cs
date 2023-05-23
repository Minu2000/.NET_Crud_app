using Microsoft.EntityFrameworkCore;
using Minunetcore.Models;

namespace Minunetcore.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
        public DbSet<Country> Countries{ get; set; }
    }
}
