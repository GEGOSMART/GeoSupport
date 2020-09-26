using GeoSupport_ms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Queries
{
    public interface IQuery
    {
        public List<IModel> getAll();
        public IModel getByPk();
    }
}
