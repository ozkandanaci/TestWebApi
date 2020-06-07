using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T result)
        {
            this.Result = result;
            this.Success = true;
        }

        public Response(string message)
        {
            this.Message = message;
            this.Success = false;
        }

        public T Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
