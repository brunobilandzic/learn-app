using System;

namespace API.DTOs
{
    public class ExamDto
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateTimeStart { get; set; }
    }
}