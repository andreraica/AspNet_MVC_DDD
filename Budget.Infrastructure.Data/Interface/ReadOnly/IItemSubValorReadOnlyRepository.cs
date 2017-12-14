using Budget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Infrastructure.Data.Interface.ReadOnly
{
    public interface IItemSubValorReadOnlyRepository
    {
        IEnumerable<ItemSubValor> GetAll();
        ItemSubValor FindById(int Id);
    }
}
