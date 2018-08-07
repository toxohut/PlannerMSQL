namespace PlannerMSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        OpenAnswer = c.String(),
                        VotingAnswerId_VotingAnswerId = c.Int(),
                        VotingId_VotingId = c.Int(),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.VotingAnswers", t => t.VotingAnswerId_VotingAnswerId)
                .ForeignKey("dbo.Votings", t => t.VotingId_VotingId)
                .Index(t => t.VotingAnswerId_VotingAnswerId)
                .Index(t => t.VotingId_VotingId);
            
            CreateTable(
                "dbo.VotingAnswers",
                c => new
                    {
                        VotingAnswerId = c.Int(nullable: false, identity: true),
                        VotingId = c.Int(nullable: false),
                        AnswerText = c.String(),
                    })
                .PrimaryKey(t => t.VotingAnswerId)
                .ForeignKey("dbo.Votings", t => t.VotingId, cascadeDelete: true)
                .Index(t => t.VotingId);
            
            CreateTable(
                "dbo.Votings",
                c => new
                    {
                        VotingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsOpenQuestion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VotingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "VotingId_VotingId", "dbo.Votings");
            DropForeignKey("dbo.Votes", "VotingAnswerId_VotingAnswerId", "dbo.VotingAnswers");
            DropForeignKey("dbo.VotingAnswers", "VotingId", "dbo.Votings");
            DropIndex("dbo.VotingAnswers", new[] { "VotingId" });
            DropIndex("dbo.Votes", new[] { "VotingId_VotingId" });
            DropIndex("dbo.Votes", new[] { "VotingAnswerId_VotingAnswerId" });
            DropTable("dbo.Votings");
            DropTable("dbo.VotingAnswers");
            DropTable("dbo.Votes");
        }
    }
}
