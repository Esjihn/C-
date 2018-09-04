using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        public List<MatchupModel> Entries { get; set; } = new List<MatchupModel>();
        public TeamModel Winnder { get; set; }
        public int MatchupRound { get; set; }

    }
}
