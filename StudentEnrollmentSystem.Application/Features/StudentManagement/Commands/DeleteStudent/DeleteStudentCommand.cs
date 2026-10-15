using MediatR;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;

namespace StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest <int>
    {
        public int StudentId { get; set; }

        public DeleteStudentCommand(int studentID)
        {
            StudentId = studentID;
        }
    }
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        readonly IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.DeleteStudent(request.StudentId);
        }
    }
}
