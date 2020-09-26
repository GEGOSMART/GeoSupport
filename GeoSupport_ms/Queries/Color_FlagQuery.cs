using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Queries
{
    public class Color_FlagQuery:IQuery
    {
        private readonly AppDbContext _context;

        public Color_FlagQuery(AppDbContext context)
        {
            _context = context;
        }
        public List<IModel> getAll()
        {
            throw new NotImplementedException();
        }

        public IModel getByPk(int pk)
        {
            throw new NotImplementedException();
        }
        public List<Color_Flag> FindWhereIdFlag(int idFlag)
        {
            List<Color_Flag> color_flags = _context.Color_Flag
                .Where(s => s.Id_flag == idFlag)
                .ToList();
            return color_flags;
        }

    }
}
