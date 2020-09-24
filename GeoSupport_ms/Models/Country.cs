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
        public int Id_continent { get; set; }
        [ForeignKey("Flag")]
        public int Id_flag { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string MapImage { get; set; }
    }
}
