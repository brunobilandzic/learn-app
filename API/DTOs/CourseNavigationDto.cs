using System.Collections.Generic;

namespace API.DTOs
{
    public class CourseNavigationDto : CourseDto
    {
        public ICollection<LectureDto> Lectures { get; set; }
        public ICollection<ExamDto> Exams { get; set; }
    }
}