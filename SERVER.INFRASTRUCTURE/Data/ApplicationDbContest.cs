using Microsoft.EntityFrameworkCore;
using SERVER.CORE.Entities;

namespace SERVER.INFRASTRUCTURE.Data
{
    public class ApplicationDbContest : DbContext
    {
        public ApplicationDbContest(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContest()
        {
        }

        public DbSet<User> Users { get; set; }
    }
}