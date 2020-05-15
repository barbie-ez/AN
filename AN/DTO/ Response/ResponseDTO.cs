using System;
using Microsoft.AspNetCore.Http;

namespace AN.DTO.Response
{
    public class ResponseDTO<T>
    {
        public int Code { get; set; }
        public string responseMessage { get; set; }
        public T returnObject { get; set; }
    }
}
