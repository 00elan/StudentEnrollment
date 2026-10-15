using MediatR;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;

namespace StudentEnrollmentSystem.Application.Features.StudentManagement.Queries
{
    public class GetSubjectsQuery : IRequest<IEnumerable<Subject>>
    {
    }
    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, IEnumerable<Subject>>
    {
        readonly ISubjectRepository _subjectRepository;
        public GetSubjectsQueryHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<Subject>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _subjectRepository.GetAllSubject();
            return result;
        }
    }
}
