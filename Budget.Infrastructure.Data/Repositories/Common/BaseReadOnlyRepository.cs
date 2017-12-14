using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Budget.Infrastructure.Data.Repositories.Common
{
    public class BaseReadOnlyRepository : IDisposable
    {
        public IDbConnection Connection 
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["BudgetConnection"].ConnectionString);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (this.Connection == null)
                return;

            this.Connection.Dispose();
        }
    }
}
