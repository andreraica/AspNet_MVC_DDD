using Budget.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Budget.Infrastructure.Data.EntityConfig
{
    public class OrcamentoConfiguracao : EntityTypeConfiguration<Orcamento>
    {
        public OrcamentoConfiguracao()
        {
            HasKey(x => x.ID);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.TipoOrcamento)
                .IsRequired();

            Property(x => x.TipoPagamento)
                .IsRequired();

            Property(x => x.TipoPessoa)
                .IsRequired();

            Property(v => v.Fixa)
                .IsRequired();
        }
    }
}
