using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class NosterMessage
    {
        [Key]
        public string NosterId { get; set; }
        [Key]
        public string MessageSource { get; set; }
        [Key]
        public DateTime OriginTime { get; set; }
        public string MessageBody { get; set; }
        public string MessageTitle { get; set; }

        public Noster Noster { get; set; }
    }
}
