using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class GenericEventDto
    {
        public GenericEventDto()
        {
            GenericPredictionDtos = new HashSet<GenericPredictionDto>();
        }


        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateOccurs { get; set; }
        public bool? Valid { get; set; }
        public int? EventQualityVoteCount { get; set; }
        public bool? Occurred { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreationDate { get; set; }

        public NosterDto NosterDto { get; set; }
        public ICollection<GenericPredictionDto> GenericPredictionDtos { get; set; }
    }
}
