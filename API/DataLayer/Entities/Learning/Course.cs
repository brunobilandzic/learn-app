using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.DataLayer.Entities.StudentRelationships;

namespace API.DataLayer.Entities.Learning
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}