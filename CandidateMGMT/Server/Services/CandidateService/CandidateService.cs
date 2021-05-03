using CandidateMGMT.Server.Data;
using CandidateMGMT.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMGMT.Server.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CandidateDbContext _context;

        public CandidateService(CandidateDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _context.Candidate
                .Include(x => x.Level)
                .Include(x => x.Position)
                .ToListAsync();
        }

        public async Task<Candidate> GetById(int candidateId)
        {
            return await _context.Candidate
                .Include(x => x.Level)
                .Include(x => x.Position)
                .FirstOrDefaultAsync(x => x.CandidateId == candidateId);
        }

        public async Task<Candidate> Create(Candidate candidate)
        {
            var result = await _context.Candidate.AddAsync(candidate);
            await _context.SaveChangesAsync();
            return result.Entity; ;
        }

        public async Task<Candidate> Update(Candidate candidate)
        {
            var result = await _context.Candidate
                .FirstOrDefaultAsync(c => c.CandidateId == candidate.CandidateId);

            if (result != null)
            {
                result.PositionId = candidate.PositionId;
                result.LevelId = candidate.LevelId;
                result.FullName = candidate.FullName;
                result.Birthday = candidate.Birthday;
                result.Address = candidate.Address;
                result.Address = candidate.Address;
                result.Email = candidate.Email;
                result.Phone = candidate.Phone;
                result.CVPath = candidate.CVPath;
                result.IntroduceName = candidate.IntroduceName;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Candidate> Delete(int candidateId)
        {
            var result = await _context.Candidate.FindAsync(candidateId);
            if (result != null)
            {
                _context.Candidate.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Candidate>> Search(string searchStr)
        {
            return await _context.Candidate
                .Where(x => x.FullName.Contains(searchStr))
                .Include(x => x.Level)
                .Include(x => x.Position)
                .ToListAsync();
        }
    }
}
