using CandidateMGMT.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public class UploadService : IUploadService
    {
        private readonly HttpClient _httpClient;

        public UploadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Upload(UploadedFile file)
        {
            await _httpClient.PostAsJsonAsync<UploadedFile>("/api/fileupload", file);
        }
    }
}
