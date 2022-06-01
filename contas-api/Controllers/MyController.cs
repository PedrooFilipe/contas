using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using contas_api_model.Model;

namespace bills_api.Controllers
{
    public class MyController : ControllerBase
    {
        public RestResponse<T> GetRestResponseOk<T>(T data, Pagination pagination, string currentToken) where T : class
        {
            return new RestResponse<T>
            {
                Data = data,
                Message = "Success!",
                Pagination = pagination,
                ResponseCode = 200,
                Token = GenerateRefreshToken(currentToken)
            };
        }

        public RestResponse<T> GetRestResponseError<T>(string currentToken) where T : class
        {
            return new RestResponse<T>
            {
                Message = "Error!",
                ResponseCode = 500,
                Token = GenerateRefreshToken(currentToken)
            };
        }
        
        public RestResponse<T> GetRestResponseWarning<T>(string customMessage, string currentToken) where T : class
        {
            return new RestResponse<T>
            {
                Message = customMessage,
                ResponseCode = 400,
                Token = GenerateRefreshToken(currentToken)
            };
        }

        public string GenerateRefreshToken(string currentToken)
        {
            return "sdajhsdaisjdjahjsdg";
        }

        public int GetIdFromToken(string currentToken)
        {
            return 1;
        }
    }
}
