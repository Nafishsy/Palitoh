namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateConvoTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conversations", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conversations", "Text");
        }
    }
}
