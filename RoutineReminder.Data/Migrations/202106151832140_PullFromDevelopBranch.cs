namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PullFromDevelopBranch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routine_ShoppingList",
                c => new
                    {
                        R_SLId = c.Int(nullable: false, identity: true),
                        RoutineId = c.Int(nullable: false),
                        ShoppingListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.R_SLId)
                .ForeignKey("dbo.Routine", t => t.RoutineId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingList", t => t.ShoppingListId, cascadeDelete: true)
                .Index(t => t.RoutineId)
                .Index(t => t.ShoppingListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routine_ShoppingList", "ShoppingListId", "dbo.ShoppingList");
            DropForeignKey("dbo.Routine_ShoppingList", "RoutineId", "dbo.Routine");
            DropIndex("dbo.Routine_ShoppingList", new[] { "ShoppingListId" });
            DropIndex("dbo.Routine_ShoppingList", new[] { "RoutineId" });
            DropTable("dbo.Routine_ShoppingList");
        }
    }
}
