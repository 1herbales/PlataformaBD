using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Core.CustomEntities
{
    public class PaginationOptions
    {
       public  int DefaultPageNumber { get; set; } = 1;
       public  int DefaultPageSize { get; set; } = 10;
    }
}
