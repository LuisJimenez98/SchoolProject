using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response()
        {
        }

        public Response(T data, string message = null)
        {
            Succeded = true;
            Message = message;
            Data = data;
        }

    }
}
