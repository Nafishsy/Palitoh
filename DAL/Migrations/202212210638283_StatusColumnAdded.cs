namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Status");
        }
    }
}
