using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        IGenericEventRepository GenericEvent { get; }
        IGenericPredictionRepository GenericPrediction { get; }
        INosterRepository Noster { get; }
        //INosterScoreRepository NosterScore { get; }

        IPresidentialPredictionRepository PresidentialPrediction { get; }
        INosterMessageRepository NosterMessage { get; }
       

        Task Save();
    }
}
