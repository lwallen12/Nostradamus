using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface IPresidentialPredictionRepository : IRepositoryBase<PresidentialPrediction>
    {
        Task<IEnumerable<PresidentialPrediction>> FindAllWithIncludes();
    }
}
