using Budget.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Budget.Infrastructure.Data.EntityConfig
{
    public class ItemValorConfiguracao : EntityTypeConfiguration<ItemValor>
    {
        public ItemValorConfiguracao()
        {
            HasKey(v => v.ID);

            Property(v => v.Vencimento)
                .IsRequired();

            //this.HasOptional(x => x.SubValores)
            //    .WithMany()
            //    .HasForeignKey(x => x.ID);
        }
    }
}
