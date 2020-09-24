using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Country
    {
        [Key]
        public int Id_country { get; set; }
        public String Capital { get; set; }
        public String MapImage { get; set; }
    }
}
