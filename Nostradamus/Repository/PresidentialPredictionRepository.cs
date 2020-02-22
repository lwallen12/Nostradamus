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
    public class PresidentialPredictionRepository : RepositoryBase<PresidentialPrediction>, IPresidentialPredictionRepository
    {
        public PresidentialPredictionRepository(NostradamusContext nostradamusContext)
            :base(nostradamusContext)
        {

        }

        public new async Task Create(PresidentialPrediction presidentialPrediction)
        {
            string strDefaultEndDate = "2099-12-31 00:00:00";

            presidentialPrediction.Scored = false;
            presidentialPrediction.Active = true;
            presidentialPrediction.Valid = true;

            presidentialPrediction.SnapEndDate = Convert.ToDateTime(strDefaultEndDate);
            presidentialPrediction.SnapStartDate = DateTime.Now;

            _nostradamusContext.Set<PresidentialPrediction>().Add(presidentialPrediction);
            await _nostradamusContext.SaveChangesAsync();

        }

        public async Task MarkDelete(PresidentialPrediction presidentialPrediction)
        {
            presidentialPrediction.Active = false;
            presidentialPrediction.SnapEndDate = DateTime.Now;

            _nostradamusContext.Set<PresidentialPrediction>().Update(presidentialPrediction);
            await _nostradamusContext.SaveChangesAsync();
        }

        public async Task MarkUpdate(PresidentialPrediction presidentialPrediction)
        {
            //Need to get current active prediction
            var currentActivePred = await FindActivePrediction(presidentialPrediction.CreatedBy);
            
            await this.MarkDelete(currentActivePred);

            await this.Create(presidentialPrediction);
        }

        public async Task<PresidentialPrediction> FindActivePrediction(string currentNoster)
        {
            var currentActive = this._nostradamusContext.PresidentialPrediction
                .Where(pp => pp.Active == true)
                .Where(pp => pp.CreatedBy == currentNoster).FirstOrDefaultAsync();

            return await currentActive;
        }

        public async Task<PresidentialPredictionFormDto> FindByIdWithIncludes(int id)
        {
            var presPrediction = await this._nostradamusContext.Set<PresidentialPrediction>().AsNoTracking()
                .Include(pp => pp.Noster)
                .FirstOrDefaultAsync(x => x.Id == id);

            NosterDto nosterDto = new NosterDto();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Noster, NosterDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var presidentialPredictionFormDto = MapPresidentialPrediction(presPrediction);

            return presidentialPredictionFormDto;
        }

        public async Task<IEnumerable<PresidentialPredictionFormDto>> FindAllWithIncludes()
        {
            var presPredictions =  await this._nostradamusContext.Set<PresidentialPrediction>().AsNoTracking()
                .Include(pp => pp.Noster).ToListAsync();

            NosterDto nosterDto = new NosterDto();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Noster, NosterDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var presidentialPredictionFormDtoList = presPredictions.Select(pp => new PresidentialPredictionFormDto
            {
                Id = pp.Id,
                CreatedBy = pp.CreatedBy,
                Candidate1 = pp.Candidate1,
                Candidate1Party = pp.Candidate1Party,
                Candidate1VP = pp.Candidate1VP,
                Candidate1FaithlessElectors = pp.Candidate1FaithlessElectors,
                Candidate2 = pp.Candidate2,
                Candidate2Party = pp.Candidate2Party,
                Candidate2VP = pp.Candidate2VP,
                Candidate2FaithlessElectors = pp.Candidate2FaithlessElectors,
                PopularVoteWinner = pp.PopularVoteWinner,
                ElectoralVoteWinner = pp.ElectoralVoteWinner,
                ElectionWinner = pp.ElectionWinner,
                Description = pp.Description,
                Why = pp.Why,
                SnapStartDate = pp.SnapStartDate,
                SnapEndDate = pp.SnapEndDate,
                Scored = pp.Scored,
                Active = pp.Active,
                Valid = pp.Valid,
                ALVote = pp.ALVote,
                AKVote = pp.AKVote,
                AZVote = pp.AZVote,
                ARVote = pp.ARVote,
                CAVote = pp.CAVote,
                COVote = pp.COVote,
                CTVote = pp.CTVote,
                DEVote = pp.DEVote,
                FLVote = pp.FLVote,
                GAVote = pp.GAVote,
                HIVote = pp.HIVote,
                IDVote = pp.IDVote,
                ILVote = pp.ILVote,
                INVote = pp.INVote,
                IAVote = pp.IAVote,
                KSVote = pp.KSVote,
                KYVote = pp.KYVote,
                LAVote = pp.LAVote,
                MEVote = pp.MEVote,
                MDVote = pp.MDVote,
                MAVote = pp.MAVote,
                MIVote = pp.MIVote,
                MNVote = pp.MNVote,
                MSVote = pp.MSVote,
                MOVote = pp.MOVote,
                MTVote = pp.MTVote,
                NEVote = pp.NEVote,
                NVVote = pp.NVVote,
                NHVote = pp.NHVote,
                NJVote = pp.NJVote,
                NMVote = pp.NMVote,
                NYVote = pp.NYVote,
                NCVote = pp.NCVote,
                NDVote = pp.NDVote,
                OHVote = pp.OHVote,
                OKVote = pp.OKVote,
                ORVote = pp.ORVote,
                PAVote = pp.PAVote,
                RIVote = pp.RIVote,
                SCVote = pp.SCVote,
                SDVote = pp.SDVote,
                TNVote = pp.TNVote,
                TXVote = pp.TXVote,
                UTVote = pp.UTVote,
                VTVote = pp.VTVote,
                VAVote = pp.VAVote,
                WAVote = pp.WAVote,
                WVVote = pp.WVVote,
                WIVote = pp.WIVote,
                WYVote = pp.WYVote,

                NosterDto = iMapper.Map(pp.Noster, nosterDto)
            });

            return presidentialPredictionFormDtoList;
        }


        public PresidentialPredictionFormDto MapPresidentialPrediction(PresidentialPrediction presPrediction)
        {
            NosterDto nosterDto = new NosterDto();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Noster, NosterDto>();
            });
            IMapper iMapper = config.CreateMapper();

            var presidentialPredictionFormDto = new PresidentialPredictionFormDto
            {
                Id = presPrediction.Id,
                CreatedBy = presPrediction.CreatedBy,
                Candidate1 = presPrediction.Candidate1,
                Candidate1Party = presPrediction.Candidate1Party,
                Candidate1VP = presPrediction.Candidate1VP,
                Candidate1FaithlessElectors = presPrediction.Candidate1FaithlessElectors,
                Candidate2 = presPrediction.Candidate2,
                Candidate2Party = presPrediction.Candidate2Party,
                Candidate2VP = presPrediction.Candidate2VP,
                Candidate2FaithlessElectors = presPrediction.Candidate2FaithlessElectors,
                PopularVoteWinner = presPrediction.PopularVoteWinner,
                ElectoralVoteWinner = presPrediction.ElectoralVoteWinner,
                ElectionWinner = presPrediction.ElectionWinner,
                Description = presPrediction.Description,
                Why = presPrediction.Why,
                SnapStartDate = presPrediction.SnapStartDate,
                SnapEndDate = presPrediction.SnapEndDate,
                Scored = presPrediction.Scored,
                Active = presPrediction.Active,
                Valid = presPrediction.Valid,
                ALVote = presPrediction.ALVote,
                AKVote = presPrediction.AKVote,
                AZVote = presPrediction.AZVote,
                ARVote = presPrediction.ARVote,
                CAVote = presPrediction.CAVote,
                COVote = presPrediction.COVote,
                CTVote = presPrediction.CTVote,
                DEVote = presPrediction.DEVote,
                FLVote = presPrediction.FLVote,
                GAVote = presPrediction.GAVote,
                HIVote = presPrediction.HIVote,
                IDVote = presPrediction.IDVote,
                ILVote = presPrediction.ILVote,
                INVote = presPrediction.INVote,
                IAVote = presPrediction.IAVote,
                KSVote = presPrediction.KSVote,
                KYVote = presPrediction.KYVote,
                LAVote = presPrediction.LAVote,
                MEVote = presPrediction.MEVote,
                MDVote = presPrediction.MDVote,
                MAVote = presPrediction.MAVote,
                MIVote = presPrediction.MIVote,
                MNVote = presPrediction.MNVote,
                MSVote = presPrediction.MSVote,
                MOVote = presPrediction.MOVote,
                MTVote = presPrediction.MTVote,
                NEVote = presPrediction.NEVote,
                NVVote = presPrediction.NVVote,
                NHVote = presPrediction.NHVote,
                NJVote = presPrediction.NJVote,
                NMVote = presPrediction.NMVote,
                NYVote = presPrediction.NYVote,
                NCVote = presPrediction.NCVote,
                NDVote = presPrediction.NDVote,
                OHVote = presPrediction.OHVote,
                OKVote = presPrediction.OKVote,
                ORVote = presPrediction.ORVote,
                PAVote = presPrediction.PAVote,
                RIVote = presPrediction.RIVote,
                SCVote = presPrediction.SCVote,
                SDVote = presPrediction.SDVote,
                TNVote = presPrediction.TNVote,
                TXVote = presPrediction.TXVote,
                UTVote = presPrediction.UTVote,
                VTVote = presPrediction.VTVote,
                VAVote = presPrediction.VAVote,
                WAVote = presPrediction.WAVote,
                WVVote = presPrediction.WVVote,
                WIVote = presPrediction.WIVote,
                WYVote = presPrediction.WYVote,

                NosterDto = iMapper.Map(presPrediction.Noster, nosterDto)
            };

            return presidentialPredictionFormDto;

        }
    }
}
