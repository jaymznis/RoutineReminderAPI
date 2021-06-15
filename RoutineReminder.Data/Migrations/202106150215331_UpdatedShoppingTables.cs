namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedShoppingTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList");
            DropIndex("dbo.ShoppingItem", new[] { "ShoppingListId" });
            CreateTable(
                "dbo.ShoppingList_ShoppingItem",
                c => new
                    {
                        ListItemJoinId = c.Int(nullable: false, identity: true),
                        ShoppingListId = c.Int(nullable: false),
                        ShoppingItemId = c.Int(nullable: false),
                        StoreLocation = c.String(),
                    })
                .PrimaryKey(t => t.ListItemJoinId)
                .ForeignKey("dbo.ShoppingItem", t => t.ShoppingItemId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingList", t => t.ShoppingListId, cascadeDelete: true)
                .Index(t => t.ShoppingListId)
                .Index(t => t.ShoppingItemId);
            
            DropColumn("dbo.ShoppingItem", "ShoppingListId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingItem", "ShoppingListId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ShoppingList_ShoppingItem", "ShoppingListId", "dbo.ShoppingList");
            DropForeignKey("dbo.ShoppingList_ShoppingItem", "ShoppingItemId", "dbo.ShoppingItem");
            DropIndex("dbo.ShoppingList_ShoppingItem", new[] { "ShoppingItemId" });
            DropIndex("dbo.ShoppingList_ShoppingItem", new[] { "ShoppingListId" });
            DropTable("dbo.ShoppingList_ShoppingItem");
            CreateIndex("dbo.ShoppingItem", "ShoppingListId");
            AddForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList", "ShoppingListId", cascadeDelete: true);
        }
    }
}
