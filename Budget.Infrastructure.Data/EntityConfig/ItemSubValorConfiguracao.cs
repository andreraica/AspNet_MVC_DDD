using Budget.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Budget.Infrastructure.Data.EntityConfig
{
    public class ItemSubValorConfiguracao : EntityTypeConfiguration<ItemSubValor>
    {
        public ItemSubValorConfiguracao()
        {
            HasKey(v => v.ID);

            Property(v => v.Valor)
                .IsRequired();
        }
    }
}
