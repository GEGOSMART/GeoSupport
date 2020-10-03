using GeoSupport_ms.Contexts;
using GeoSupport_ms.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Queries
{
    public class PlaceQuery : IQuery
    {
        private readonly AppDbContext _context;
     
        public PlaceQuery(AppDbContext context)
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
        public List<Place> FindWhereIdCountry(int idCountry) {
            List<Place> places = _context.Place
                .Where(s => s.CountryId_country == idCountry).ToList();
            return places;
        }
    }
}
