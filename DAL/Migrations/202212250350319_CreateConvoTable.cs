namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateConvoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        VetId = c.Int(nullable: false),
                        ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MapCustomerVets", t => t.ChatId, cascadeDelete: true)
                .Index(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conversations", "ChatId", "dbo.MapCustomerVets");
            DropIndex("dbo.Conversations", new[] { "ChatId" });
            DropTable("dbo.Conversations");
        }
    }
}
