using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    interface ILevelService
    {
        Task<IEnumerable<Level>> GetAll();
    }
}
