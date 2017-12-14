using Budget.Domain.Interfaces;

namespace Budget.Domain.Entities
{
    public class ItemSubValor: IItemSubValor
    {
        public int ID { get; set; }
        public decimal Valor { get; set; }

        public virtual ItemValor ItemValor { get; set; }
    }
}

