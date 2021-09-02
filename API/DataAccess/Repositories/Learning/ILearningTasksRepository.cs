using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Generic;

namespace API.DataAccess.Repositories.Learning
{
    public interface ILearningTasksRepository
    {
        Task<IEnumerable<LearningTaskMinDto>> GetLearningTasks(int studentId);
        Task<LearningTaskMinDto> CreateLearningTask(LearningTaskMinDto learningTaskDto, int studentId);
        Task AddLecturesToLearningTask(IdsToId lecturesToTask, int studentId);
        Task ToggleLectureCompletion(int lectureId, int learningTaskId);
        Task<LearningTaskDto> GetLearningTaskWithLectures(int learningTaskId);
        Task CompleteWholeLearningTask(int learningTaskId);
        Task RemoveLectureFromTask(IdToId lectureTaskIds);
        Task<LearningTaskDto> TaskForLecture(int lectureId);
        Task RemoveLearningTask(int learningTaskId);
    }
}