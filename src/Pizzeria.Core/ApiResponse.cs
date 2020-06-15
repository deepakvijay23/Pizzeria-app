using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            this.RequestId = $"Api-{Guid.NewGuid().ToString()}";
        }

        public ApiResponse(string requestId)
        {
            this.RequestId = requestId;
        }

        public string RequestId { get; private set; }
        public ApiResult<T> Result { get; set; }
    }

    public class ApiResult<T>
    {
        public T Data { get; set; }

        public ErrorInfo ErrorInfo { get; set; }
    }

    public class ErrorInfo
    {
        public ErrorInfo(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
