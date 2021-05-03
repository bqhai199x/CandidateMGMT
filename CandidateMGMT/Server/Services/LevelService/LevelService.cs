using CandidateMGMT.Server.Data;
using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Linq;

namespace CandidateMGMT.Server.Services
{
    public class LevelService : ILevelService
    {
        private readonly CandidateDbContext _context;

        public LevelService(CandidateDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Level> GetAll()
        {
            return _context.Level;
        }

        public Level GetById(int levelId)
        {
            return _context.Level.Find(levelId);
        }
    }
}
