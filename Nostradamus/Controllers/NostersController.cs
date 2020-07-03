using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostradamus.DTOs;
using Nostradamus.Repository.Interfaces;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NostersController : ControllerBase
    {
        private IUnitofWork _unitofWork;

        public NostersController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("search")]
        public async Task<IEnumerable<NosterDto>> GetSearched([FromBody] SearchDto search)
        {
            NosterDto[] nosterDtos = new NosterDto[100];

            

            return await _unitofWork.Noster.FindFromSearch(search.Search);
        }
    }

    public class SearchDto
    {
        public string Search { get; set; }
    }
}
