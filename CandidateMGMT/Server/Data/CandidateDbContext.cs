using CandidateMGMT.Shared;
using Microsoft.EntityFrameworkCore;

namespace CandidateMGMT.Server.Data
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext (DbContextOptions<CandidateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
