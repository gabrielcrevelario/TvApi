using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvApi.Context;
using TvApi.Models;

namespace TvApi.Domain.Interfaces
{
    public interface IAudienceRepository
    {

        void Delete(long audienceId);
        void DeleteTree(List<Audience> audiences);
        void Update(Audience audience);
        void Create(Audience audiences);
        Audience GetById(long audienceId);
        List<Audience> List();
    }
}
