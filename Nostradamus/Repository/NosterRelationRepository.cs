using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus.DTOs;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class NosterRelationRepository : RepositoryBase<NosterRelation>, INosterRelationRepository
    {
        public NosterRelationRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {

        }

        public async Task<List<NosterRelationDto>> GetMyFreinds(string nosterUserName)
        {
            var nosterRelations = this._nostradamusContext.NosterRelation
                .Where(nr => nr.UserName == nosterUserName).ToAsyncEnumerable();

            var nosterRelationDtos = nosterRelations.Select(nr => new NosterRelationDto
            {
                UserName = nr.UserName,
                DisplayName = nr.DisplayName,
                RelatedUserName = nr.RelatedUserName,
                RelatedDisplayName = nr.RelatedDisplayName,
                CreationDate = nr.CreationDate,
                RelationStatus = nr.RelationStatus,
                RelationType = nr.RelationType,
            }).Where(nr => nr.RelationStatus == "Approved").ToList();

            return await nosterRelationDtos;
        }

        public async Task<List<NosterRelationDto>> GetMyRequestInbox(string nosterUserName)
        {
            var nosterRelations = this._nostradamusContext.NosterRelation
                .Where(nr => nr.RelationStatus == "Pending")
                .Where(nr => nr.RelatedUserName == nosterUserName).ToAsyncEnumerable();

            var nosterRelationDtos = nosterRelations.Select(nr => new NosterRelationDto
            {
                UserName = nr.UserName,
                DisplayName = nr.DisplayName,
                RelatedUserName = nr.RelatedUserName,
                RelatedDisplayName = nr.RelatedDisplayName,
                CreationDate = nr.CreationDate,
                RelationStatus = nr.RelationStatus,
                RelationType = nr.RelationType,
            }).ToList();

            return await nosterRelationDtos;
        }

        public async Task<List<NosterRelationDto>> GetMyPendingSent(string nosterUserName)
        {
            var nosterRelations = this._nostradamusContext.NosterRelation
                .Where(nr => nr.UserName == nosterUserName)
                .Where(nr => nr.RelationStatus == "Pending")
                .ToAsyncEnumerable();

            var nosterRelationDtos = nosterRelations.Select(nr => new NosterRelationDto
            {
                UserName = nr.UserName,
                DisplayName = nr.DisplayName,
                RelatedUserName = nr.RelatedUserName,
                RelatedDisplayName = nr.RelatedDisplayName,
                CreationDate = nr.CreationDate,
                RelationStatus = nr.RelationStatus,
                RelationType = nr.RelationType,
            }).ToList();

            return await nosterRelationDtos;
        }



        public async Task<NosterRelation> GetPendingRequest(NosterRelationDto nosterRelationDto)
        {
            var nosterRelation = this._nostradamusContext.NosterRelation
                .Where(nr => nr.RelationStatus == "Pending")
                .Where(nr => nr.UserName == nosterRelationDto.RelatedUserName).FirstOrDefaultAsync();

            return await nosterRelation;
        }


        public async Task MarkAccepted(NosterRelation nosterRelation)
        {
            nosterRelation.RelationStatus = "Approved";
            _nostradamusContext.Set<NosterRelation>().Update(nosterRelation);

            await _nostradamusContext.SaveChangesAsync();
        }

        //public async Task<IActionResult> SendFriendRequest(NosterRelationDto nosterRelationDto)
        //{

        //}

        //public async Task<IActionResult> ReviewFriendRequest(NosterRelation approvingNoster, NosterRelation reacherOuterNoster, NosterRelationDto reviewPayload)
        //{
        //    if (reviewPayload.RelationStatus == "Approved")
        //    {

        //    }
        //}
    }
}
