using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Flag: IModel
    {
        [Key]
        public int Id_flag { get; set; }
        [Required]
        [MaxLength(2000)]
        public string FlagImage { get; set; }
        [NotMapped]
        public List<Color> colors { get; set; } = new List<Color>();

    }
}
