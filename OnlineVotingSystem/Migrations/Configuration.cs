namespace OnlineVotingSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OnlineVotingSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineVotingSystem.Models.VotingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineVotingSystem.Models.VotingDbContext context)
        {
            if (!context.Candidates.Any())
            {
                context.Candidates.AddOrUpdate(
                    c => c.Name,
                    new Candidate { Name = "Alice", Party = "Party A" },
                    new Candidate { Name = "Bob", Party = "Party B" },
                    new Candidate { Name = "Charlie", Party = "Party C" }
                );
                context.SaveChanges();
            }
        }

    }
}
