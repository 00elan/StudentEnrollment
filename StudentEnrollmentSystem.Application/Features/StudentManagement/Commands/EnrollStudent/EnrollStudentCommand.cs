using FluentValidation;
using FluentValidation.Results;
using MediatR;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.EnrollStudent;
using StudentEnrollmentSystem.Application.Models;

namespace StudentEnrollmentSystem.Application.Features.Events.Commands.EnrollStudent
{
    public class EnrollStudentCommand : IRequest<int>
    {
        public StudentSubject Enroll { get; set; }
    }
    public class EnrollStudentCommandHandler : IRequestHandler<EnrollStudentCommand, int>
    {
        readonly IStudentRepository _studentRepository;

        public EnrollStudentCommandHandler(IStudentRepository studentRepository) //IValidator<EnrollStudentCommand> validator
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(EnrollStudentCommand request, CancellationToken cancellationToken)
        {
 
            var validation = new EnrollStudentCommandValidator(_studentRepository);
            var validationResult = await validation.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await _studentRepository.EnrollStudentWithSubj(request.Enroll, request.Enroll.subjectIds);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }

        }
    }
}
