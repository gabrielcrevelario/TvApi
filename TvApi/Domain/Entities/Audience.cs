using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvApi.Models
{
    public class Audience
    {
        public long Id { get; set; }
        public double AudiencePoints { get; set; }
        public DateTime DateAndTimeAudience { get; set; }
        public TvChannel TvChannel { get; set; }
        public long TvChannelId { get; set; }
    }
}
