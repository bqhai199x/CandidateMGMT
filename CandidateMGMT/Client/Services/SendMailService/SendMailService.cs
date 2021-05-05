using CandidateMGMT.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly HttpClient _httpClient;

        public SendMailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMail(Candidate candidate)
        {
            await _httpClient.PostAsJsonAsync("/api/sendemail/", candidate);
        }
    }
}
