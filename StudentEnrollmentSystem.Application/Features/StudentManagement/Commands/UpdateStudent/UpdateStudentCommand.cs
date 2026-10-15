using MediatR;
using StudentEnrollmentSystem.Application.Attributes;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.UpdateStudent
{
    public class UpdateStudentCommand: IRequest
    {
        public StudentSubject Update { get; set; }
        [SwaggerIgnore]
        public int StudentId { get; set; }
        public UpdateStudentCommand(int studentID, StudentSubject update)
        {
            Update = update;
            StudentId = studentID;
        }
    }
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        readonly IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository= studentRepository;
        }
        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentRepository.UpdateStudent(request.StudentId, request.Update);
        }
    }
}
