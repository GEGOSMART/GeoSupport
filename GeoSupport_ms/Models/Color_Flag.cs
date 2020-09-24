using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Color_Flag
    {
        [ForeignKey("Flag")]
        public int Id_flag { get; set; }
        [ForeignKey("Color")]
        public int Id_color { get; set; }
        [Required]
        public int order { get; set; }
        public Color Color { get; set; }
        public Flag Flag{ get; set; }


    }
}
