using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Context;
using Budget.Infrastructure.Data.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Budget.Infrastructure.Data.Repositories
{
    public class ItemSubValorRepository : IItemSubValorRepository
    {
        private readonly BudgetContext _contexto;
        protected readonly IDbSet<ItemSubValor> _dbset;

        public ItemSubValorRepository(BudgetContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<ItemSubValor> GetAll()
        {
            return _contexto.ItemSubValor;
        }

        public ItemSubValor FindById(int id)
        {
            return _contexto.ItemSubValor.Include(x => x.ItemValor).FirstOrDefault(x => x.ID == id);
        }

        public ItemSubValor Add(ItemSubValor entity)
        {
            _contexto.Entry(entity.ItemValor).State = EntityState.Unchanged;
            
            return _contexto.ItemSubValor.Add(entity);
        }

        public ItemSubValor Delete(ItemSubValor entity)
        {
            return _contexto.ItemSubValor.Remove(entity);
        }

        public void Edit(ItemSubValor entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        public IEnumerable<ItemSubValor> GetByValor(int valorId)
        {
            return _contexto.ItemSubValor.Include(x => x.ItemValor.Orcamento).Where(x => x.ItemValor.ID == valorId);
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
