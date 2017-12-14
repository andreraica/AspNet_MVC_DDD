namespace Budget.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemSubValor2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ItemValor", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemValor", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
