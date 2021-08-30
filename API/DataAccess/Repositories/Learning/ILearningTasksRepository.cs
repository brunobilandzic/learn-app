using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Generic;

namespace API.DataAccess.Repositories.Learning
{
    public interface ILearningTasksRepository
    {
        Task<IEnumerable<LearningTaskDto>> GetLearningTasks(int studentId);
        Task<LearningTaskDto> CreateLearningTask(LearningTaskDto learningTaskDto, int studentId);
        Task AddLecturesToLearningTask(IdsToId lecturesToTask);
        Task ToggleLectureCompletion(int lectureId, int learningTaskId);
        Task RemoveLectureFromTask(IdToId lectureTaskIds);

        Task RemoveLearningTask(int learningTaskId);
    }
}