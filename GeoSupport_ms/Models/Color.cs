using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Color:IModel
    {
        [Key]
        public int Id_color { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string HexCode { get; set; }
        [NotMapped]
        public List<Flag> flags { get; set; } = new List<Flag>();
 
    }
}
