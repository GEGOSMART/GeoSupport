using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Queries
{
    
    public class ColorQuery:IQuery
    {
        private readonly AppDbContext _context;

        public ColorQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<IModel> getAll()
        {
            throw new NotImplementedException();
        }

        public IModel getByPk()
        {
            throw new NotImplementedException();
        }

    }
}
