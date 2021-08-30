using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagementRepository.Models
{
    public enum StatusCode
    {
        Success = 200,
        Error = 300,
        Exception = 500,
        BadRequest = 400,
        UnauthorizeAccess = 401,
        TokenError = 222,
        AdministratorRequired = 501,
        NotInAccess = 405,
    }
    public class ApiResult<T>
    {
        public bool ResponseStatus { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T data { get; set; }
    }
}
