using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OnlineLibraryMS2
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetExecutionStrategy("MySql.Data.MySqlClient", () => new DefaultExecutionStrategy());
            SetDefaultConnectionFactory(new MySqlConnectionFactory());
        }
    }
}