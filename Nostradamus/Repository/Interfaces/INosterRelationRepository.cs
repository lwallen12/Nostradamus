using Microsoft.AspNetCore.Mvc;
using Nostradamus.DTOs;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface INosterRelationRepository: IRepositoryBase<NosterRelation>
    {
        Task<List<NosterRelationDto>> GetMyFreinds(string nosterUserName);
        //Task<IActionResult> SendFriendRequest(NosterRelationDto nosterRelationDto);
        //Task<IActionResult> ReviewFriendRequest(NosterRelationDto nosterRelationDto);

        Task MarkAccepted(NosterRelation nosterRelation);
        Task<NosterRelation> GetPendingRequest(NosterRelationDto nosterRelationDto);
    }
}
