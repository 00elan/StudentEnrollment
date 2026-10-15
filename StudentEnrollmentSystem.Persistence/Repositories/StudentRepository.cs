using Dapper;
using Microsoft.Extensions.Options;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Application.Models.DTOs;
using StudentEnrollmentSystem.Infrastructure.Configuration;
using StudentEnrollmentSystem.Infrastructure.Interfaces;
using System.Data;

namespace StudentEnrollmentSystem.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _connection;

        public StudentRepository(IOptions<ConnectionStrings> options, IDbConfiguration dbConfiguration)
        {
            _connection = dbConfiguration.CreateDatabase(options.Value.DefaultConnection);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var SQL = "SELECT * FROM Student";
            var result = await _connection.QueryAsync<Student>(SQL);

            return result;
        }
        public async Task<StudentWithSubjectsListDto> GetStudentById(int studentId)
        {
            var studentQuery = "SELECT studentID, firstName, middleName, lastName, birthDate, emailAddress FROM Student WHERE studentID = @studentID";
            var subjQuery = @"SELECT sub.*
                            FROM StudentSubject AS ss
                            INNER JOIN Student AS s ON s.studentID = ss.studentID
                            INNER JOIN Subject AS sub ON sub.subjectID = ss.subjectID
                            WHERE s.studentID = @studentID";

            var student = await _connection.QueryFirstAsync<Student>(studentQuery, new { studentId });
            var subject = await _connection.QueryAsync<Subject>(subjQuery, new { studentId });

            return new StudentWithSubjectsListDto
            {
                Student = student,
                Subjects = subject,
            };
        }
        public async Task <int> EnrollStudentWithSubj(StudentSubject enroll, IList<int> subjectIds)
        {
            var newStudId = _connection.QuerySingle<int>(@"INSERT INTO Student (firstName, middleName, lastName, birthDate, emailAddress, dateCreated, dateUpdated)
                               VALUES (@FirstName, @MiddleName, @LastName, @BirthDate, @EmailAddress, @DateCreated, @DateUpdated);
                               SELECT CAST (SCOPE_IDENTITY() AS int)",
                               new
                               {
                                   enroll.Student.FirstName,
                                   enroll.Student.MiddleName,
                                   enroll.Student.LastName,
                                   enroll.Student.BirthDate,
                                   enroll.Student.EmailAddress,
                                   DateCreated = DateTime.Now,
                                   DateUpdated = DateTime.Now
                               });
            foreach(var subjId in subjectIds)
            {
                await _connection.ExecuteAsync("INSERT INTO StudentSubject (studentID, subjectID) VALUES (@studentID, @subjectID)", new { studentID = newStudId, subjectID = subjId });
            }
            return newStudId;
        }
        public async Task UpdateStudent(int studentID, StudentSubject update)
        {
            await _connection.ExecuteAsync(@"UPDATE Student SET firstName = @FirstName, middleName = @MiddleName, lastName = @LastName, birthDate = @BirthDate, emailAddress = @EmailAddress,
                              dateUpdated = @DateUpdated WHERE studentID = @StudentID",
                              new
                              {
                                  update.Student.FirstName,
                                  update.Student.MiddleName,
                                  update.Student.LastName,
                                  update.Student.BirthDate,
                                  update.Student.EmailAddress,
                                  dateUpdated = DateTime.Now,
                                  StudentID = studentID
                              });
            await _connection.ExecuteAsync("DELETE FROM StudentSubject WHERE studentID = @StudentID ", new { StudentID = studentID});
            foreach (var subjID in update.subjectIds)
            {
                await _connection.ExecuteAsync("INSERT INTO StudentSubject (studentID, subjectID) VALUES (@studentID, @subjectID)", new { studentID = studentID, subjectID = subjID });             
            }
        }
        public async Task<int> DeleteStudent(int studentID)
        {
            var sql = await _connection.ExecuteAsync("DELETE FROM studentsubject WHERE studentID = @studentID; DELETE FROM Student where studentID = @studentID", new { StudentID = studentID});
            return sql;
        }

        public async Task<int> CheckDuplicateRecord(StudentEnrollmentDto student)
        {
            var query = @"SELECT [firstName],[middleName],[lastName],[birthDate],[emailAddress]
                        FROM [StudentEnrollment].[dbo].[Student]
                        WHERE firstName = @FirstName
                        AND middleName = @MiddleName
                        AND lastName = @LastName
                        AND birthDate = @BirthDate
                        AND emailAddress = @EmailAddress";

            var formattedBday = student.BirthDate.ToString("yyyy-MM-dd");

            var duplicateRecord = await _connection.QueryAsync<Student>(query,
                new
                {
                    student.FirstName,
                    student.MiddleName,
                    student.LastName,
                    BirthDate = formattedBday,
                    student.EmailAddress
                });

            return duplicateRecord.Count();
        }

        public async Task<int> CheckDuplicateEmail (Student email)
        {
            var existingEmail = @"SELECT [emailAddress]
                        FROM StudentEnrollment.dbo.Student
                        WHERE emailAddress = @EmailAddress";

            var duplicateEmail = await _connection.QueryAsync<Student>(existingEmail,
                new
                {
                    email.EmailAddress
                });
            return duplicateEmail.Count();
        }
    }
}
