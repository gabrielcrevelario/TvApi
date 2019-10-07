using System.Collections.Generic;
using System.Linq;
using TvApi.Context;
using TvApi.Domain.Interfaces;
using TvApi.Models;

namespace TvApi.Repositories
{
    public class TvChannelRepository : ITvChannelRepository
    {
        private TvContext TvContext { get; }

        public TvChannelRepository(TvContext tvContext)
        {
            TvContext = tvContext;
        }

        public void Delete(long tvId)
        {
            TvChannel tvchannel = TvContext.TvChannels.Where(x => x.Id == tvId).SingleOrDefault();
            TvContext.TvChannels.Remove(tvchannel);
            TvContext.SaveChanges();
        }
        public void Update(TvChannel tvChannel)
        {
            TvContext.TvChannels.Update(tvChannel);
            TvContext.SaveChanges();
        }
        public void Create(TvChannel tvChannel)
        {
            TvContext.TvChannels.Add(tvChannel);
            TvContext.SaveChanges();
        }
        public TvChannel GetByIdWithAudience(long tvChannelId)
        {
            return (from tv in TvContext.TvChannels
             join audience in TvContext.Audiences on tv.Id
             equals audience.TvChannelId
             where tv.Id == tvChannelId
             select new TvChannel
             {
                 Id = tv.Id,
                 Name = tv.Name,
                 Audiences = TvContext.Audiences.Where(x => x.TvChannelId == tvChannelId).ToList()
             }).FirstOrDefault();
        }
        public TvChannel GetById(long tvChannelId)
        {
            return TvContext.TvChannels.Where(x => x.Id == tvChannelId).SingleOrDefault();
        }
        public TvChannel GetByName(string Name)
        {
            return TvContext.TvChannels.Where(x => x.Name == Name).SingleOrDefault();
        }

        public List<TvChannel> List()
        {
            List<TvChannel> listChannels = TvContext.TvChannels.ToList();
            TvContext.TvChannels.ToList().ForEach(element =>
            {
                element.Audiences = TvContext.Audiences.Where(x => x.TvChannelId == element.Id).ToList();
            });
            //return (from tv in TvContext.TvChannels
            //        join audience in TvContext.Audiences on tv.Id
            //        equals audience.TvChannelId
            //        select new TvChannel
            //        {
            //            Id = tv.Id,
            //            Name = tv.Name,
            //            Audiences = TvContext.Audiences.Where(x => x.TvChannelId == tv.Id).ToList()
            //        }).ToList();
            return listChannels;
        }
    }
}
