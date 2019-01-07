namespace PlannerMSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig61 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "MeetingModel_MeetingId", "dbo.MeetingModels");
            DropIndex("dbo.AspNetUsers", new[] { "MeetingModel_MeetingId" });
            AddColumn("dbo.EventModels", "Name", c => c.String());
            AddColumn("dbo.EventModels", "Description", c => c.String());
            AddColumn("dbo.MeetingModels", "Name", c => c.String());
            AddColumn("dbo.MeetingModels", "Description", c => c.String());
            AddColumn("dbo.ExpenseModels", "Name", c => c.String());
            AddColumn("dbo.ExpenseModels", "Description", c => c.String());
            AddColumn("dbo.ExpenseModels", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.EventModels", "EventName");
            DropColumn("dbo.EventModels", "EventDescription");
            DropColumn("dbo.MeetingModels", "MeetingName");
            DropColumn("dbo.MeetingModels", "MeetingDescription");
            DropColumn("dbo.AspNetUsers", "MeetingModel_MeetingId");
            DropColumn("dbo.ExpenseModels", "ExpenseName");
            DropColumn("dbo.ExpenseModels", "ExpenseDescription");
            DropColumn("dbo.ExpenseModels", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpenseModels", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ExpenseModels", "ExpenseDescription", c => c.String());
            AddColumn("dbo.ExpenseModels", "ExpenseName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MeetingModel_MeetingId", c => c.Int());
            AddColumn("dbo.MeetingModels", "MeetingDescription", c => c.String());
            AddColumn("dbo.MeetingModels", "MeetingName", c => c.String(nullable: false));
            AddColumn("dbo.EventModels", "EventDescription", c => c.String());
            AddColumn("dbo.EventModels", "EventName", c => c.String());
            DropColumn("dbo.ExpenseModels", "Cost");
            DropColumn("dbo.ExpenseModels", "Description");
            DropColumn("dbo.ExpenseModels", "Name");
            DropColumn("dbo.MeetingModels", "Description");
            DropColumn("dbo.MeetingModels", "Name");
            DropColumn("dbo.EventModels", "Description");
            DropColumn("dbo.EventModels", "Name");
            CreateIndex("dbo.AspNetUsers", "MeetingModel_MeetingId");
            AddForeignKey("dbo.AspNetUsers", "MeetingModel_MeetingId", "dbo.MeetingModels", "MeetingId");
        }
    }
}
