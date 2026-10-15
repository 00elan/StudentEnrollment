using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Models.DTOs
{
    public class StudentWithSubjectsListDto
    {
        public Student Student { get; set; }
        public IEnumerable<Subject> Subjects { get; set;}
    }
}
