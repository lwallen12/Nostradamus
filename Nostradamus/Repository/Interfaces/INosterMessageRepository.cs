using Nostradamus.DTOs;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface INosterMessageRepository: IRepositoryBase<NosterMessage>
    {
        Task<List<NosterMessageDto>> AllRelatedMessages(Noster viewer, Noster friend);
    }
}
