namespace Budget.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemValor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vencimento = c.DateTime(nullable: false),
                        Orcamento_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orcamento", t => t.Orcamento_ID)
                .Index(t => t.Orcamento_ID);
            
            CreateTable(
                "dbo.Orcamento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 150),
                        TipoPessoa = c.Int(nullable: false),
                        TipoPagamento = c.Int(nullable: false),
                        TipoOrcamento = c.Int(nullable: false),
                        Fixa = c.Boolean(nullable: false),
                        TaxaPorcentagem = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemValor", "Orcamento_ID", "dbo.Orcamento");
            DropIndex("dbo.ItemValor", new[] { "Orcamento_ID" });
            DropTable("dbo.Orcamento");
            DropTable("dbo.ItemValor");
        }
    }
}
