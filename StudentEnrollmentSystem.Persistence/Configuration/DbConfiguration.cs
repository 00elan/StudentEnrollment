using StudentEnrollmentSystem.Infrastructure.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace StudentEnrollmentSystem.Infrastructure.Configuration
{
    public class DbConfiguration : IDbConfiguration
    {
        public IDbConnection CreateDatabase(string connectionString) //for creating connection to DB
        {
            return new SqlConnection(connectionString); //CS value is DefaultConnection: initialized in appsettings.json
        }
    }
}
