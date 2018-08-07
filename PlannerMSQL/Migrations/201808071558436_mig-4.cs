namespace PlannerMSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "VotingAnswerId_VotingAnswerId", "dbo.VotingAnswers");
            DropIndex("dbo.Votes", new[] { "VotingAnswerId_VotingAnswerId" });
            RenameColumn(table: "dbo.Votes", name: "VotingAnswerId_VotingAnswerId", newName: "VotingAnswerId");
            RenameColumn(table: "dbo.Votes", name: "VotingId_VotingId", newName: "VotingId");
            RenameIndex(table: "dbo.Votes", name: "IX_VotingId_VotingId", newName: "IX_VotingId");
            AlterColumn("dbo.Votes", "VotingAnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Votings", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Votes", "VotingAnswerId");
            AddForeignKey("dbo.Votes", "VotingAnswerId", "dbo.VotingAnswers", "VotingAnswerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "VotingAnswerId", "dbo.VotingAnswers");
            DropIndex("dbo.Votes", new[] { "VotingAnswerId" });
            AlterColumn("dbo.Votings", "Name", c => c.String());
            AlterColumn("dbo.Votes", "VotingAnswerId", c => c.Int());
            RenameIndex(table: "dbo.Votes", name: "IX_VotingId", newName: "IX_VotingId_VotingId");
            RenameColumn(table: "dbo.Votes", name: "VotingId", newName: "VotingId_VotingId");
            RenameColumn(table: "dbo.Votes", name: "VotingAnswerId", newName: "VotingAnswerId_VotingAnswerId");
            CreateIndex("dbo.Votes", "VotingAnswerId_VotingAnswerId");
            AddForeignKey("dbo.Votes", "VotingAnswerId_VotingAnswerId", "dbo.VotingAnswers", "VotingAnswerId");
        }
    }
}
