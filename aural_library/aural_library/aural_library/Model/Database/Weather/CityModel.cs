using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace aural_library.Model.Database.Weather
{
    public class CityModel
    {
        [Key]
        [Required]
        [ConcurrencyCheck]
        public int CityId { get; set; }
        [Required]
        [MaxLength(50)]
        [ConcurrencyCheck]
        public string CityName { get; set; }
        [Required]
        [ConcurrencyCheck]
        public double Latitude { get; set; }
        [Required]
        [ConcurrencyCheck]
        public double Longitude { get; set; }
        [Required]
        [MaxLength(50)]
        [ConcurrencyCheck]
        public string Country { get; set; }
        [Required]
        [ConcurrencyCheck]
        public long Population { get; set; }
        [Required]
        [ConcurrencyCheck]
        public long Timezone { get; set; }
    }
}
