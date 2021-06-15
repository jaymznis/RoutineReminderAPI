namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList");
            DropIndex("dbo.ShoppingItem", new[] { "ShoppingListId" });
            AlterColumn("dbo.ShoppingItem", "ShoppingListId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingItem", "ShoppingListId");
            AddForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList", "ShoppingListId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList");
            DropIndex("dbo.ShoppingItem", new[] { "ShoppingListId" });
            AlterColumn("dbo.ShoppingItem", "ShoppingListId", c => c.Int());
            CreateIndex("dbo.ShoppingItem", "ShoppingListId");
            AddForeignKey("dbo.ShoppingItem", "ShoppingListId", "dbo.ShoppingList", "ShoppingListId");
        }
    }
}
