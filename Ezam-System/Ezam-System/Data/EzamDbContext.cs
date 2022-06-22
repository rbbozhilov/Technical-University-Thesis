using Ezam_System.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ezam_System.Data
{
    public class EzamDbContext : IdentityDbContext
    {
        public EzamDbContext(DbContextOptions<EzamDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Staff> Staff { get; set; }


    }
}