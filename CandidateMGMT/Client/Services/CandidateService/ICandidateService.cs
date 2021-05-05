using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public interface ICandidateService
    {
        Task<IEnumerable<Candidate>> GetAll();

        Task<Candidate> GetById(int candidateId);

        Task Create(Candidate candidate);

        Task Update(Candidate candidate, int candidateId);

        Task Delete(int candidateId);

        IEnumerable<Candidate> Search(IEnumerable<Candidate> candidate, string searchStr);

        Task<IEnumerable<Candidate>> GetByStatus(int status);

        Task<IEnumerable<Candidate>> GetByStatus(int status1, int status2);

        Task<IEnumerable<Candidate>> GetByStatus(int status1, int status2, int status3);
     
        IEnumerable<Candidate> GetWithFiltering(IEnumerable<Candidate> candidate, int positionId, int levelId);
    }
}
