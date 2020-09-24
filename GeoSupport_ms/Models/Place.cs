using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Place
    {
        [Key]
        public int Id_place { get; set; }
        [ForeignKey("Country")]
        public int Id_country { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlaceImage { get; set; }

    }
}
