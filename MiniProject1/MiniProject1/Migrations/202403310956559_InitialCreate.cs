namespace MiniProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Long(nullable: false, identity: true),
                        AdminName = c.String(nullable: false),
                        EmailId = c.String(),
                        MobileNo = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.ClientProjectUsers",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ProjectId = c.Long(nullable: false),
                        Address = c.String(),
                        EmailId = c.String(),
                        MobileNo = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Long(nullable: false, identity: true),
                        ClientName = c.String(nullable: false),
                        Address = c.String(),
                        EmailId = c.String(),
                        MobileNo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.ClientProjects",
                c => new
                    {
                        ProjectId = c.Long(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        LocationAddress = c.String(),
                        LocationCity = c.String(nullable: false),
                        ClientId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientProjects", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientProjects", new[] { "ClientId" });
            DropTable("dbo.ClientProjects");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientProjectUsers");
            DropTable("dbo.Admins");
        }
    }
}
