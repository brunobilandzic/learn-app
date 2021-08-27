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

        [HttpPost]
         public async Task<ActionResult<LearningTaskDto>> CreateLearningTask(LearningTaskDto learningTaskDto)
         {
             return Ok(await _unitOfWork.LearningTasksRepository.CreateLearningTask(learningTaskDto, User.GetUserId()));            
         }

         [HttpPost("lectures")]
         public async Task<ActionResult> AddLecturesToLearningTask(IdsToId lecturesToTask)
        {
            await _unitOfWork.LearningTasksRepository
                .AddLecturesToLearningTask(lecturesToTask);

            if(await _unitOfWork.SaveAllChanges() <= 0) throw new InternalServerException("Failed to create new learning task");

            return Ok();
        }

        [HttpPost("lecture-completion")]
         public async Task<ActionResult> AddLecturesToLearningTask(IdToId lectureIdTaskId)
        {
            await _unitOfWork.LearningTasksRepository
                .ToggleLectureCompletion(lectureIdTaskId.FirstId, lectureIdTaskId.SecondId);

            if(await _unitOfWork.SaveAllChanges() <= 0) throw new InternalServerException("Failed to create new learning task");

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