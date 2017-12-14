using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Context;
using Budget.Infrastructure.Data.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Budget.Infrastructure.Data.Repositories
{
    public class ItemValorRepository : IItemValorRepository
    {
        private readonly BudgetContext _contexto;
        protected readonly IDbSet<ItemValor> _dbset;

        public ItemValorRepository(BudgetContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<ItemValor> GetAll()
        {
            return _contexto.ItemValor;
        }

        public ItemValor FindById(int id)
        {
            return _contexto.ItemValor.Include(x => x.Orcamento).FirstOrDefault(x => x.ID == id);
        }

        public ItemValor Add(ItemValor entity)
        {

            _contexto.Entry(entity.Orcamento).State = EntityState.Unchanged;

            if (entity.SubValores != null)
            {
                foreach (var item in entity.SubValores)
                    _contexto.Entry(item).State = EntityState.Unchanged;
            }

            return _contexto.ItemValor.Add(entity);
        }

        public ItemValor Delete(ItemValor entity)
        {
            return _contexto.ItemValor.Remove(entity);
        }

        public void Edit(ItemValor entity)
        {
            _contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        public IEnumerable<ItemValor> GetByOrcamento(int orcamentoId)
        {
            return _contexto.ItemValor.Include(x => x.Orcamento).Where(x => x.Orcamento.ID == orcamentoId);
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
