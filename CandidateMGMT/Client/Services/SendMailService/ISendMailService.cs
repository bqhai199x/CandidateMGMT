using CandidateMGMT.Shared;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public interface ISendMailService
    {
        Task SendMail(Candidate candidate);
    }
}