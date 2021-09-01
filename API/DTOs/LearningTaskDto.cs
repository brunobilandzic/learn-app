using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class LearningTaskDto
    {
        public string Tag { get; set; }
        public int LearningTaskId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int Importance { get; set; }
        public List<LectureLearningTaskDto> Lectures { get; set; }
    }
}