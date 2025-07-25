namespace OnlineVotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Candidates", "VoteCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "VoteCount", c => c.Int(nullable: false));
        }
    }
}
