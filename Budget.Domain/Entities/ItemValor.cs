using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Domain.Entities
{
    public class ItemValor: IItemValor
    {
        public int ID { get; set; }
        public DateTime Vencimento { get; set; }

        public virtual ICollection<ItemSubValor> SubValores { get; set; }

        public virtual Orcamento Orcamento { get; set; }

        public decimal TotalSubValor(ItemValor itemValor)
        {
            return itemValor.SubValores.Sum(x => x.Valor);
        }
    }
}

