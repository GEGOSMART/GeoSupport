using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Color
    {
        [Key]
        public int Id_color { get; set; }
        public double Name { get; set; }
        public string HexCode { get; set; }
        public List<Color_Flag> Color_Flags { get; set; } = new List<Color_Flag>();
 
    }
}
