using AutoMapper;
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
    public class GenericEventRepository : RepositoryBase<GenericEvent>, IGenericEventRepository
    {
        public GenericEventRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {
        }

        ////public async Task<<IEnumerable>GenericEvent> FindAllWithIncludes()
        ////{
        ////    return await this._nostradamusContext.Set<GenericEvent>().AsNoTracking()
        ////        .Include(ge => ge.Noster)
        ////        .Include(ge => ge.GenericPredictions).ToListAsync();
        ////}

        public async Task<IEnumerable<GenericEventDto>> FindAllWithIncludes()
        {
            var genericEvent = await this._nostradamusContext.Set<GenericEvent>().AsNoTracking()
                .Include(ge => ge.Noster)
                .Include(ge => ge.GenericPredictions).ToListAsync();

            NosterDto nosterDto = new NosterDto();
            GenericPredictionDto[] genericPredictionDtos = new GenericPredictionDto[50];

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Noster, NosterDto>();
                cfg.CreateMap<GenericPrediction, GenericPredictionDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var GenericEventDtoList = genericEvent.Select(ge => new GenericEventDto
            {
                Id = ge.Id,
                CreatedBy = ge.CreatedBy,
                Title = ge.Title,
                Description = ge.Description,
                DateOccurs = ge.DateOccurs,
                Valid = ge.Valid,
                Active = ge.Active,
                Occurred = ge.Occurred,
                CreationDate = ge.CreationDate,

                NosterDto = iMapper.Map(ge.Noster, nosterDto),
                GenericPredictionDtos = iMapper.Map(ge.GenericPredictions, genericPredictionDtos)
            });

            return GenericEventDtoList;

        }

        public new async Task<GenericEventDto> Create(GenericEvent genericEvent)
        {
            
            genericEvent.CreationDate = DateTime.Now;
            _nostradamusContext.Set<GenericEvent>().Add(genericEvent);
            await _nostradamusContext.SaveChangesAsync();

            //GetGenericPrediction

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GenericEvent, GenericEventDto>();
            });
            IMapper iMapper = config.CreateMapper();

            GenericEventDto dto = new GenericEventDto();
            var genericEventDto = iMapper.Map(genericEvent, dto);

            return  genericEventDto;
        }

        
    }
}
