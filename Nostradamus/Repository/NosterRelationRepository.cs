﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<NosterDto>> GetMyRequestInbox(string nosterUserName)
        {
            var userNames = this._nostradamusContext.NosterRelation
                .Where(nr => nr.RelationStatus == "Pending")
                .Where(nr => nr.RelatedUserName == nosterUserName).ToList();

            List<string> nosterUsers = new List<string>();

            foreach (var names in userNames)
            {
                nosterUsers.Add(names.UserName);
            }

            //List<string> nosterUsers = new List<string>() { "a.allenwill@gmail.com", "bobbody@gmail.com" };

            
            var nosterList = _nostradamusContext.Noster.Where(n => nosterUsers.Contains(n.UserName));
            //var nosterList = _nostradamusContext.Noster.Where(n => userNames.Contains());

            var nosterDtos = nosterList.Select(n => new NosterDto
            {
                UserName = n.UserName,
                Email = n.Email,
                PhoneNumber = n.PhoneNumber,
                PhoneNumberConfirmed = n.PhoneNumberConfirmed,
                TwoFactorEnabled = n.TwoFactorEnabled,
                CreationDate = n.CreationDate,
                DisplayName = n.DisplayName,
                Motto = n.Motto
                ////NosterScoreDto = iMapper.Map(n.NosterScore, nosterScoreDto),
                //GenericEventDtos = iMapper.Map(n.GenericEvents, GenericEventDtos),
                //GenericPredictionDtos = iMapper.Map(n.GenericPredictions, genericPredictionDtos)
            }).ToList();

            return nosterDtos;

            //var nosterDtos = this._nostradamusContext.Noster.Where(n => n.UserName in { })

            //var nosterRelationDtos = nosterRelations.Select(nr => new NosterRelationDto
            //{
            //    UserName = nr.UserName,
            //    DisplayName = nr.DisplayName,
            //    RelatedUserName = nr.RelatedUserName,
            //    RelatedDisplayName = nr.RelatedDisplayName,
            //    CreationDate = nr.CreationDate,
            //    RelationStatus = nr.RelationStatus,
            //    RelationType = nr.RelationType,
            //}).ToList();

            //return await nosterRelationDtos;
        }

        //public async Task<List<NosterRelationDto>> GetTopRandom(string search)
        //{
        //    var nosterRelations = (from nosterRelation in this._nostradamusContext.NosterRelation
        //                          where nosterRelation.DisplayName == search ||
        //                          nosterRelation.UserName == search
        //                          select nosterRelation);

        //    var nosterRelationDtos = nosterRelations.Select(nr => new NosterRelationDto
        //    {
        //        UserName = nr.UserName,
        //        DisplayName = nr.DisplayName,
        //        RelatedUserName = nr.RelatedUserName,
        //        RelatedDisplayName = nr.RelatedDisplayName,
        //        CreationDate = nr.CreationDate,
        //        RelationStatus = nr.RelationStatus,
        //        RelationType = nr.RelationType,
        //    }).ToList();

        //    return nosterRelations;
        //}

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



        public async Task<NosterRelation> GetPendingRequest(string userName)
        {
            var noster = _nostradamusContext.Noster.Single(n => n.UserName == userName);

            var nosterRelation = this._nostradamusContext.NosterRelation
                .Where(nr => nr.RelationStatus == "Pending")
                .Where(nr => nr.UserName == userName).FirstOrDefaultAsync();

            return await nosterRelation;
        }


        public async Task MarkAccepted(NosterRelation nosterRelation)
        {
            nosterRelation.RelationStatus = "Approved";
            _nostradamusContext.Set<NosterRelation>().Update(nosterRelation);

            await _nostradamusContext.SaveChangesAsync();
        }

        public async Task MarkDenied(NosterRelation nosterRelation)
        {
            nosterRelation.RelationStatus = "Denied";
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

    public class UserNameOnlyDto
    {
        public string UserName { get; set; }
    }
}
