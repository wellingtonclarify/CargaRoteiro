using System.Data;

namespace CargoRoteiro.DbContext
{
    public static class DbConnectionFactory
    {
        public static IDbConnection GetInstance()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=LOGA_SGO_V3;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True";
            var connection = DbConnection.GetInstance(connectionString);
            connection.Open();
            return connection;
        }
    }
}
