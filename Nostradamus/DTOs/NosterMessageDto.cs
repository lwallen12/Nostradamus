using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.DTOs
{
    public class NosterMessageDto
    {
        public string NosterTarget { get; set; }
        public string TargetDisplayName { get; set; }
        public string SourceDisplayName { get; set; }
        public string Source { get; set; }
        public DateTime OriginTime { get; set; }
        public string MessageBody { get; set; }
        public bool IsSeen { get; set; }
    }
}
