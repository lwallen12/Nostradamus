using Microsoft.AspNetCore.Authentication.JwtBearer;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("reqinbox")]
        public async Task<IEnumerable<NosterRelationDto>> GetMyRequestInbox()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            return await _unitofWork.NosterRelation.GetMyRequestInbox(subject);
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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("sendFriend")]
        public async Task<IActionResult> SendFriendRequest([FromBody] NosterRelationDto nosterRelationDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            var requestingNoster = _unitofWork.Noster.GetForToken(subject);
            var requestedNoster = _unitofWork.Noster.GetForToken(nosterRelationDto.RelatedUserName);

            NosterRelation nosterRelation = new NosterRelation();
            nosterRelation.NosterId = requestingNoster.Id;
            nosterRelation.UserName = requestingNoster.UserName;
            nosterRelation.RelatedNosterId = requestedNoster.Id;
            nosterRelation.RelatedUserName = requestedNoster.UserName;
            nosterRelation.CreationDate = nosterRelationDto.CreationDate;
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

            return Ok(nosterRelationDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("confirmFriend")]
        public async Task<IActionResult> ConfirmRequest([FromBody] NosterRelationDto nosterRelationDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;
            var subject = tokenDecode.Subject;

            var approvingNoster = _unitofWork.Noster.GetForToken(subject);
            var reacherOuterNoster = _unitofWork.Noster.GetForToken(nosterRelationDto.RelatedUserName);

            if (nosterRelationDto.RelationStatus == "Approved")
            {
                NosterRelation nosterRelation = new NosterRelation();
                nosterRelation.NosterId = approvingNoster.Id;
                nosterRelation.UserName = approvingNoster.UserName;
                nosterRelation.CreationDate = nosterRelationDto.CreationDate;
                nosterRelation.RelatedNosterId = reacherOuterNoster.Id;
                nosterRelation.RelatedUserName = reacherOuterNoster.UserName;
                nosterRelation.RelationType = "Friend";
                nosterRelation.RelationStatus = "Approved";

                var updateRelation = await _unitofWork.NosterRelation.GetPendingRequest(nosterRelationDto);

                try
                {
                    await _unitofWork.NosterRelation.Create(nosterRelation);
                    await _unitofWork.NosterRelation.MarkAccepted(updateRelation);
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
                return Ok(nosterRelationDto);
            }
            else
            {
                NosterRelation updateRelation = new NosterRelation();
                updateRelation.NosterId = reacherOuterNoster.Id;
                updateRelation.UserName = reacherOuterNoster.UserName;
                updateRelation.RelatedNosterId = approvingNoster.Id;
                updateRelation.RelatedUserName = approvingNoster.UserName;
                updateRelation.RelationType = "Friend";
                updateRelation.RelationStatus = "Denied";

                try
                {
                    await _unitofWork.NosterRelation.Update(updateRelation);
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
                return Ok(nosterRelationDto);
            }
        }


    }
}
