using Dapper;
using Microsoft.Extensions.Options;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Models;
using StudentEnrollmentSystem.Infrastructure.Configuration;
using StudentEnrollmentSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentSystem.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IDbConnection _connection;
        public SubjectRepository(IOptions<ConnectionStrings> options, IDbConfiguration dbConfiguration)
        {
            _connection = dbConfiguration.CreateDatabase(options.Value.DefaultConnection);               
        }

        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            var query = "SELECT * FROM Subject";
            var result = await _connection.QueryAsync<Subject>(query);
            return result;
        }
    }
}
