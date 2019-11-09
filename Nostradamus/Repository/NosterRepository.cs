using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Noster>> FindAllWithIncludes()
        {
            return await this._nostradamusContext.Set<Noster>().AsNoTracking()
            .Include(n => n.NosterScore)
            .Include(n => n.GenericEvents)
            .Include(n => n.GenericPredictions)
            .ToListAsync();
        }
    }
}
