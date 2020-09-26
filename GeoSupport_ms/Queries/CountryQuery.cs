using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Queries
{
    public class CountryQuery : IQuery
    {
        private readonly AppDbContext _context;

        public CountryQuery(AppDbContext context)
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
        public List<Country> FindWhereIdContinent(int idContinent)
        {
            List<Country> countries = _context.Country
                .Where(s => s.ContinentId_continent == idContinent).ToList();
            return countries;
        }

    }
}
