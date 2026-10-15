using StudentEnrollmentSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Application.Contracts.Repository
{
    public interface ISubjectRepository
    {
        public Task<IEnumerable<Subject>> GetAllSubject();
    }
}
