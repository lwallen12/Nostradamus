using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class PresidentialPredictionFormDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string NosterId { get; set; }
        public string Candidate1 { get; set; }
        public string Candidate1Party { get; set; }
        public string Candidate1VP { get; set; }
        public int Candidate1FaithlessElectors { get; set; }
        public string Candidate2 { get; set; }
        public string Candidate2Party { get; set; }
        public string Candidate2VP { get; set; }
        public int Candidate2FaithlessElectors { get; set; }
        public string PopularVoteWinner { get; set; }
        public string ElectoralVoteWinner { get; set; }
        public string ElectionWinner { get; set; } //This could be different than ElectoralVoteWinner... what if it is done away with?
        public string Description { get; set; }
        public string Why { get; set; }
        public DateTime? SnapStartDate { get; set; }
        public DateTime? SnapEndDate { get; set; }
        public bool Scored { get; set; }
        public bool Active { get; set; }
        public bool Valid { get; set; }
        public string ALVote { get; set; } = "Republican";
        public string AKVote { get; set; } = "Republican";
        public string AZVote { get; set; } = "Republican";
        public string ARVote { get; set; } = "Republican";
        public string CAVote { get; set; } = "Democrat";
        public string COVote { get; set; } = "Democrat";
        public string CTVote { get; set; } = "Democrat";
        public string DEVote { get; set; } = "Democrat";
        public string FLVote { get; set; } = "Republican";
        public string GAVote { get; set; } = "Republican";
        public string HIVote { get; set; } = "Democrat";
        public string IDVote { get; set; } = "Republican";
        public string ILVote { get; set; } = "Democrat";
        public string INVote { get; set; } = "Republican";
        public string IAVote { get; set; } = "Republican";
        public string KSVote { get; set; } = "Republican";
        public string KYVote { get; set; } = "Republican";
        public string LAVote { get; set; } = "Republican";
        public string MEVote { get; set; } = "Democrat";
        public string MDVote { get; set; } = "Democrat";
        public string MAVote { get; set; } = "Democrat";
        public string MIVote { get; set; } = "Republican";
        public string MNVote { get; set; } = "Democrat";
        public string MSVote { get; set; } = "Republican";
        public string MOVote { get; set; } = "Republican";
        public string MTVote { get; set; } = "Republican";
        public string NEVote { get; set; } = "Republican";
        public string NVVote { get; set; } = "Democrat";
        public string NHVote { get; set; } = "Democrat";
        public string NJVote { get; set; } = "Democrat";
        public string NMVote { get; set; } = "Democrat";
        public string NYVote { get; set; } = "Democrat";
        public string NCVote { get; set; } = "Republican";
        public string NDVote { get; set; } = "Republican";
        public string OHVote { get; set; } = "Republican";
        public string OKVote { get; set; } = "Republican";
        public string ORVote { get; set; } = "Democrat";
        public string PAVote { get; set; } = "Republican";
        public string RIVote { get; set; } = "Democrat";
        public string SCVote { get; set; } = "Republican";
        public string SDVote { get; set; } = "Republican";
        public string TNVote { get; set; } = "Republican";
        public string TXVote { get; set; } = "Republican";
        public string UTVote { get; set; } = "Republican";
        public string VTVote { get; set; } = "Republican";
        public string VAVote { get; set; } = "Republican";
        public string WAVote { get; set; } = "Democrat";
        public string WVVote { get; set; } = "Republican";
        public string WIVote { get; set; } = "Republican";
        public string WYVote { get; set; } = "Republican";

        public NosterDto NosterDto { get; set; }
    }
}
