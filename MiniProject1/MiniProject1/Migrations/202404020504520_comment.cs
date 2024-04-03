namespace MiniProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientProjectUsers", "UserName", c => c.String());
            AlterColumn("dbo.ClientProjectUsers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientProjectUsers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.ClientProjectUsers", "UserName", c => c.String(nullable: false));
        }
    }
}
