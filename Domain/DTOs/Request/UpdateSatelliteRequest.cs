using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public class UpdateSatelliteRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[PastDate] // ✅ optional: custom validation attribute if you want strict past-date validation
        public DateTime LaunchDate { get; set; }

        [Required]
        [RegularExpression("^(LEO|MEO|GEO)$", ErrorMessage = "Orbit type must be LEO, MEO, or GEO.")]
        public string OrbitType { get; set; }
    }

}
