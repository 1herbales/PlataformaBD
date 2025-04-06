using System.Data;
using Plataforma.Core.CustomEntities;

namespace BD.Response
{
    public class ApiResponse<T>
    {

        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Metadata Meta { get; set; }

    }
}
