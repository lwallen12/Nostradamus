using Microsoft.AspNetCore.Identity;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private NostradamusContext _nostradamusContext;

        private IGenericEventRepository _genericEventRepository;
        private IGenericPredictionRepository _genericPredictionRepository;
        private INosterRepository _nosterRepository;
        //private INosterScoreRepository _nosterScoreRepository;
        private IPresidentialPredictionRepository _presidentialPredictionRepository;
        private INosterMessageRepository _nosterMessageRepository;
        private INosterRelationRepository _nosterRelationRepository;

        public UnitofWork (NostradamusContext nostradamusContext)
        {
            _nostradamusContext = nostradamusContext;
        }

        public IGenericEventRepository GenericEvent
        {
            get
            {
                if (_genericEventRepository == null)
                {
                    _genericEventRepository = new GenericEventRepository(_nostradamusContext);
                }

                return _genericEventRepository;
            }
        }

        public IGenericPredictionRepository GenericPrediction
        {
            get
            {
                if (_genericPredictionRepository == null)
                {
                    _genericPredictionRepository = new GenericPredictionRepository(_nostradamusContext);
                }

                return _genericPredictionRepository;
            }
        }

        public INosterRepository Noster
        {
            get
            {
                if (_nosterRepository == null)
                {
                    _nosterRepository = new NosterRepository(_nostradamusContext);
                }

                return _nosterRepository;
            }
        }

        public INosterMessageRepository NosterMessage
        {
            get
            {
                if(_nosterMessageRepository == null)
                {
                    _nosterMessageRepository = new NosterMessageRepository(_nostradamusContext);
                }
                return _nosterMessageRepository;
            }
        }

        public INosterRelationRepository NosterRelation
        {
            get
            {
                if(_nosterRelationRepository == null)
                {
                    _nosterRelationRepository = new NosterRelationRepository(_nostradamusContext);
                }
                return _nosterRelationRepository;
            }
        }

        //public INosterScoreRepository NosterScore
        //{
        //    get
        //    {
        //        if (_nosterScoreRepository == null)
        //        {
        //            _nosterScoreRepository = new NosterScoreRepository(_nostradamusContext);
        //        }

        //        return _nosterScoreRepository;
        //    }
        //}

        public IPresidentialPredictionRepository PresidentialPrediction
        {
            get
            {
                if (_presidentialPredictionRepository == null)
                {
                    _presidentialPredictionRepository = new PresidentialPredictionRepository(_nostradamusContext);
                }

                return _presidentialPredictionRepository;
            }
        }

        public async Task Save()
        {
            await _nostradamusContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _nostradamusContext.Dispose();
        }
    }
}
