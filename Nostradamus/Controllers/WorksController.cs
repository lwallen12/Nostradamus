using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nostradamus.DTOs;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    public class WorksController : ControllerBase
    {
        private IUnitofWork _unitofWork;

        public WorksController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public async Task<IEnumerable<NosterDto>> FindDto()
        {
            return await _unitofWork.Noster.FindAllWithIncludes();
        }

        [HttpPost("genericevent")]
        public async Task<IActionResult> PostGenericEvent([FromBody] GenericEvent genericEvent)
        {
            genericEvent.CreationDate = DateTime.Now;

            await _unitofWork.GenericEvent.Create(genericEvent);

            return CreatedAtAction("GetGenericEvent", new { id = genericEvent.Id }, genericEvent);
        }

        

        [HttpPost("genericprediction")]
        public async Task<IActionResult> PostGenericPrediction([FromBody] GenericPrediction genericPrediction)
        {
            genericPrediction.CreationDate = DateTime.Now;

            await _unitofWork.GenericPrediction.Create(genericPrediction);

            return CreatedAtAction("GetGenericPrediction", new { id = genericPrediction.Id }, genericPrediction);
        }

        [HttpGet("getprediction/{id}")]
        public async Task<GenericPrediction> GetGenericPrediction(int id)
        {
            return await _unitofWork.GenericPrediction.FindById(id);
        }

        [HttpPut("deleteprediction")]
        public async Task DeleteGenericPrediction([FromBody] GenericPrediction genericPrediction)
        {
            await _unitofWork.GenericPrediction.MarkDelete(genericPrediction);
        }

        [HttpPut("updateprediction")]
        public async Task UpdatePrediction([FromBody] GenericPrediction genericPrediction)
        {
            await _unitofWork.GenericPrediction.MarkUpdate(genericPrediction);
        }


        //[HttpGet("tokenz")]
        //public JwtSecurityToken ParseToken()
        //{
        //    var stream = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJXaWxsQGdtYWlsLmNvbSIsImp0aSI6IjMxMWM3ZGU5LTcxMDctNGI4MC1hMzViLTA4NjJlYTE1MjZjOCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYzE3ZTEyNWItYmE0NC00N2MxLTg2NzUtOTc2ZmJlZDRlMTEyIiwiZXhwIjoxNTc2NDU0NDYxLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1NzA5NiIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjU3MDk2In0.VtsMgq7fc17M6y8kKHQRw3vO3M7aSrQgF62gw0-mXWg";

        //    var handler = new JwtSecurityTokenHandler();

        //    var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

        //    //var tokenSubject = tokenS.Subject;

        //    //var noster = _unitofWork.Noster.GetForToken(tokenSubject);

        //    //return noster;

        //    return tokenS;
        //}

        [HttpGet("moretokenz")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<JwtSecurityToken>> MoreToken()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
           

            var handler = new JwtSecurityTokenHandler();

            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            return tokenDecode;
        }

        [HttpGet("{id}")]
        public async Task<GenericEventDto> GetGenericEvent(int id)
        {
            //return await _unitofWork.GenericEvent.FindById(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GenericEvent, GenericEventDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var genericEvent = await _unitofWork.GenericEvent.FindById(id);
            GenericEventDto dto = new GenericEventDto();

            var genericEventDto = iMapper.Map(genericEvent, dto);

            return genericEventDto;
        }

        [HttpGet("genericevents")]
        public async Task<IEnumerable<GenericEventDto>> GetGenericEvents()
        {
            return await _unitofWork.GenericEvent.FindAllWithIncludes();
        }

        //[HttpPost("moretokenz")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<GenericEventDto> PostEvent([FromBody] GenericEvent genericEvent)
        //{
        //    var token = await HttpContext.GetTokenAsync("access_token");
        //    var handler = new JwtSecurityTokenHandler();
        //    var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

        //    var subject = tokenDecode.Subject;

        //    var noster = _unitofWork.Noster.GetForToken(subject);

        //    genericEvent.NosterId = noster.Id;
        //    genericEvent.CreationDate = DateTime.Now;
        //    genericEvent.DateOccurs = "December 2020";
        //    await _unitofWork.GenericEvent.Create(genericEvent);

        //    //GetGenericPrediction

        //    var config = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<GenericEvent, GenericEventDto>();
        //    });
        //    IMapper iMapper = config.CreateMapper();

        //    GenericEventDto dto = new GenericEventDto();
        //    var genericEventDto = iMapper.Map(genericEvent, dto);

        //    return  genericEventDto;
        //}

        [HttpPost("lesstokenz")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<GenericEventDto> PostThisEvent([FromBody] GenericEvent genericEvent)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;

            var noster = _unitofWork.Noster.GetForToken(subject);
            genericEvent.NosterId = noster.Id;


            return await _unitofWork.GenericEvent.Create(genericEvent);
        }

        [HttpGet("Allprez")]
        public async Task<IEnumerable<PresidentialPrediction>> GetPresidentialPredictions()
        {
            return await _unitofWork.PresidentialPrediction.FindAllWithIncludes();
        }
    }
}
