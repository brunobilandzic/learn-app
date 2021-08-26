using API.DataLayer.Entities.Learning;

namespace API.DataLayer.Entities.StudentRelationships
{
    public class StudentExam
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; } = 0;
    }
}