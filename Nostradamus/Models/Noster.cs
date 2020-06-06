using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class Noster : IdentityUser
    {

        public Noster()
        {
            GenericEvents = new HashSet<GenericEvent>();
            GenericPredictions = new HashSet<GenericPrediction>();
            NosterRelations = new HashSet<NosterRelation>();
            NosterMessages = new HashSet<NosterMessage>();
        }

        public DateTime? CreationDate { get; set; }

        //The two below should come in the next dev cycle
        public string DisplayName { get; set; }
        public string Motto { get; set; }

        //public NosterScore NosterScore { get; set; }

        public ICollection<NosterMessage> NosterMessages { get; set; }
        public ICollection<NosterRelation> NosterRelations { get; set; }
        public ICollection<GenericEvent> GenericEvents { get; set; }
        public ICollection<GenericPrediction> GenericPredictions { get; set; }
    }
}
