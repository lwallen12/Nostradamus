using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class GenericEvent
    {
        public GenericEvent()
        {
            GenericPredictions = new HashSet<GenericPrediction>();
        }

        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateOccurs { get; set; }
        public bool? Valid { get; set; }
        public bool? Active { get; set; }
        public bool? Occurred { get; set; }
        public int? EventQualityVoteCount { get; set; }
        public DateTime? CreationDate { get; set; }
        public string NosterId { get; set; }

        public Noster Noster { get; set; }
        public ICollection<GenericPrediction> GenericPredictions { get; set; }
    }
}
