using GeoSupport_ms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Responses
{
    public class ColorOrder
    {
        public ColorOrder(Color color, int theOrder)
        {
            this.Id_color = color.Id_color;
            this.Name = color.Name;
            this.HexCode = color.HexCode;
            this.Order = theOrder;
        }
        public int Id_color { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public int Order { get; set; }
    }
}
