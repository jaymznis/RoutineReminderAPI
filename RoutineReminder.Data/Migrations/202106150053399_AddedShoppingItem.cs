namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShoppingItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingItem",
                c => new
                    {
                        ShoppingItemId = c.Int(nullable: false, identity: true),
                        ShoppingListId = c.Int(nullable: false),
                        ShoppingItemName = c.String(nullable: false),
                        ShoppingItemDesc = c.String(),
                    })
                .PrimaryKey(t => t.ShoppingItemId)
                .ForeignKey("dbo.ShoppingList", t => t.ShoppingListId, cascadeDelete: true)
                .Index(t => t.ShoppingListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList");
            DropIndex("dbo.ShoppingItem", new[] { "ShoppingListId" });
            DropTable("dbo.ShoppingItem");
        }
    }
}
