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
        public string RefreshToken { get; set; }
        public DateTime? RefreshExpiration { get; set; }

        //public NosterScore NosterScore { get; set; }

        public ICollection<NosterMessage> NosterMessages { get; set; }
        public ICollection<NosterRelation> NosterRelations { get; set; }
        public ICollection<GenericEvent> GenericEvents { get; set; }
        public ICollection<GenericPrediction> GenericPredictions { get; set; }
    }
}
