using MediatR;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;

namespace StudentEnrollmentSystem.Application.Features.StudentManagement.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        readonly IStudentRepository _studentRepository;
        public GetStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _studentRepository.GetStudents();
            return result;
        }
    }
}
