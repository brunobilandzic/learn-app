using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess.Queries;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Learning;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories.Learning
{
    public class ExamsRepository : IExamsRepository
    {
        private readonly LearnAppDbContext _context;
        private readonly IMapper _mapper;
        public ExamsRepository(
            LearnAppDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExamDto> AddExam(ExamDto examDto)
        {
            var newExam = _mapper.Map<Exam>(examDto);

            await _context.Exams.AddAsync(newExam);

            await _context.SaveChangesAsync();

            return _mapper.Map<ExamDto>(newExam);
        }

        public async Task<IEnumerable<ExamDto>> GetExams(int courseId)
        {
            return await _context.Exams
                .Where(e => e.CourseId == courseId)
                .ProjectTo<ExamDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}