using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public class PositionService : IPositionService
    {
        private readonly HttpClient _httpClient;

        public PositionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<Position>>("api/position");
        }
    }
}
