using CandidateMGMT.Shared;
using System.Collections.Generic;

namespace CandidateMGMT.Server.Services
{
    public interface ILevelService
    {
        IEnumerable<Level> GetAll();
        Level GetById(int levelId);
    }
}