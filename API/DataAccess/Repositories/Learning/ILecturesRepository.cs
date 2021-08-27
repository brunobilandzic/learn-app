using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.DataAccess.Repositories.Learning
{
    public interface ILecturesRepository
    {
        Task<LectureDto> AddLecture(LectureDto lectureDto);
        Task<IEnumerable<LectureDto>> GetLectures(int courseId);
    }
}