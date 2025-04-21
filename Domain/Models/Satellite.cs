using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Satellite
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        public string OrbitType { get; set; }
        public bool Decommissioned { get; set; }

        public ICollection<Astronaut> Astronauts { get; set; } = new List<Astronaut>();
    }

}
