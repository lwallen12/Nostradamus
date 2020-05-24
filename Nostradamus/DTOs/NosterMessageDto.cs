using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class NosterMessageDto
    {
        public string NosterTarget { get; set; }
        public string Source { get; set; }
        public DateTime OriginTime { get; set; }
        public string MessageBody { get; set; }
        public string Title { get; set; }
    }
}
