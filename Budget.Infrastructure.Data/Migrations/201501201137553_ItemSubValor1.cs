namespace Budget.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemSubValor1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemSubValor", "ItemValor_ID", c => c.Int());
            CreateIndex("dbo.ItemSubValor", "ItemValor_ID");
            AddForeignKey("dbo.ItemSubValor", "ItemValor_ID", "dbo.ItemValor", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemSubValor", "ItemValor_ID", "dbo.ItemValor");
            DropIndex("dbo.ItemSubValor", new[] { "ItemValor_ID" });
            DropColumn("dbo.ItemSubValor", "ItemValor_ID");
        }
    }
}
