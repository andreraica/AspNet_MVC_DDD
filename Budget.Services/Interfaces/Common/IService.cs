using Budget.Domain.Interfaces;
using System.Collections.Generic;

namespace Budget.Domain.Services.Interfaces.Common
{
    public interface IService<T> where T : IBase
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
