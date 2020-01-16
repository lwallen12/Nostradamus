using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class NosterScoreDto
    {
        public string UserName { get; set; }
        public int? RunningTotal { get; set; }
        public int? GenericPredictionTotal { get; set; }

        public NosterDto NosterDto { get; set; }
    }
}
