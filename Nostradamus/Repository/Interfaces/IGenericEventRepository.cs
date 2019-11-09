using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface IGenericEventRepository : IRepositoryBase<GenericEvent>
    {
        IQueryable<GenericEvent> FindAllWithIncludes();
    }
}
