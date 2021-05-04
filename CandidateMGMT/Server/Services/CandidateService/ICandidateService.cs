using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMGMT.Server.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate> GetById(int candidateId);
        Task<Candidate> Create(Candidate candidate);
        Task<Candidate> Update(Candidate candidate);
        Task<Candidate> Delete(int candidateId);
    }
}