using AutoMapper;
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
    public class NosterRepository : RepositoryBase<Noster>, INosterRepository
    {
        public NosterRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {
        }

        public async Task<IEnumerable<NosterDto>> FindAllWithIncludes()
        {
            var Noster = await this._nostradamusContext.Set<Noster>().AsNoTracking()
            .Include(n => n.NosterScore)
            .Include(n => n.GenericEvents)
            .Include(n => n.GenericPredictions)
            .ToListAsync();

            GenericEventDto[] GenericEventDtos = new GenericEventDto[50];
            NosterScoreDto nosterScoreDto = new NosterScoreDto();
            GenericPredictionDto[] genericPredictionDtos = new GenericPredictionDto[50];

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GenericEvent, GenericEventDto>();
                cfg.CreateMap<NosterScore, NosterScoreDto>();
                cfg.CreateMap<GenericPrediction, GenericPredictionDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var NosterDtoList = Noster.Select(n => new NosterDto
            {
                Id = n.Id,
                UserName = n.UserName,
                Email = n.Email,
                PhoneNumber = n.PhoneNumber,
                PhoneNumberConfirmed = n.PhoneNumberConfirmed,
                TwoFactorEnabled = n.TwoFactorEnabled,
                CreationDate = n.CreationDate,
                NosterScoreDto = iMapper.Map(n.NosterScore, nosterScoreDto),
                GenericEventDtos = iMapper.Map(n.GenericEvents, GenericEventDtos),
                GenericPredictionDtos = iMapper.Map(n.GenericPredictions, genericPredictionDtos)
            });

            return NosterDtoList;
        }


        public Noster GetForToken(string userName)
        {
            var noster = _nostradamusContext.Noster.Single(n => n.UserName == userName);

            return noster;
        }
    }
}
