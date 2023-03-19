using GraduationTracker.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationTracker.DAL
{
    public class GraduationContext : DbContext
    {
        public GraduationContext(DbContextOptions<GraduationContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        
        public DbSet<StudentGrade> StudentGrades { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Diploma> Diplomas{ get; set; }

        public DbSet<Requirement> Requirements { get; set; }
    }
}
