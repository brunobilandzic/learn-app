using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess.UnitOfWork;
using API.DTOs;
using API.Services.ClaimsExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ExamsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ExamDto>>> GetAllExams()
        {
            return Ok(
                await _unitOfWork.ExamsRepository.GetAllFutureExams(User.GetUserId())
            );
        }
    }
}