using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class NosterScoreRepository : RepositoryBase<NosterScore>, INosterScoreRepository
    {
        public NosterScoreRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {
        }
    }
}
