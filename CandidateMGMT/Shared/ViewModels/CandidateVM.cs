using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateMGMT.Shared.ViewModels
{
    public class CandidateVM : Candidate
    {
        public string LevelName { get; set; }

        public string PositionName { get; set; }
    }
}
