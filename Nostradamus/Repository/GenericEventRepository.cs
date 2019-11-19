using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class GenericEventRepository : RepositoryBase<GenericEvent>, IGenericEventRepository
    {
        public GenericEventRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {
        }

        public IQueryable<GenericEvent> FindAllWithIncludes()
        {
            return this._nostradamusContext.Set<GenericEvent>().AsNoTracking()
                .Include(ge => ge.Noster)
                .Include(ge => ge.GenericPredictions);
        }

        
    }
}
