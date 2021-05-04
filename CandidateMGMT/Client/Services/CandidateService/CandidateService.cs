using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly HttpClient _httpClient;

        public CandidateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Candidate>>("api/candidate");
        }

        public async Task<Candidate> GetById(int candidateId)
        {
            return await _httpClient.GetFromJsonAsync<Candidate>($"api/candidate/{candidateId}");
        }

        public async Task Update(Candidate candidate, int candidateId)
        {
            await _httpClient.PutAsJsonAsync($"/api/candidate/{candidateId}", candidate);
        }

        public async Task Create(Candidate candidate)
        {
            await _httpClient.PostAsJsonAsync("/api/candidate/", candidate);
        }

        public async Task Delete(int candidateId)
        {
            await _httpClient.DeleteAsync($"/api/candidate/{candidateId}");
        }

        public async Task<IEnumerable<Candidate>> Search(string searchStr)
        {
            var result = await GetAll();
            return result.Where(x => x.FullName.ToLower().Contains(searchStr.ToLower()));
        }

        public async Task<IEnumerable<Candidate>> GetByStatus(int status)
        {
            var result = await GetAll();
            return result.Where(x => x.Status == status);
        }

        public async Task<IEnumerable<Candidate>> GetByStatus(int status1, int status2)
        {
            var result = await GetAll();
            return result.Where(x => x.Status == status1 || x.Status == status2);
        }

        public async Task<IEnumerable<Candidate>> GetByStatus(int status1, int status2, int status3)
        {
            var result = await GetAll();
            return result.Where(x => x.Status == status1 || x.Status == status2 || x.Status == status3);
        }

        public async Task<IEnumerable<Candidate>> GetWithFiltering(int? positionId, int? levelId)
        {
            var result = await GetAll();
            if(positionId != null)
            {
                result = result.Where(x => x.PositionId == positionId);
            }
            if (levelId != null)
            {
                result = result.Where(x => x.LevelId == positionId);
            }
            return result;
        }
    }
}
