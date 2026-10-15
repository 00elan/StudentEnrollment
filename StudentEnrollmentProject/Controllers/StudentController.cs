using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollmentSystem.Application.Features.Events.Commands.EnrollStudent;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.DeleteStudent;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.UpdateStudent;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Queries;
using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Application.Models.DTOs;

namespace StudentEnrollmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudent()
        {
            try
            {
                var studentsList = await _mediator.Send(new GetStudentsQuery());
                return Ok(studentsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentID}")] //to add route
        public async Task<ActionResult<StudentWithSubjectsListDto>> GetStudentById(int studentID)
        {
            try
            {
                var student = await _mediator.Send(new GetStudentByIdQuery(studentID));             

                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> EnrollStudentWithSubj(EnrollStudentCommand enroll)
        {
            try
            {
                await _mediator.Send(enroll);
                var enrollStud = await _mediator.Send(new GetStudentsQuery());
                return Ok(enrollStud);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{studentID}")]
        public async Task<ActionResult> UpdateStudent (int studentID, StudentSubject update)
        {
            try
            {
                var updateStud = new UpdateStudentCommand(studentID, update);
                await _mediator.Send(updateStud);
                return Ok(updateStud);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{studentID}")]
        public async Task<ActionResult<int>> DeleteStudent(int studentID)
        {
            try
            {
                var deleteStud = await _mediator.Send(new DeleteStudentCommand(studentID));
                //var result = await _mediator.Send(new GetStudentsQuery());

                return Ok(deleteStud);
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}