using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Context;
using Budget.Infrastructure.Data.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Budget.Infrastructure.Data.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly BudgetContext _contexto;
        protected readonly IDbSet<Orcamento> _dbset;

        public OrcamentoRepository(BudgetContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Orcamento> GetAll()
        {
            return _contexto.Orcamentos;
        }

        public Orcamento FindById(int id)
        {
            return _contexto.Orcamentos.FirstOrDefault(x => x.ID == id);
        }

        public Orcamento Add(Orcamento entity)
        {
            return _contexto.Orcamentos.Add(entity);
        }

        public Orcamento Delete(Orcamento entity)
        {
            return _contexto.Orcamentos.Remove(entity);
        }

        public void Edit(Orcamento entity)
        {
            _contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _contexto.SaveChanges();
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

            if (this._contexto == null)
                return;

            this._contexto.Dispose();
        }
    }
}
