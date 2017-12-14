using Budget.Domain.Interfaces;
using System.Collections.Generic;

namespace Budget.Application.Interfaces.Common
{
    public interface IGerenciador<T> where T : IBase
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
