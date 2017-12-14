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
    public class ItemSubValorReadOnlyRepository : BaseReadOnlyRepository, IItemSubValorReadOnlyRepository
    {

        public IEnumerable<ItemSubValor> GetAll()
        {
            using (var cn = Connection)
            {
                var sql = @"Select * from ItemSubValor";
                cn.Open();
                return cn.Query<ItemSubValor>(sql);
            }
        }

        public ItemSubValor FindById(int Id)
        {
            using (var cn = Connection)
            {
                var sql = @"Select top 1 * from ItemSubValor where id = " + Id;
                cn.Open();
                return cn.Query<ItemSubValor>(sql).FirstOrDefault();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
