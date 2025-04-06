using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.QueryFilters;
using Plataforma.Infrastructure.Filtros;

namespace Plataforma.Infrastructure.Interfaces
{
    public interface IUriService
    {
        public Uri GetPaginationUri<T>(T queryFilter, string actionUrl) where T : QueryFiltersBase;
        
    }
}
