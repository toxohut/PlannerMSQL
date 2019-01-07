namespace PlannerMSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        MeetingId = c.Int(nullable: false),
                        EventName = c.String(),
                        EventDescription = c.String(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.MeetingModels", t => t.MeetingId, cascadeDelete: true)
                .Index(t => t.MeetingId);
            
            CreateTable(
                "dbo.MeetingModels",
                c => new
                    {
                        MeetingId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MeetingId);
            
            CreateTable(
                "dbo.ExpenseModels",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        MeetingId = c.Int(nullable: false),
                        ExpenseName = c.String(),
                        ExpenseDescription = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.MeetingModels", t => t.MeetingId, cascadeDelete: true)
                .Index(t => t.MeetingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseModels", "MeetingId", "dbo.MeetingModels");
            DropForeignKey("dbo.EventModels", "MeetingId", "dbo.MeetingModels");
            DropIndex("dbo.ExpenseModels", new[] { "MeetingId" });
            DropIndex("dbo.EventModels", new[] { "MeetingId" });
            DropTable("dbo.ExpenseModels");
            DropTable("dbo.MeetingModels");
            DropTable("dbo.EventModels");
        }
    }
}
