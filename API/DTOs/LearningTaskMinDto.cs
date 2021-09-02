using System;

namespace API.DTOs
{
    public class LearningTaskMinDto
    {
        public string Tag { get; set; }
        public int LearningTaskId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int Importance { get; set; }
        public bool Completed { get; set; }
        public int LecturesCount { get; set; }
        public int CompletedLecturesCount { get; set; }
    }
}