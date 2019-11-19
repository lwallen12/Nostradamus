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
        /// But I still want to have a base class implementation.
        /// Perhaps this should be defined at the Base level, but I feel each class would have its own implementation
        /// </summary>
        /// <param name="genericPrediction"></param>
        /// <returns></returns>
        public async Task MarkDelete(GenericPrediction genericPrediction)
        {
            genericPrediction.Active = false;
            genericPrediction.SnapEndDate = DateTime.Now;

            _nostradamusContext.Set<GenericPrediction>().Update(genericPrediction);
            await _nostradamusContext.SaveChangesAsync();

        }

        public async Task MarkUpdate(GenericPrediction genericPrediction)
        {
            await this.MarkDelete(genericPrediction);

            var copyGenericPrediction = genericPrediction;

            await this.Create(copyGenericPrediction);
        }
    }
}
