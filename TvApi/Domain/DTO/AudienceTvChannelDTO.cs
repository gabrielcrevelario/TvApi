using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvApi.Models;

namespace TvApi.Domain.DTO
{
    public class AudienceTvChannelDTO
    {
        public string NameChannel { get; set; }
        public double AudiencePoints { get; set; }
        public DateTime DateAndTimeAudience { get; set; }
        public double AudienceAverage { get; set; }
    }
}
