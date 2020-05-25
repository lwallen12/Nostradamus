using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus;
using Nostradamus.DTOs;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresidentialPredictionsController : ControllerBase
    {
        private IUnitofWork _unitofWork;

        public PresidentialPredictionsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        // GET: api/PresidentialPredictions
        [HttpGet]
        public async Task<IEnumerable<PresidentialPredictionFormDto>> GetPresidentialPredictions()
        {
            return await _unitofWork.PresidentialPrediction.FindAllWithIncludes();
        }

        // GET: api/PresidentialPredictions/5
        [HttpGet("{id}")]
        public async Task<PresidentialPredictionFormDto> GetById(int id)
        {
            return await _unitofWork.PresidentialPrediction.FindByIdWithIncludes(id);
        } 

        [HttpGet("active")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<PresidentialPrediction> FindMostActive()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;

            return await this._unitofWork.PresidentialPrediction.FindActivePrediction(subject);

        }


        // POST: api/PresidentialPredictions
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostPresidentialPrediction([FromBody] PresidentialPrediction presidentialPrediction)
        {

            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var tokenDecode = handler.ReadToken(token) as JwtSecurityToken;

            var subject = tokenDecode.Subject;
            var noster = _unitofWork.Noster.GetForToken(subject);

            presidentialPrediction.NosterId = noster.Id;
            presidentialPrediction.CreatedBy = noster.UserName;

            var currentActivePred = await _unitofWork.PresidentialPrediction.FindActivePrediction(presidentialPrediction.CreatedBy);

            if (currentActivePred == null)
            {
                await _unitofWork.PresidentialPrediction.Create(presidentialPrediction);
            }

            else
            {
                await _unitofWork.PresidentialPrediction.MarkDelete(currentActivePred);

                await _unitofWork.PresidentialPrediction.Create(presidentialPrediction);
            }

            var presidentialPredictionFormDto = _unitofWork.PresidentialPrediction.MapPresidentialPrediction(presidentialPrediction);

            return Ok(presidentialPredictionFormDto);
        }

        // DELETE: api/PresidentialPredictions/5
        [HttpDelete("{id}")]
        public async Task DeletePresidentialPrediction(int id)
        {
            var presidentialPrediction = await _unitofWork.PresidentialPrediction.FindById(id);

             await _unitofWork.PresidentialPrediction.MarkDelete(presidentialPrediction);
        }

        }
}