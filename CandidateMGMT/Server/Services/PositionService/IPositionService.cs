using CandidateMGMT.Shared;
using System.Collections.Generic;

namespace CandidateMGMT.Server.Services
{
    public interface IPositionService
    {
        IEnumerable<Position> GetAll();
        Position GetById(int positionId);
    }
}