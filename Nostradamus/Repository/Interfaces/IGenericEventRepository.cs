using Microsoft.AspNetCore.Mvc;
using Nostradamus.DTOs;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository.Interfaces
{
    public interface IGenericEventRepository : IRepositoryBase<GenericEvent>
    {
        Task<IEnumerable<GenericEventDto>> FindAllWithIncludes();

        Task<GenericEventDto> Create(GenericEvent genericEvent);
    }
}
