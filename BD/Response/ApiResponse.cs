using System.Data;

namespace BD.Response
{
    public class ApiResponse<T>
    {

        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

    }
}
