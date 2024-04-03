namespace MiniProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClientProjectUsers", "RegistrationDate");
            DropColumn("dbo.ClientProjects", "CreationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientProjects", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientProjectUsers", "RegistrationDate", c => c.DateTime(nullable: false));
        }
    }
}
