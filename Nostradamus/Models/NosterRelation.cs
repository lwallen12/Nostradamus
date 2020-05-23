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
        public string UserName { get; set; }
        [Key]
        public string RelatedNosterId { get; set; }
        public string RelatedUserName { get; set; }
        [Key]
        public string RelationType { get; set; }

        public Noster Noster { get; set; }
    }
}
