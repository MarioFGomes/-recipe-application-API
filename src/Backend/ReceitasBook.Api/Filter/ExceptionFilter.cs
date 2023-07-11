using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReceitasBook.Comunicacao.Response;
using ReceitasBook.Exceptions;
using ReceitasBook.Exceptions.ExceptionsBase;
using System.Net;

namespace ReceitasBook.Api.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
       if(context.Exception is ReceitasBookException)
        {
            TratarReceitasBookException(context);
        }
        else
        {
            LancarErroDesconhecido(context);
        }
    }

    public void TratarReceitasBookException(ExceptionContext context)
    {
        if(context.Exception is ValidationErrorEceptions)
        {
            TratarValidationErrorEceptions(context);
        }
    }

    private void TratarValidationErrorEceptions(ExceptionContext context)
    {
        var ErrorValidation=context.Exception as ValidationErrorEceptions;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ResponseErrorJson(ErrorValidation.ErrorsList));
    }

    public void LancarErroDesconhecido(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageError.Erro_Desconhecido));
    }
}
