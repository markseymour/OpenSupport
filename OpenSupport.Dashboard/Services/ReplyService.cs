using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IRepository<ReplyRecord> _replyRepository;

        public ReplyService(IRepository<ReplyRecord> replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public IEnumerable<ReplyRecord> GetReplies(int parentId)
        {
            return _replyRepository.Where(x => x.ReplyTo == parentId);            
        }
    }
}
