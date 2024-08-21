using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Constants;

namespace Shared.Response
{
    public class Response<TData>(TData? data, 
        string? message = null, 
        int code = Configuration.DefaultStatusCode)
    {
        public TData? Data { get; set; } = data;
        public int StatusCode => code;
        public string? Message { get; set; } = message;
        public bool IsSuccess => code is >= 200 and <= 299;
    }
 
}