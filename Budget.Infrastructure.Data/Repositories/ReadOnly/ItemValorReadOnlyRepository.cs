using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface.ReadOnly;
using Budget.Infrastructure.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Budget.Infrastructure.Data.Repositories.ReadOnly
{
    public class ItemValorReadOnlyRepository : BaseReadOnlyRepository, IItemValorReadOnlyRepository
    {
        
        public IEnumerable<ItemValor> GetAll()
        {
            using (var cn = Connection)
            {
                var sql = @"Select * from ItemValor";
                cn.Open();
                return cn.Query<ItemValor>(sql);
            }
        }

        public ItemValor FindById(int Id)
        {
            using (var cn = Connection)
            {
                var sql = @"Select top 1 * from ItemValor where id = " + Id;
                cn.Open();
                return cn.Query<ItemValor>(sql).FirstOrDefault();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
