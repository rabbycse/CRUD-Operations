using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data.Entities;

namespace StudentApp.Data.Data  
{
    public class StudentAppContext : DbContext 
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public StudentAppContext(string connectionString, string migrationAssemblyName)  
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(_connectionString, b => b.MigrationsAssembly(_migrationAssemblyName));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<StudentCourses>()
                 .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder
                .Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder
                .Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder
                .Entity<CourseTopic>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.Topics)
                .HasForeignKey(sc => sc.CourseId); 
        }

        public DbSet<Student> Students { get; set; } 
        public DbSet<Course> Courses { get; set; }
     
    }
}
