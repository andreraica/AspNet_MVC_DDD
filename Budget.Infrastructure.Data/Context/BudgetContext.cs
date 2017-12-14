using System.Data.Entity;
using Budget.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using Budget.Infrastructure.Data.EntityConfig;
using System;

namespace Budget.Infrastructure.Data.Context
{
    public class BudgetContext : DbContext
    {
        public BudgetContext()
            : base("BudgetConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<ItemValor> ItemValor { get; set; }
        public DbSet<ItemSubValor> ItemSubValor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Configuração Global para Evitar o NVARCHAR
            modelBuilder.Properties<String>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new OrcamentoConfiguracao());
            modelBuilder.Configurations.Add(new ItemValorConfiguracao());
            modelBuilder.Configurations.Add(new ItemSubValorConfiguracao());
        }
        
    }
}
