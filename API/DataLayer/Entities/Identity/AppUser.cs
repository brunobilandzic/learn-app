using System.Collections.Generic;
using API.DataLayer.Entities.Learning;
using API.DataLayer.Entities.StudentRelationships;
using Microsoft.AspNetCore.Identity;

namespace API.DataLayer.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }

        public virtual ICollection<LearningTask> LearningTasks { get; set; }
    
    }
}