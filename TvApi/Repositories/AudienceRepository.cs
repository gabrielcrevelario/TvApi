using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvApi.Context;
using TvApi.Domain.Interfaces;
using TvApi.Models;

namespace TvApi.Repositories
{
    public class AudienceRepository : IAudienceRepository
    {
       private  TvContext TvContext { get; }


        public AudienceRepository(TvContext tvContext)
        {
            TvContext = tvContext;
        }

        public void Delete(long audienceId)
        {
            Audience audience = TvContext.Audiences.Where(x => x.Id == audienceId).SingleOrDefault();
            TvContext.Audiences.Remove(audience);
            TvContext.SaveChanges();
        }
        public void DeleteTree(List<Audience> audiences)
        {
            TvContext.Audiences.RemoveRange(audiences);
            TvContext.SaveChanges();
        }
        public void Update(Audience audience)
        {
            TvContext.Audiences.Update(audience);
            TvContext.SaveChanges();
        }
        public void Create(Audience audiences)
        {
            TvContext.Audiences.Add(audiences);
            TvContext.SaveChanges();
        }
        public Audience GetById(long audienceId)
        {
            return TvContext.Audiences.Where(x => x.Id == audienceId).SingleOrDefault();
        }
        public List<Audience> List()
        {
            return TvContext.Audiences.ToList();
        }
    }
}
