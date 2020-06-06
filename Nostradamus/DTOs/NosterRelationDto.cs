using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class NosterRelationDto
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string RelatedUserName { get; set; }
        public string RelatedDisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string RelationStatus { get; set; }
        public string RelationType { get; set; }

        public NosterDto NosterDto { get; set; }
    }
}
