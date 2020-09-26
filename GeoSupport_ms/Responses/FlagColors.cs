using GeoSupport_ms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Responses
{
    public class FlagColors
    {
        public FlagColors(Flag flag, List<ColorOrder> colors)
        {
            this.Id_flag = flag.Id_flag;
            this.FlagImage = flag.FlagImage;
            this.Colors = colors;
        }
        public int Id_flag { get; set; }
        public string FlagImage { get; set; }
        public List<ColorOrder> Colors { get; set; }
    }
}
