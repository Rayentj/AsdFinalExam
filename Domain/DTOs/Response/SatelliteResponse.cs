using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class SatelliteResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        public string OrbitType { get; set; }
        public bool Decommissioned { get; set; }
    }

}
