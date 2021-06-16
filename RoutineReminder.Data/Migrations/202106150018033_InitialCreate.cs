namespace RoutineReminder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routine_RoutineItem",
                c => new
                    {
                        R_RI_Id = c.Int(nullable: false, identity: true),
                        RoutineId = c.Int(nullable: false),
                        RoutineItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.R_RI_Id)
                .ForeignKey("dbo.Routine", t => t.RoutineId, cascadeDelete: true)
                .ForeignKey("dbo.RoutineItem", t => t.RoutineItemId, cascadeDelete: true)
                .Index(t => t.RoutineId)
                .Index(t => t.RoutineItemId);
            
            CreateTable(
                "dbo.Routine",
                c => new
                    {
                        RoutineId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RoutineName = c.String(nullable: false),
                        RoutineDesc = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineId);
            
            CreateTable(
                "dbo.RoutineReminderJoin",
                c => new
                    {
                        RoutineReminderJoinId = c.Int(nullable: false, identity: true),
                        RoutineId = c.Int(nullable: false),
                        ReminderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoutineReminderJoinId)
                .ForeignKey("dbo.Reminder", t => t.ReminderId, cascadeDelete: true)
                .ForeignKey("dbo.Routine", t => t.RoutineId, cascadeDelete: true)
                .Index(t => t.RoutineId)
                .Index(t => t.ReminderId);
            
            CreateTable(
                "dbo.Reminder",
                c => new
                    {
                        ReminderId = c.Int(nullable: false, identity: true),
                        ReminderName = c.String(nullable: false),
                        ReminderDesc = c.String(),
                        ReminderTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReminderId);
            
            CreateTable(
                "dbo.RoutineItem",
                c => new
                    {
                        RoutineItemId = c.Int(nullable: false, identity: true),
                        RoutineItemName = c.String(nullable: false),
                        RoutineItemDescription = c.String(),
                        RoutineItemTimeframe = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RoutineItemId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ShoppingList",
                c => new
                    {
                        ShoppingListId = c.Int(nullable: false, identity: true),
                        ShoppingListName = c.String(nullable: false),
                        ShoppingListDesc = c.String(),
                    })
                .PrimaryKey(t => t.ShoppingListId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Routine_RoutineItem", "RoutineItemId", "dbo.RoutineItem");
            DropForeignKey("dbo.Routine_RoutineItem", "RoutineId", "dbo.Routine");
            DropForeignKey("dbo.RoutineReminderJoin", "RoutineId", "dbo.Routine");
            DropForeignKey("dbo.RoutineReminderJoin", "ReminderId", "dbo.Reminder");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.RoutineReminderJoin", new[] { "ReminderId" });
            DropIndex("dbo.RoutineReminderJoin", new[] { "RoutineId" });
            DropIndex("dbo.Routine_RoutineItem", new[] { "RoutineItemId" });
            DropIndex("dbo.Routine_RoutineItem", new[] { "RoutineId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.ShoppingList");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.RoutineItem");
            DropTable("dbo.Reminder");
            DropTable("dbo.RoutineReminderJoin");
            DropTable("dbo.Routine");
            DropTable("dbo.Routine_RoutineItem");
        }
    }
}
