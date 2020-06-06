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
    public class NosterMessagesController: ControllerBase
    {
        private IUnitofWork _unitofWork;

        public NosterMessagesController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<NosterMessageDto>> FindAllRelated()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;

            var noster = _unitofWork.Noster.GetForToken(subject);

            return await _unitofWork.NosterMessage.AllRelatedMessages(noster);

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostMessage([FromBody] NosterMessageDto nosterMessageDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;

            var noster = _unitofWork.Noster.GetForToken(subject);

            NosterMessage nosterMessage = new NosterMessage();
            nosterMessage.NosterId = noster.Id;
            nosterMessage.MessageSource = nosterMessageDto.Source;
            nosterMessage.OriginTime = nosterMessageDto.OriginTime;
            nosterMessage.MessageBody = nosterMessageDto.MessageBody;
            nosterMessage.NosterTargetUserName = nosterMessageDto.NosterTarget;

            try
            {
                await _unitofWork.NosterMessage.Create(nosterMessage);
            }
            catch (Exception ex)
            {
                return Ok(ex.InnerException.Message);
            }

            return Ok(nosterMessageDto);


        }
    }
}
