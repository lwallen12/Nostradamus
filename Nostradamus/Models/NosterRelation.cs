using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class NosterRelation
    {
        [Key]
        public string NosterId { get; set; }
        [Key]
        public string RelatedNosterId { get; set; }
        [Key]
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string RelatedUserName { get; set; }
        public string RelatedDisplayName { get; set; }
        public string RelationStatus { get; set; }
        public string RelationType { get; set; }

        public Noster Noster { get; set; }
    }
}
