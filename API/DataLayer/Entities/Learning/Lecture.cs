using System.Collections.Generic;

namespace API.DataLayer.Entities.Learning
{
    public class Lecture
    {
        public int LectureId { get; set; }

        public int CourseId { get; set; }

        public string Topic { get; set; }

        public ICollection<LectureLearningTask> LectureLearningTasks { get; set; }
    }
}