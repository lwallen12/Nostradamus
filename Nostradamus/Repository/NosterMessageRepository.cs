using Microsoft.EntityFrameworkCore;
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

        public async Task<List<NosterMessageDto>> AllRelatedMessages(Noster viewer, Noster friend)
        {

            var myRec = _nostradamusContext.NosterMessage
                .Where(nm => nm.MessageSource == viewer.UserName)
                .Where(nm => nm.NosterTargetUserName == friend.UserName);

            var mySent = _nostradamusContext.NosterMessage
                .Where(nm => nm.NosterTargetUserName == viewer.UserName)
                .Where(nm => nm.MessageSource == friend.UserName);


            var allMessages = myRec.Union(mySent);

            var NosterMessageDtoList = allMessages.Select(am => new NosterMessageDto
            {
                NosterTarget = am.NosterTargetUserName,
                TargetDisplayName = am.TargetDisplayName,
                SourceDisplayName = am.SourceDisplayName,
                Source = am.MessageSource,
                OriginTime = am.OriginTime,
                MessageBody = am.MessageBody,
                IsSeen = am.IsSeen
            }).ToListAsync();

            return await NosterMessageDtoList;
        }

    }
}