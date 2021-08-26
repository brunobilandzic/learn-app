using API.DataLayer.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.DataLayer.EfCode.Configurations
{
    internal class StudentConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity
                .HasMany(s => s.StudentCourses)
                .WithOne()
                .HasForeignKey(sc => sc.StudentId);
            
            entity
                .HasMany(s => s.StudentExams)
                .WithOne()
                .HasForeignKey(se => se.StudentId);

            entity
                .HasMany(s => s.LearningTasks)
                .WithOne()
                .HasForeignKey(lt => lt.StudentId);

        }
    }
}