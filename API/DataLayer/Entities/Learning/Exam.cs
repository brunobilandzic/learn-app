using System;
using System.Collections.Generic;
using API.DataLayer.Entities.StudentRelationships;

namespace API.DataLayer.Entities.Learning
{
    public class Exam
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
    }
}