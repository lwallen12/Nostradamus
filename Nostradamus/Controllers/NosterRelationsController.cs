﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostradamus.DTOs;
using Nostradamus.Repository.Interfaces;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Nostradamus.Models;
using System;
using System.Linq;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    public class NosterRelationsController: ControllerBase
    {
        private IUnitofWork _unitofWork;

        public NosterRelationsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IEnumerable<NosterRelationDto>> GetMyFriends()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            return await _unitofWork.NosterRelation.GetMyFreinds(subject);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("allpending")]
        //public async Task<IEnumerable<NosterRelationDto>> AllPending()
        //{
        //    var token = await HttpContext.GetTokenAsync("access_token");
        //    var handler = new JwtSecurityTokenHandler();
        //    var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
        //    var subject = tokenDecode.Subject;

        //    //Probably a little inefficient but I will hold off for now... May be useful to have these methods
        //    //seperate anyway
        //    var pendingReceived = await _unitofWork.NosterRelation.GetMyRequestInbox(subject);
        //    var pendingSent = await _unitofWork.NosterRelation.GetMyPendingSent(subject);

        //    return pendingReceived.Concat(pendingSent);
        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("reqinbox")]
        public async Task<IEnumerable<NosterDto>> GetMyRequestInbox()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            return await  _unitofWork.NosterRelation.GetMyRequestInbox(subject);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("pendingsent")]
        public async Task<IEnumerable<NosterRelationDto>> GetPendingSent()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            return await _unitofWork.NosterRelation.GetMyPendingSent(subject);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("pendingsent")]
        //public async Task<IEnumerable<NosterRelationDto>> GetTopRandom()
        //{
        //    var token = await HttpContext.GetTokenAsync("access_token");
        //    var handler = new JwtSecurityTokenHandler();
        //    var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
        //    var subject = tokenDecode.Subject;

        //    return await _unitofWork.NosterRelation.GetMyPendingSent(subject);
        //}


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("sendFriend")]
        public async Task<IActionResult> SendFriendRequest([FromBody] NosterDto nosterDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            var requestingNoster = _unitofWork.Noster.GetForToken(subject);
            var requestedNoster = _unitofWork.Noster.GetForToken(nosterDto.UserName);

            NosterRelation nosterRelation = new NosterRelation();
            nosterRelation.NosterId = requestingNoster.Id;
            nosterRelation.UserName = requestingNoster.UserName;
            nosterRelation.RelatedNosterId = requestedNoster.Id;
            nosterRelation.RelatedUserName = requestedNoster.UserName;
            nosterRelation.CreationDate = (DateTime)nosterDto.CreationDate;
            nosterRelation.RelationStatus = "Pending";
            nosterRelation.RelationType = "Friend";
            try
            {
                await _unitofWork.NosterRelation.Create(nosterRelation);
            }
            catch (Exception ex)
            {
                return Ok(ex.InnerException.Message);
            }

            return Ok(nosterDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("confirmFriend")]
        public async Task<IActionResult> ConfirmRequest([FromBody] NosterDto nosterDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            var approvingNoster = _unitofWork.Noster.GetForToken(subject);
            var reacherOuterNoster = _unitofWork.Noster.GetForToken(nosterDto.UserName);

            
            NosterRelation nosterRelation = new NosterRelation();
            nosterRelation.NosterId = approvingNoster.Id;
            nosterRelation.UserName = approvingNoster.UserName;
            nosterRelation.CreationDate = (DateTime)nosterDto.CreationDate;
            nosterRelation.RelatedNosterId = reacherOuterNoster.Id;
            nosterRelation.RelatedUserName = reacherOuterNoster.UserName;
            nosterRelation.RelationType = "Friend";
            nosterRelation.RelationStatus = "Approved";

            var updateRelation = await _unitofWork.NosterRelation.GetPendingRequest(reacherOuterNoster.UserName);

            try
            {
                await _unitofWork.NosterRelation.Create(nosterRelation);
                await _unitofWork.NosterRelation.MarkAccepted(updateRelation);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(nosterDto);
           
            }
        }


    }

