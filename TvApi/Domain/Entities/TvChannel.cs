using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvApi.Models
{
    public class TvChannel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Audience> Audiences { get; set; }
    }
}
