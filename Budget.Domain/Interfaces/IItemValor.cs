using Budget.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Budget.Domain.Interfaces
{
    public interface IItemValor : IBase
    {
        DateTime Vencimento { get; set; }
        ICollection<ItemSubValor> SubValores { get; set; }

        decimal TotalSubValor(ItemValor itemValor);
    }
}
