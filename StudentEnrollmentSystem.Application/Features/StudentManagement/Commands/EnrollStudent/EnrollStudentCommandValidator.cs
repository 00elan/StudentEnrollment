using FluentValidation;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Features.Events.Commands.EnrollStudent;
using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Application.Models.DTOs;

namespace StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.EnrollStudent
{
    public class EnrollStudentCommandValidator : AbstractValidator<EnrollStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        public EnrollStudentCommandValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

            RuleFor(sub => sub.Enroll.subjectIds)
                .Must(isValidSubjectId)
                .WithMessage("Subject ID must be within the range of 1-9 and 12");


            //Rules for entering Student's Information
            RuleFor(cd => cd.Enroll.Student)
            .MustAsync(async (student, cancellationToken) => await isUniqueRecord(student))
            .WithMessage("Student Record already exists");
            
            RuleFor(student => student.Enroll.Student.FirstName).NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(student => student.Enroll.Student.MiddleName).NotEmpty()
                .WithMessage("Middle Name is required");

            RuleFor(student => student.Enroll.Student.LastName).NotEmpty()
                .WithMessage("Last Name is required");

            RuleFor(student => student.Enroll.Student.BirthDate).NotEmpty()
                .WithMessage("Birthdate is required");

            RuleFor(student => student.Enroll.Student.EmailAddress)
                .NotEmpty().WithMessage("E-mail address is required")
                .EmailAddress().WithMessage("Please enter a valid e-mail address")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("The e-mail address is not in a valid format")
                .MustAsync(async (email, cancellationToken) => await isUniqueEmail(email))
                .WithMessage("Email account is already in use");
            
        }

        private bool isValidSubjectId(IList<int> subjectIds)
        {
            foreach (var subjId in subjectIds)
            {
                if (subjId < 1 || subjId > 12 || (subjId == 10 || subjId == 11))
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> isUniqueRecord(StudentEnrollmentDto student)
        {
            int existingRecord = await _studentRepository.CheckDuplicateRecord(student);

            if (existingRecord == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async Task<bool> isUniqueEmail(string emailAdd)
        {
            int existingEmail = await _studentRepository.CheckDuplicateEmail(new Student { EmailAddress = emailAdd });

            return existingEmail == 0;
        }
    }
}
