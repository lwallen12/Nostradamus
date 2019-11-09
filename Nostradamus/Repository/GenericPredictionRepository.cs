using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class GenericPredictionRepository : RepositoryBase<GenericPrediction>, IGenericPredictionRepository
    {
        public GenericPredictionRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {
        }

        /// <summary>
        /// Always set the EndDateTime to 2099 no matter what
        /// </summary>
        /// <param name="genericPrediction"></param>
        /// <returns></returns>
        public new async Task Create(GenericPrediction genericPrediction)
        {
            string strDefaultEndDate = "2099-12-31 00:00:00";

            genericPrediction.SnapEndDate = Convert.ToDateTime(strDefaultEndDate);
            genericPrediction.EventOccurred = false;
            genericPrediction.Active = true;
            genericPrediction.Valid = true;

            _nostradamusContext.Set<GenericPrediction>().Add(genericPrediction);
            await _nostradamusContext.SaveChangesAsync();
        }

        /// <summary>
        /// In order to preserve history, this will be set to inactive, not actually deleted. 
        /// So it hides base class implementation
        /// </summary>
        /// <param name="genericPrediction"></param>
        /// <returns></returns>
        public async new Task Delete(GenericPrediction genericPrediction)
        {
            genericPrediction.Active = false;
            genericPrediction.SnapEndDate = DateTime.Now;

            _nostradamusContext.Set<GenericPrediction>().Update(genericPrediction);
            await _nostradamusContext.SaveChangesAsync();

        }
    }
}
