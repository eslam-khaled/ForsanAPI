using G2K.AlForsan.Base.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static G2K.AlForsan.Base.DTOs.BaseDto;
using static G2K.AlForsan.Base.Enums.ErrorCodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G2K.AlForsan.API
{

    public abstract class APIControllerBase : ControllerBase
    {
        //[SwaggerResponse(typeof(DtoBaseResponse))]
        protected internal async Task<IActionResult> HandledCall<T>(BaseRequestDto request, Func<ValidationModel> validationFunction,
    Func<T> businessFunction, Action<T> onSuccess = null) where T : BaseResponseDto, new()
        {

            var statusCode = HttpStatusCode.OK;
            T result;
            {
                var validationModel = validationFunction();
                if (validationModel.ErrorCode == ErrorCode.None)
                {
                    try
                    {
                        result = businessFunction();
                        if (result.ValidationModel == null)
                            result.ValidationModel = validationModel;
                        else
                        {
                            statusCode = HttpStatusCode.BadRequest;
                        }
                        onSuccess?.Invoke(result);
                    }
                    catch (Exception e)
                    {
                        var exp = e;
                        while (exp.InnerException != null)
                        {
                            exp = exp.InnerException;
                        }
                        result = new T
                        {
                            ValidationModel = ValidationModel.Exception(exp.Message)
                        };
                        statusCode = HttpStatusCode.InternalServerError;
                    }
                }
                else
                {
                    result = new T
                    {
                        ValidationModel = validationModel
                    };
                    statusCode = HttpStatusCode.BadRequest;
                }
            }
            return StatusCode((int)statusCode, result);
        }
    }
}
