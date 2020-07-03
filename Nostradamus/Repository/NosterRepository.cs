using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nostradamus.DTOs;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class NosterRepository : RepositoryBase<Noster>, INosterRepository
    {
        public NosterRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {
        }

        //This is really inefficient and I would like to know how to do it better...
        public async Task<IEnumerable<NosterDto>> FindFromSearch(string search)
        {
            var nostersDisplayMatch = await _nostradamusContext.Set<Noster>().AsNoTracking()
                .Where(n => n.DisplayName.Contains(search))
                .ToListAsync(); 

            var nostersEmailMatch = await _nostradamusContext.Set<Noster>().AsNoTracking()
                .Where(n => n.UserName.Contains(search))
                .ToListAsync(); ;

            var nostersMottoMatch = await _nostradamusContext.Set<Noster>().AsNoTracking()
                .Where(n => n.Motto.Contains(search))
                .ToListAsync();

            var combined = nostersDisplayMatch.Concat(nostersEmailMatch.Concat(nostersMottoMatch)).Take(100).ToList();

            var distinct = combined.GroupBy(elem => elem.UserName).Select(group => group.First());

            var NosterDtoList = distinct.Select(n => new NosterDto
            {
                UserName = n.UserName,
                Email = n.Email,
                PhoneNumber = n.PhoneNumber,
                PhoneNumberConfirmed = n.PhoneNumberConfirmed,
                TwoFactorEnabled = n.TwoFactorEnabled,
                CreationDate = n.CreationDate,
                DisplayName = n.DisplayName,
                Motto = n.Motto
                //NosterScoreDto = iMapper.Map(n.NosterScore, nosterScoreDto)
            });
            return NosterDtoList;
        }

        public async Task<IEnumerable<NosterDto>> FindAllWithIncludes()
        {
            var Noster = await this._nostradamusContext.Set<Noster>().AsNoTracking()
            //.Include(n => n.NosterScore)
            .Include(n => n.GenericEvents)
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
                DisplayName = n.DisplayName,
                Motto = n.Motto,
                //NosterScoreDto = iMapper.Map(n.NosterScore, nosterScoreDto),
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
