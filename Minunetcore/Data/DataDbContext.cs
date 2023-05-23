using Microsoft.EntityFrameworkCore;
using Minunetcore.Models;

namespace Minunetcore.Data
{
    public class DataDbContext
    {
        public DbSet<Datamodel> Mydata { get; set; }
    }
}
