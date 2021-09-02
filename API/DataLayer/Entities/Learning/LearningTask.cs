using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DataLayer.Entities.Learning
{
    public class LearningTask
    {
        [Required]
        public string Tag { get; set; }
        public int LearningTaskId { get; set; }
        public int StudentId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int Importance { get; set; }

        public virtual ICollection<LectureLearningTask> LectureLearningTasks { get; set; }
    }
}