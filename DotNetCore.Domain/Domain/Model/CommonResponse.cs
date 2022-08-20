
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eService.Domain.Model
{
    public class CommonResponse
    {
        public CommonResponse()
        {

        }

        public CommonResponse(string msg)
        {
            Message = msg;
        }
        [JsonProperty("data")]
        public object Data { get; set; }

        public string Details { get; set; }
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public int StatusCode { get; set; }
        public bool Successful { get; set; }
        [JsonProperty("errors")]
        public List<ValidationError> Errors { get; set; }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPageCount { get; private set; }

        public static CommonResponse CreateSuccessResponse(string msg, object data = null,int stausCode=200,string messageCode="")
        {
            return new CommonResponse()
            {
                Data = data,
                Message = msg,
                Successful = true,
                StatusCode = stausCode,
                MessageCode = messageCode
            };
        }
        public static CommonResponse CreateErrorResponse(string msg, object data = null, int stausCode = 200, string messageCode = "")
        {
            return new CommonResponse()
            {
                Data = data,
                Message = msg,
                Successful = false,
                StatusCode = stausCode,
                MessageCode = messageCode
            };
        }
       
    }

    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        public string Message { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
