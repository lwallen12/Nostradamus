using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface IGenericPredictionRepository : IRepositoryBase<GenericPrediction>
    {
        new Task Create(GenericPrediction genericPrediction);
        new Task Delete(GenericPrediction genericPrediction);
    }
}
