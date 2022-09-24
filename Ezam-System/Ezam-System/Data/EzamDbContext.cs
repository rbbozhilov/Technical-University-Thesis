using Ezam_System.Data.Models;
using Ezam_System.Data.Models.Exam;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ezam_System.Data
{
    public class EzamDbContext : IdentityDbContext<User>
    {
        public EzamDbContext(DbContextOptions<EzamDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Staff> Staff { get; set; }

        public virtual DbSet<Dissertation> Dissertations { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Models.Exam.Type> Types { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }


    }
}