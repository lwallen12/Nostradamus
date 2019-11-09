using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class GenericPredictionDto
    {

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string OutcomeDescription { get; set; }
        public int? CorrectVoteCount { get; set; }
        public int? IncorrectVoteCount { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? SnapEndDate { get; set; }
        public string Valid { get; set; }
        public string Active { get; set; }
        public string EventOccurred { get; set; }
        public int? GenericEventId { get; set; }

        public NosterDto NosterDto { get; set; }
        public GenericEventDto GenericEventDto { get; set; }

    }
}
