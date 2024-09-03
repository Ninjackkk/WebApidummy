using Microsoft.EntityFrameworkCore;
using WebApidummy.Models;

namespace WebApidummy.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Emp> EmpDetails { get; set; }
    }
}
