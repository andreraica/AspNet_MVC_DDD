using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface.ReadOnly;
using Budget.Infrastructure.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Budget.Infrastructure.Data.Repositories.ReadOnly
{
    public class OrcamentoReadOnlyRepository : BaseReadOnlyRepository, IOrcamentoReadOnlyRepository
    {
        
        public IEnumerable<Orcamento> GetAll()
        {
            using (var cn = Connection)
            {
                var sql = @"Select * from Orcamento";
                cn.Open();
                return cn.Query<Orcamento>(sql);
            }
        }

        public Orcamento FindById(int Id)
        {
            using (var cn = Connection)
            {
                var sql = @"Select top 1 * from Orcamento where id = " + Id;
                cn.Open();
                return cn.Query<Orcamento>(sql).FirstOrDefault();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
