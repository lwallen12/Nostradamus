using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class NosterDto
    {
        public NosterDto()
        {
            GenericEventDtos = new HashSet<GenericEventDto>();
            GenericPredictionDtos = new HashSet<GenericPredictionDto>();
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? CreationDate { get; set; }

        //public NosterScoreDto NosterScoreDto { get; set; }
        public ICollection<GenericEventDto> GenericEventDtos { get; set; }
        public ICollection<GenericPredictionDto> GenericPredictionDtos { get; set; }

    }
}
