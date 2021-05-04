using Microsoft.EntityFrameworkCore;
using System;

namespace CandidateMGMT.Shared
{
    [Owned]
    public class Interview
    {
        public bool? IsContacted { get; set; }
        
        public DateTime? Time { get; set; }
        
        public string Location { get; set; }

        public string Note { get; set; }
    }
}
