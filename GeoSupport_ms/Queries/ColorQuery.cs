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

        public IModel getByPk(int pk)
        {
            return (Color)_context.Color
                .Where(s => s.Id_color == pk).SingleOrDefault();
        }
        public List<Color> FindWhereId_flag(int idFlag)
        {
            Color_FlagQuery color_FlagQuery = new Color_FlagQuery(_context);
            List<Color_Flag> color_flags = color_FlagQuery.FindWhereIdFlag(idFlag);
            if (color_flags == null) {
                return null;
            }
            List<Color> colors = new List<Color>();
            foreach (Color_Flag color_flag in color_flags)
            {
                colors.Add((Color)this.getByPk(color_flag.Id_color));
            }
            return colors;
        }

    }
}
