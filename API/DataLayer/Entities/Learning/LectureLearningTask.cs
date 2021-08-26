namespace API.DataLayer.Entities.Learning
{
    public class LectureLearningTask
    {
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }
        public LearningTask LectureTask { get; set; }
        public int LearningTaskId { get; set; }
        public bool Completed { get; set; } = false;
    }
}