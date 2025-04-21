using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class AstronautResponse
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public int ExperienceYears { get; set; }

        public List<SatelliteResponse> Satellites { get; set; }
    }

}
