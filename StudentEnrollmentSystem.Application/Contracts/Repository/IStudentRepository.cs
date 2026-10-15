using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Application.Models.DTOs;

namespace StudentEnrollmentSystem.Application.Contracts.Repository
{
    public interface IStudentRepository 
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<StudentWithSubjectsListDto> GetStudentById(int studentId);
        public Task<int> EnrollStudentWithSubj (StudentSubject student, IList<int> subjectIds);
        public Task UpdateStudent(int studentID, StudentSubject update);
        public Task<int> DeleteStudent(int studentID);
        public Task<int> CheckDuplicateRecord(StudentEnrollmentDto student);
        public Task<int> CheckDuplicateEmail(Student email);
    }
}
