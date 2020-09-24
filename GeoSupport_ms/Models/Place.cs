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
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(2000)]
        public string PlaceImage { get; set; }

    }
}
