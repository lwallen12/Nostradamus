using Nostradamus.DTOs;
using Nostradamus.Models;
using Nostradamus.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostradamus.Repository
{
    public class NosterMessageRepository: RepositoryBase<NosterMessage>, INosterMessageRepository
    {
        public NosterMessageRepository(NostradamusContext nostradamusContext)
            : base(nostradamusContext)
        {

            
        }

        public async Task<List<NosterMessageDto>> AllRelatedMessages(Noster noster)
        {
           //var noster = this._nostradamusContext.Noster.Single(n => n.UserName == nosterName);

            var myInbox = this._nostradamusContext.NosterMessage
                .Where(myRM => myRM.NosterId == noster.Id).ToAsyncEnumerable();

            var mySent = this._nostradamusContext.NosterMessage
                .Where(myS => myS.MessageSource == noster.UserName).ToAsyncEnumerable();

            var allMessages = myInbox.Union(mySent);

            var NosterMessageDtoList = allMessages.Select(am => new NosterMessageDto
            {
                NosterTarget = am.NosterTargetUserName,
                Source = am.MessageSource,
                OriginTime = am.OriginTime,
                MessageBody = am.MessageBody,
                Title = am.MessageTitle
            }).ToList();

            return await NosterMessageDtoList;
        }
    }
}


//Cannot implictly convert type 'system.collections.generic.IAsyncEnumerable<class>' to system.collections.generic.IEnumerable<class>