using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvApi.Models;

namespace TvApi.Domain.Interfaces
{
    public interface ITvChannelRepository
    {
        void Delete(long tvId);
        void Update(TvChannel tvChannel);
        void Create(TvChannel tvChannel);
        TvChannel GetByIdWithAudience(long tvChannelId);
        TvChannel GetByName(string Name);
        List<TvChannel> List();
        TvChannel GetById(long tvChannelId);
    }
}
