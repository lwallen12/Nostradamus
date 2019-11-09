using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class GenericPrediction
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string OutcomeDescription { get; set; }
        public int? CorrectVoteCount { get; set; }
        public int? IncorrectVoteCount { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? SnapEndDate { get; set; }
        public bool Valid { get; set; }
        public bool Active { get; set; }
        public bool EventOccurred { get; set; }
        public string NosterId { get; set; }
        public int? GenericEventId { get; set; }

        public Noster Noster { get; set; }
        public GenericEvent GenericEvent { get; set; }

    }
}
