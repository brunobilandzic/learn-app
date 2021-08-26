using System.Collections.Generic;
using API.DataLayer.Entities.Learning;
using API.DataLayer.Entities.StudentRelationships;
using Microsoft.AspNetCore.Identity;

namespace API.DataLayer.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<StudentExam> StudentExams { get; set; }

        public ICollection<LearningTask> LearningTasks { get; set; }
    
    }
}