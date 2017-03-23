namespace GroceryApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroceryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroceryItems");
        }
    }
}
