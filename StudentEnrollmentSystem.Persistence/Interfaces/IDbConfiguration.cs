using System.Data;

namespace StudentEnrollmentSystem.Infrastructure.Interfaces
{
    public interface IDbConfiguration
    {
        IDbConnection CreateDatabase(string connectionString);
    }
}
