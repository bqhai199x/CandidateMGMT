using CandidateMGMT.Shared;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    public interface IUploadService
    {
        Task Upload(UploadedFile file);
    }
}