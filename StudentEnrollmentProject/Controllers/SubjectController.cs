using Dapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Queries;
using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Infrastructure.Repositories;

namespace StudentEnrollmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            try
            {
                var result = await _mediator.Send(new GetSubjectsQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
