using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.CustomEntities
{
    public class Metadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious{ get; set; }

        public string NextPageUrl { get; set; }
        public string PreviousPageUrl { get; set; }

    }
}
