using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hris.Shared
{
    public class ResponseResult<T>
    {
        public ResponseResult(T data)
        {
            Data = data;
            Code = ResultCode.Success;
        }

        public ResponseResult(string message)
        {
            Message = message;
            Code = ResultCode.Error;
        }

        public ResponseResult(T data, ResultCode code, string message)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        public ResultCode Code { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
