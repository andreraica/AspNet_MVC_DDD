namespace Budget.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemSubValor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemSubValor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemSubValor");
        }
    }
}
