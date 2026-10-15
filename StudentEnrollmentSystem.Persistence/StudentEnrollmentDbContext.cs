using Microsoft.EntityFrameworkCore;
using StudentEnrollmentSystem;
using StudentEnrollmentSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Infrastructure
{
    public class StudentEnrollmentDbContext : DbContext
    {
        public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options) : base(options) { }

        //specifies which tables are available in DB
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
    }
}
