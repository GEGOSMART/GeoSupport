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
        [ForeignKey("Country")]
        public int Id_country { get; set; }
        public string FlagImage { get; set; }
      
    }
}
