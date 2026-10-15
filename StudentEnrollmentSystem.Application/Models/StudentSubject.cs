using StudentEnrollmentSystem.Application.Attributes;
using StudentEnrollmentSystem.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Models
{
    public class StudentSubject
    {
        [JsonIgnore]
        public int StudentSubjectID { get; set; }
        public StudentEnrollmentDto Student { get; set; }
        public IList<int> subjectIds { get; set; }
    }
}
