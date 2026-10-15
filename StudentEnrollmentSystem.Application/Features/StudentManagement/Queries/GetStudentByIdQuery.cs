using MediatR;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Features.StudentManagement.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentWithSubjectsListDto>
    {
        public int Studentid { get; set; }
        public GetStudentByIdQuery(int studentID)
        {
            Studentid = studentID;
        }
    }
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentWithSubjectsListDto>
    {
        readonly IStudentRepository _studentRepository;
        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentWithSubjectsListDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _studentRepository.GetStudentById(request.Studentid);
            return result;
        }
    }
}
