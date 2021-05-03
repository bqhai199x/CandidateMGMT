using CandidateMGMT.Server.Data;
using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Linq;

namespace CandidateMGMT.Server.Services
{
    public class PositionService : IPositionService
    {
        private readonly CandidateDbContext _context;

        public PositionService(CandidateDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Position> GetAll()
        {
            return _context.Position.ToList();
        }

        public Position GetById(int positionId)
        {
            return _context.Position.Find(positionId);
        }
    }
}
