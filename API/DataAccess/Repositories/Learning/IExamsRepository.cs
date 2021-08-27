using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.DataAccess.Repositories.Learning
{
    public interface IExamsRepository
    {
        Task<ExamDto> AddExam(ExamDto examDto);
        Task<IEnumerable<ExamDto>> GetExams(int courseId);
    }
}