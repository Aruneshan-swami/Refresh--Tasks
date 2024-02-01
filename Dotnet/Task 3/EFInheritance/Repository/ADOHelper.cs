using System.Data;
using System.Data.SqlClient;

namespace EFInheritance.Repository
{
    public class ADOHelper
    {
        private readonly string _connectionString;

        public ADOHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}