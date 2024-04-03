namespace MiniProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inherit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String());
            DropColumn("dbo.Admins", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
        }
    }
}
