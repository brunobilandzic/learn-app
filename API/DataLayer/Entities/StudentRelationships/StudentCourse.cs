using API.DataLayer.Entities.Identity;
using API.DataLayer.Entities.Learning;

namespace API.DataLayer.Entities.StudentRelationships
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; } = 0;
    }
}