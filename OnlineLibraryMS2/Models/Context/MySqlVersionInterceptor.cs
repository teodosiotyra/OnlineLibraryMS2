using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace OnlineLibraryMS2
{
    public class MySqlVersionInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            CheckAndPatchCommand(command);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) { }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            CheckAndPatchCommand(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) { }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            CheckAndPatchCommand(command);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) { }

        private void CheckAndPatchCommand(DbCommand command)
        {
            if (command.CommandText != null && (command.CommandText.Contains("@@version") || command.CommandText.Contains("VERSION()")))
            {
                command.CommandText = "SELECT '5.6.10' AS `version`";
            }
        }
    }
}