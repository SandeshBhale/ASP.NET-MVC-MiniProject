namespace MiniProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk_pjid : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ClientProjectUsers", "ProjectId");
            AddForeignKey("dbo.ClientProjectUsers", "ProjectId", "dbo.ClientProjects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientProjectUsers", "ProjectId", "dbo.ClientProjects");
            DropIndex("dbo.ClientProjectUsers", new[] { "ProjectId" });
        }
    }
}
