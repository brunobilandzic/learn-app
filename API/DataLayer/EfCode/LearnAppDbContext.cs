using API.DataLayer.EfCode.Configurations;
using API.DataLayer.Entities.Identity;
using API.DataLayer.Entities.Learning;
using API.DataLayer.Entities.StudentRelationships;
using Microsoft.EntityFrameworkCore;

namespace API.DataLayer.EfCode.DbSetup
{
    public class LearnAppDbContext : DbContext
    {
        public LearnAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<LearningTask> LearningTasks { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<LectureLearningTask> LectureLearningTasks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        /****************************
         Other tables created by EF
         from navigational props...
        ****************************/
        
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StudentConfig());

            builder.Entity<LectureLearningTask>()
                .HasKey(llt => new {llt.LearningTaskId, llt.LectureId}); 
            builder.Entity<StudentCourse>()
                .HasKey(sc => new {sc.CourseId, sc.StudentId});
            builder.Entity<StudentExam>()
                .HasKey(se => new {se.StudentId, se.ExamId});
        }
        
    }
}