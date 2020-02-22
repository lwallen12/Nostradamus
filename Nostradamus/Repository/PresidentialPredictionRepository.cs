using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<PresidentialPrediction>> FindAllWithIncludes()
        {
            return await this._nostradamusContext.Set<PresidentialPrediction>().AsNoTracking()
                .Include(pp => pp.Noster).ToListAsync();
        }
    }
}
