using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Country
    {
        [Key]
        public int Id_country { get; set; }
        [ForeignKey("Continent")]
        public int ContinentId_continent { get; set; }
        [ForeignKey("Flag")]
        public int FlagId_flag { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Capital { get; set; }
        [Required]
        [MaxLength(2000)]
        public string MapImage { get; set; }
        public Flag Flag { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();


    }
}
