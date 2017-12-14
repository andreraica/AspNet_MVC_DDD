using Budget.Domain.Interfaces;
using Budget.Infrastructure.Data.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Budget.Infrastructure.Data.Interface.Common
{
    public interface IRepository<T> where T : IBase
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
