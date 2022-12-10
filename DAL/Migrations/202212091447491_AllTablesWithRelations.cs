namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTablesWithRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.String(),
                        ProfilePic = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        AccessToken = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        About = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Balance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MapCustomerFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        OrderId = c.Int(nullable: false),
                        RequestItemTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FoodId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        WorkingHour = c.String(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.MapCustomerPets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        AdoptionRequestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.PetId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        ShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.MapCustomerVets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        VetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Vets", t => t.VetId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.VetId);
            
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        AppointmentFees = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapCustomerVets", "VetId", "dbo.Vets");
            DropForeignKey("dbo.MapCustomerVets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MapCustomerFoods", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.MapCustomerFoods", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.MapCustomerPets", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Foods", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.MapCustomerPets", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MapCustomerPets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MapCustomerFoods", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Tokens", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Reports", "AccountId", "dbo.Accounts");
            DropIndex("dbo.MapCustomerVets", new[] { "VetId" });
            DropIndex("dbo.MapCustomerVets", new[] { "CustomerId" });
            DropIndex("dbo.Foods", new[] { "ShopId" });
            DropIndex("dbo.Pets", new[] { "ShopId" });
            DropIndex("dbo.MapCustomerPets", new[] { "EmployeeId" });
            DropIndex("dbo.MapCustomerPets", new[] { "PetId" });
            DropIndex("dbo.MapCustomerPets", new[] { "CustomerId" });
            DropIndex("dbo.Employees", new[] { "ShopId" });
            DropIndex("dbo.MapCustomerFoods", new[] { "EmployeeId" });
            DropIndex("dbo.MapCustomerFoods", new[] { "FoodId" });
            DropIndex("dbo.MapCustomerFoods", new[] { "CustomerId" });
            DropIndex("dbo.Tokens", new[] { "AccountId" });
            DropIndex("dbo.Reports", new[] { "AccountId" });
            DropTable("dbo.Vets");
            DropTable("dbo.MapCustomerVets");
            DropTable("dbo.Foods");
            DropTable("dbo.Shops");
            DropTable("dbo.Pets");
            DropTable("dbo.MapCustomerPets");
            DropTable("dbo.Employees");
            DropTable("dbo.MapCustomerFoods");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
            DropTable("dbo.Tokens");
            DropTable("dbo.Reports");
            DropTable("dbo.Accounts");
        }
    }
}
