using System;
using System.Collections.Generic;

namespace API.DataLayer.Entities.Learning
{
    public class LearningTask
    {
        public int LearningTaskId { get; set; }
        public int StudentId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int Importance { get; set; }

        public ICollection<LectureLearningTask> LectureLearningTasks { get; set; }
    }
}