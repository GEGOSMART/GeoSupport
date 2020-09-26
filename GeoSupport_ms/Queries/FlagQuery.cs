using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Queries
{
    public class FlagQuery : IQuery
    {
        private readonly AppDbContext _context;

        public FlagQuery(AppDbContext context)
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
        public Flag FindWhereIdFlag(int idFlag)
        {
            Flag flag = _context.Flag
                .Where(s => s.Id_flag == idFlag).SingleOrDefault();
            return flag;

        }
    }
}
