using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvApi.Domain.DTO;
using TvApi.Models;

namespace TvApi.Domain.Interfaces
{
    public interface IAudienceTvChannelService
    {
         void CreateAudience(long tvId, Audience audience);
         void CreateTvChannel(TvChannel tvChannel);
         List<AudienceTvChannelDTO> ListAudiencesTvChannelWithAvarageHour(string desiredDate);
         TvChannel GetTvChannelByName(string name);
         TvChannel GetTvChannelById(long tvId);
         Audience GetAudienceById(long tvId);
         void RemoveAudience(long audienceId);
         void RemoveTvChannel(long tvId);
         void UpdateAudience(long audienceId, Audience audience);
         void UpdateTvChannel(long tvId, TvChannel tvChannel);
         List<Audience> ListAudience();
         List<TvChannel> ListTvChannel();
       
    }
}
