/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.QueryFilters;
using Plataforma.Infrastructure.Filtros;
using Plataforma.Infrastructure.Interfaces;

namespace Plataforma.Infrastructure.Servicios
{
    public class UriService : IUriService

    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetDocentePaginationUri(DocenteQF docenteqf, DocenteCatedraQF docentecatedraqf, string actionUrl)
        {
            string baseUri = $"{_baseUri}{actionUrl}";
            return new Uri(baseUri);
        }

}
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plataforma.Core.QueryFilters;
using Plataforma.Infrastructure.Filtros;
using Plataforma.Infrastructure.Interfaces;

namespace Plataforma.Infrastructure.Servicios
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPaginationUri<T>(T queryFilter, string actionUrl) where T : QueryFiltersBase
        {
            var queryString = GetQueryString(queryFilter);
            string baseUri = $"{_baseUri}{actionUrl}?{queryString}";
            return new Uri(baseUri);
        }

        private string GetQueryString<T>(T obj)
        {
            var properties = from p in typeof(T).GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + Uri.EscapeDataString(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}

