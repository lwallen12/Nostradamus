using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus.DTOs;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Controllers
{
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly NostradamusContext _context;

        public TestsController(NostradamusContext nostradamusContext)
        {
            _context = nostradamusContext;
        }

        [HttpGet("getdate")]
        public long GetDate()
        {
           DateTime dt = DateTime.Now.AddDays(Convert.ToDouble(30));

            return dt.Ticks;
        }

        [HttpGet]
        public IEnumerable<Noster> Get()
        {
            return _context.Users.Include(n => n.GenericEvents).ToList();
        }

        [HttpGet("other")]
        public IEnumerable<Object> GetOther()
        {
            return _context.UserRoles.ToList();
        }

        [HttpGet("Dto")]
        public async Task<IEnumerable<NosterDto>> FindAllDto()
        {
            var Noster = await _context.Users
                .Include(n => n.GenericEvents)
                //.Include(n => n.NosterScore)
                .Include(n => n.GenericPredictions)
                .ToListAsync();

            GenericEventDto[] GenericEventDtos = new GenericEventDto[50];
            //NosterScoreDto nosterScoreDto = new NosterScoreDto();
            GenericPredictionDto[] genericPredictionDtos = new GenericPredictionDto[50];

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GenericEvent, GenericEventDto>();
                //cfg.CreateMap<NosterScore, NosterScoreDto>();
                cfg.CreateMap<GenericPrediction, GenericPredictionDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var NosterDtoList = Noster.Select(n => new NosterDto
            {
                UserName = n.UserName,
                Email = n.Email,
                PhoneNumber = n.PhoneNumber,
                PhoneNumberConfirmed = n.PhoneNumberConfirmed,
                TwoFactorEnabled = n.TwoFactorEnabled,
                CreationDate = n.CreationDate,
                //NosterScoreDto = iMapper.Map(n.NosterScore, nosterScoreDto),
                GenericEventDtos = iMapper.Map(n.GenericEvents, GenericEventDtos),
                GenericPredictionDtos = iMapper.Map(n.GenericPredictions, genericPredictionDtos)
            });

            return NosterDtoList;
        }

        [HttpGet("event/{id}")]
        public async Task<ActionResult<GenericEventDto>> GetGenericEvent(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GenericEvent, GenericEventDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var genericEvent = await _context.GenericEvent.FindAsync(id);
            GenericEventDto dto = new GenericEventDto();

            var genericEventDto = iMapper.Map(genericEvent, dto);

            if (genericEvent == null)
            {
                return NotFound();
            }

            return genericEventDto;
        }

        //[HttpPost("event")]
        //public async Task<IActionResult> PostGenericEvent([FromBody] GenericEvent genericEvent)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    genericEvent.CreationDate = DateTime.Now;

        //    _context.GenericEvent.Add(genericEvent);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGenericEvent", new { id = genericEvent.Id }, genericEvent);
        //}

        // GET: api/GenericEvents
        [HttpGet("allevents")]
        public async Task<ActionResult<IEnumerable<GenericEvent>>> GetGenericEvent()
        {
            return await _context.GenericEvent
                .Include(g => g.GenericPredictions)
                .ToListAsync();
        }

        // GET: api/GenericPredictions/5
        [HttpGet("prediction/{id}")]
        public async Task<ActionResult<GenericPrediction>> GetGenericPrediction(int id)
        {
            var genericPrediction = await _context.GenericPrediction.FindAsync(id);

            if (genericPrediction == null)
            {
                return NotFound();
            }

            return genericPrediction;
        }

        [HttpPost("prediction")]
        public async Task<IActionResult> PostGenericPrediction([FromBody] GenericPrediction genericPrediction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GenericPrediction.Add(genericPrediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenericPrediction", new { id = genericPrediction.Id }, genericPrediction);
        }

        
    }
}
