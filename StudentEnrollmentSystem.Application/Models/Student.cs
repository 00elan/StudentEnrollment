using Microsoft.Identity.Client;
using StudentEnrollmentSystem.Application.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentEnrollmentSystem.Application.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        [JsonIgnore]
        public DateTime? DateCreated { get; set; }
        [JsonIgnore]
        public DateTime? DateUpdated { get; set; }

    }
}
