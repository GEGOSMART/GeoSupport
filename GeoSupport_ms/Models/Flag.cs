using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Flag
    {
        [Key]
        public int Id_flag { get; set; }
        public string FlagImage { get; set; }
        public List<Color_Flag> Color_Flags { get; set; } = new List<Color_Flag>();

    }
}
