﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Models
{
    public class Continent: IModel
    {
        [Key]
        public int Id_continent { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public List<Country> Countries{ get; set; } = new List<Country>();
    }
}
