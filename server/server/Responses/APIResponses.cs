using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Responses
{
    public class APIResponses
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set;}

        public APIResponses()
        {

        }

        public APIResponses(int code, string message, object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
    }
}
