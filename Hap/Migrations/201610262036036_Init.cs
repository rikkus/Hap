namespace Hap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                        LoginEmail = c.String(),
                        AddedUtc = c.DateTime(nullable: false),
                        UpdatedUtc = c.DateTime(),
                        DeletedUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.String(),
                        Type = c.Int(nullable: false),
                        CustomType = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                        AddedUtc = c.DateTime(nullable: false),
                        UpdatedUtc = c.DateTime(),
                        DeletedUtc = c.DateTime(),
                        Contact_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ID)
                .Index(t => t.Contact_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Spaces",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                        PricePerHourPoundsSterling = c.Decimal(precision: 18, scale: 2),
                        MaxCapacityPersons = c.Int(),
                        AreaMetresSquared = c.Int(),
                        WebLink = c.String(),
                        AddedUtc = c.DateTime(nullable: false),
                        UpdatedUtc = c.DateTime(),
                        DeletedUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SpaceContacts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                        AddedUtc = c.DateTime(nullable: false),
                        UpdatedUtc = c.DateTime(),
                        DeletedUtc = c.DateTime(),
                        Contact_ID = c.Guid(),
                        Space_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.Contact_ID)
                .ForeignKey("dbo.Spaces", t => t.Space_ID)
                .Index(t => t.Contact_ID)
                .Index(t => t.Space_ID);
            
            CreateTable(
                "dbo.CalendarEntries",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        StartUtc = c.DateTime(nullable: false),
                        EndUtc = c.DateTime(nullable: false),
                        AddedUtc = c.DateTime(nullable: false),
                        UpdatedUtc = c.DateTime(),
                        DeletedUtc = c.DateTime(),
                        Hirer_ID = c.Guid(),
                        Space_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.Hirer_ID)
                .ForeignKey("dbo.Spaces", t => t.Space_ID)
                .Index(t => t.Hirer_ID)
                .Index(t => t.Space_ID);
            
            CreateTable(
                "dbo.Photographs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Description = c.String(),
                        Jpeg = c.Binary(),
                        AddedUtc = c.DateTime(nullable: false),
                        UpdatedUtc = c.DateTime(),
                        DeletedUtc = c.DateTime(),
                        Space_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Spaces", t => t.Space_ID)
                .Index(t => t.Space_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Photographs", "Space_ID", "dbo.Spaces");
            DropForeignKey("dbo.CalendarEntries", "Space_ID", "dbo.Spaces");
            DropForeignKey("dbo.CalendarEntries", "Hirer_ID", "dbo.Contacts");
            DropForeignKey("dbo.SpaceContacts", "Space_ID", "dbo.Spaces");
            DropForeignKey("dbo.SpaceContacts", "Contact_ID", "dbo.Contacts");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PhoneNumbers", "Contact_ID", "dbo.Contacts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Photographs", new[] { "Space_ID" });
            DropIndex("dbo.CalendarEntries", new[] { "Space_ID" });
            DropIndex("dbo.CalendarEntries", new[] { "Hirer_ID" });
            DropIndex("dbo.SpaceContacts", new[] { "Space_ID" });
            DropIndex("dbo.SpaceContacts", new[] { "Contact_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PhoneNumbers", new[] { "Contact_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Photographs");
            DropTable("dbo.CalendarEntries");
            DropTable("dbo.SpaceContacts");
            DropTable("dbo.Spaces");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Contacts");
        }
    }
}
