using CandidateMGMT.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateMGMT.Client.Services
{
    interface IPositionService
    {
        Task<IEnumerable<Position>> GetAll();
    }
}
