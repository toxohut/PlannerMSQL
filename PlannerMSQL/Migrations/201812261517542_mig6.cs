namespace PlannerMSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetingModels", "MeetingName", c => c.String(nullable: false));
            AddColumn("dbo.MeetingModels", "MeetingDescription", c => c.String());
            AddColumn("dbo.MeetingModels", "Owner_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "MeetingModel_MeetingId", c => c.Int());
            CreateIndex("dbo.MeetingModels", "Owner_Id");
            CreateIndex("dbo.AspNetUsers", "MeetingModel_MeetingId");
            AddForeignKey("dbo.AspNetUsers", "MeetingModel_MeetingId", "dbo.MeetingModels", "MeetingId");
            AddForeignKey("dbo.MeetingModels", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "MeetingModel_MeetingId", "dbo.MeetingModels");
            DropIndex("dbo.AspNetUsers", new[] { "MeetingModel_MeetingId" });
            DropIndex("dbo.MeetingModels", new[] { "Owner_Id" });
            DropColumn("dbo.AspNetUsers", "MeetingModel_MeetingId");
            DropColumn("dbo.MeetingModels", "Owner_Id");
            DropColumn("dbo.MeetingModels", "MeetingDescription");
            DropColumn("dbo.MeetingModels", "MeetingName");
        }
    }
}
