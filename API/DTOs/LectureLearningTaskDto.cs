namespace API.DTOs
{
    public class LectureLearningTaskDto
    {
        public int LectureId { get; set; }
        public string Topic { get; set; }
        public int LearningTaskId { get; set; }
        public bool Completed { get; set; } = false;
    }
}