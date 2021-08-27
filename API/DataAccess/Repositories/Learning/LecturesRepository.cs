using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataLayer.EfCode.DbSetup;
using API.DataLayer.Entities.Learning;
using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Repositories.Learning
{
    public class LecturesRepository : ILecturesRepository
    {
        private readonly LearnAppDbContext _context;
        private readonly IMapper _mapper;
        public LecturesRepository(
            LearnAppDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LectureDto> AddLecture(LectureDto lectureDto)
        {
            var newLecture = _mapper.Map<Lecture>(lectureDto);

            await _context.Lectures.AddAsync(newLecture);

            await _context.SaveChangesAsync();

            return _mapper.Map<LectureDto>(newLecture);
        }

        public async Task<IEnumerable<LectureDto>> GetLectures(int courseId)
        {
            return await _context.Lectures
                .Where(e => e.CourseId == courseId)
                .ProjectTo<LectureDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}