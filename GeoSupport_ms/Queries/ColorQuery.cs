using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using GeoSupport_ms.Responses;
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
        public List<ColorOrder> FindWhereId_flag(int idFlag)
        {
            Color_FlagQuery color_FlagQuery = new Color_FlagQuery(_context);
            List<Color_Flag> color_flags = color_FlagQuery.FindWhereIdFlag(idFlag);
            if (color_flags == null) {
                return null;
            }
            List<ColorOrder> colors = new List<ColorOrder>();
            ColorOrder colorWhitOrder;
            foreach (Color_Flag color_flag in color_flags)
            {
                colorWhitOrder = new ColorOrder((Color)this.getByPk(color_flag.Id_color),color_flag.order);
                colors.Add(colorWhitOrder);
            }
            return colors;
        }

    }
}
