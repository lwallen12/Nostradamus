using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class NosterScore
    {
        [Key]
        public string NosterId { get; set; }
        public string UserName { get; set; }
        public int? RunningTotal { get; set; }
        public int? GenericPredictionTotal { get; set; }

        public Noster Noster { get; set; }
    }
}
