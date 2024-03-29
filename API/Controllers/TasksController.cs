using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.UnitOfWork;
using API.DTOs;
using API.DTOs.Generic;
using API.Errors;
using API.Services.ClaimsExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class TasksController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public TasksController(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningTaskDto>>> GetLearningTasks()
        {
            var learningTasks = await _unitOfWork.LearningTasksRepository
                .GetLearningTasks(User.GetUserId());

            return Ok(learningTasks);
        }

        [HttpGet("{learningTaskId}")]
        public async Task<ActionResult<LearningTaskDto>> GetLearningTask(int learningTaskId)
        {
            var learningTask = await _unitOfWork.LearningTasksRepository
                .GetLearningTaskWithLectures(learningTaskId, User.GetUserId());

            return Ok(learningTask);
        }

        [HttpGet("w/{lectureId}")]
        public async Task<ActionResult<LearningTaskMinDto>> GetLearningTaskWithLecture(int lectureId)
        {
            var learningTask = await _unitOfWork.LearningTasksRepository
                .TaskForLecture(lectureId, User.GetUserId());

            return Ok(learningTask);
        }

        [HttpPost]
         public async Task<ActionResult<LearningTaskDto>> CreateLearningTask(LearningTaskDto learningTaskDto)
         {
             return Ok(await _unitOfWork.LearningTasksRepository.CreateLearningTask(learningTaskDto, User.GetUserId()));            
         }

         [HttpPost("lectures")]
         public async Task<ActionResult> AddLecturesToLearningTask(IdsToId lecturesToTask)
        {
            await _unitOfWork.LearningTasksRepository
                .AddLecturesToLearningTask(lecturesToTask, User.GetUserId());

            if(await _unitOfWork.SaveAllChanges() <= 0) throw new InternalServerException("Failed to add lectures to task");

            return Ok();
        }

        [HttpPost("lecture-completion")]
         public async Task<ActionResult> ToggleLectureCompletion(IdToId lectureIdTaskId)
        {
            await _unitOfWork.LearningTasksRepository
                .ToggleLectureCompletion(lectureIdTaskId.FirstId, lectureIdTaskId.SecondId);

            if(await _unitOfWork.SaveAllChanges() <= 0) throw new InternalServerException("Failed to create new learning task");

            return Ok();
        }

        [HttpPost("complete/{learningTaskId}")]
        public async Task<ActionResult> CompleteWholeTask(int learningTaskId)
        {
            await _unitOfWork.LearningTasksRepository
                .CompleteWholeLearningTask(learningTaskId);

            if(await _unitOfWork.SaveAllChanges() <= 0) throw new InternalServerException("Failed to mark task complete.");

            return Ok();
        }

        [HttpDelete("{learningTaskId}")]
        public async Task<ActionResult> RemoveLearningTask(int learningTaskId)
        {
            await _unitOfWork.LearningTasksRepository
                .RemoveLearningTask(learningTaskId);

            return Ok();
        }

        [HttpDelete("lecture")]
        public async Task<ActionResult> RemoveLectureFromTask(IdToId lectureTaskIds)
        {
            await _unitOfWork.LearningTasksRepository
                .RemoveLectureFromTask(lectureTaskIds);
            
            if(await _unitOfWork.SaveAllChanges() <= 0) throw new InternalServerException("Failed to delete the lecture from task");

            return Ok();
        }

    }
}