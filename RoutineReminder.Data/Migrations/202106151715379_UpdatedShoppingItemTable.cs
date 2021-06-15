namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedShoppingItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingItem", "ShoppingListId", c => c.Int());
            AddColumn("dbo.ShoppingItem", "StoreLocation", c => c.String());
            CreateIndex("dbo.ShoppingItem", "ShoppingListId");
            AddForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList", "ShoppingListId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList");
            DropIndex("dbo.ShoppingItem", new[] { "ShoppingListId" });
            DropColumn("dbo.ShoppingItem", "StoreLocation");
            DropColumn("dbo.ShoppingItem", "ShoppingListId");
        }
    }
}
