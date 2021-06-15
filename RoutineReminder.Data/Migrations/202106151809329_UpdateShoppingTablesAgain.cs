namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShoppingTablesAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingList_ShoppingItem", "ShoppingItemId", "dbo.ShoppingItem");
            DropIndex("dbo.ShoppingList_ShoppingItem", new[] { "ShoppingListId" });
            DropIndex("dbo.ShoppingList_ShoppingItem", new[] { "ShoppingItemId" });
            DropTable("dbo.ShoppingList_ShoppingItem");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingList_ShoppingItem",
                c => new
                    {
                        ListItemJoinId = c.Int(nullable: false, identity: true),
                        ShoppingListId = c.Int(nullable: false),
                        ShoppingItemId = c.Int(nullable: false),
                        StoreLocation = c.String(),
                    })
                .PrimaryKey(t => t.ListItemJoinId);
            
            CreateIndex("dbo.ShoppingList_ShoppingItem", "ShoppingItemId");
            CreateIndex("dbo.ShoppingList_ShoppingItem", "ShoppingListId");
            AddForeignKey("dbo.ShoppingList_ShoppingItem", "ShoppingItemId", "dbo.ShoppingItem", "ShoppingItemId", cascadeDelete: true);
        }
    }
}
