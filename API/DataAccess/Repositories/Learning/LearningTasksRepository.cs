using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Learning;
using API.DTOs;
using API.DTOs.Generic;
using API.Errors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories.Learning
{
    public class LearningTasksRepository : ILearningTasksRepository
    {
        private readonly LearnAppDbContext _context;
        private readonly IMapper _mapper;

        public LearningTasksRepository(
            LearnAppDbContext context,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddLecturesToLearningTask(IdsToId lecturesToTask, int studentId)
        { 
            foreach (var id in lecturesToTask.Ids)
            {
                var newLectureLearningTask = new LectureLearningTask
                {
                    LectureId = id,
                    LearningTaskId = lecturesToTask.Id
                };
                var lectureLearningTasksToDelete = await _context.LearningTasks
                    .Where(lt => lt.StudentId == studentId)
                    .SelectMany(lt => lt.LectureLearningTasks.Where(llt => llt.LectureId == id))
                    .ToListAsync();

                _context.LectureLearningTasks.RemoveRange(lectureLearningTasksToDelete);
                await _context.LectureLearningTasks.AddAsync(newLectureLearningTask);
            }
        }

        public async Task CompleteWholeLearningTask(int learningTaskId)
        {
            var lectureLearningTaskList = await _context.LectureLearningTasks
                .Where(llt => llt.LearningTaskId == learningTaskId)
                .ToListAsync();

            if(lectureLearningTaskList == null) throw new NotFoundException("Could not find any lectures in given task.");

            foreach (var task in lectureLearningTaskList)
            {
                task.Completed = true;
            }
        }

        public async Task<LearningTaskDto> CreateLearningTask(LearningTaskDto learningTaskDto, int studentId)
        {
            var newLearningTask = _mapper.Map<LearningTask>(learningTaskDto);

            newLearningTask.StudentId = studentId;

            await _context.AddAsync(newLearningTask);

            if(await _context.SaveChangesAsync() <= 0) throw new InternalServerException("Failed to create new learning task");

            return _mapper.Map<LearningTaskDto>(newLearningTask);
        }

        public async Task<IEnumerable<LearningTaskDto>> GetLearningTasks(int studentId)
        {
            return await _context.LearningTasks
                .Where(lt => lt.StudentId == studentId)
                .ProjectTo<LearningTaskDto>(_mapper.ConfigurationProvider)
                .ToListAsync();          
        }

        public async Task RemoveLearningTask(int learningTaskId)
        {
            var learningTask = new LearningTask 
            {
                LearningTaskId = learningTaskId
            };

            _context.LearningTasks.Attach(learningTask);
            _context.LearningTasks.Remove(learningTask);

            if(await _context.SaveChangesAsync() <= 0) throw new AppException(HttpStatusCode.BadRequest, "Failed to delete learning task.");
        }

        public async Task RemoveLectureFromTask(IdToId lectureTaskIds)
        {
            var lectureLearningTask = await _context.LectureLearningTasks
                .Where(llt => llt.LectureId == lectureTaskIds.FirstId && llt.LearningTaskId == lectureTaskIds.SecondId)
                .SingleOrDefaultAsync();

            if(lectureLearningTask == null) throw new NotFoundException("Did not found lecture in the task.");

            _context.LectureLearningTasks.Remove(lectureLearningTask);
        }

        public async Task<LearningTaskDto> TaskForLecture(int lectureId)
        {
            return await _context.LearningTasks
                .Where(lt => lt.LectureLearningTasks.Select(llt => llt.LectureId).Contains(lectureId))
                .ProjectTo<LearningTaskDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
        
        public async Task ToggleLectureCompletion(int lectureId, int learningTaskId)
        {
            var lectureLearningTask = await _context.LectureLearningTasks
                .Where(llt => llt.LectureId == lectureId && llt.LearningTaskId == learningTaskId)
                .SingleOrDefaultAsync();

            lectureLearningTask.Completed = !lectureLearningTask.Completed;
        }
    }
}