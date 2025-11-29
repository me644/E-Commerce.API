using Domain.Exceptions;
using Microsoft.VisualBasic;
using Shared.ModelErros;
using System.Net;
using System.Reflection.Metadata;

namespace E_Commerce.API.MIddleWares
{
    public class GlobalHandllingMiddleWare
    {
        #region MyRegion

        //  when  the app  make  .Run()  all pipeplines  is  ready  and with first request
        //  request is passes  through  all middleWares  by  what?  Each middleWare  has Fucntion
        //  // called {Invoke}  thsi fcuntion  must  is same signture  in all midellWares
        //and  all  midellWares  has  delegate  called _next  to passes request to  the next
        //midellWare

        #endregion


        private readonly RequestDelegate _next;

        private readonly  ILogger<GlobalHandllingMiddleWare>  _logger;


        public GlobalHandllingMiddleWare(RequestDelegate next, ILogger<GlobalHandllingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async  Task InvokeAsync(HttpContext  context )
        {

            try
            {
                await _next(context);

                if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    await NotFoundApi(context);
                }
              
               
            }

            catch(Exception ex)
            {
                _logger.LogError($"something went wrong>>>>>>???????>>>>>>>>>>>>>>{ex}");

                await HandlleExceptionAsync(context, ex);
            }
        }


        public async Task NotFoundApi(HttpContext context)
        {


            context.Response.ContentType = "application/json";

         
            var Response = new Errorr_Detailes()
            {
                statusCode = StatusCodes.Status404NotFound,
                message = $"the endPoint {context.Request.Path} not found"
            }.ToString();

            await context.Response.WriteAsync(Response);
        }

        private async Task HandlleExceptionAsync(HttpContext context, Exception ex)
        {

            var reponse = new Errorr_Detailes()
            {

                message = ex.Message

            };


            context.Response.StatusCode = ex switch {


                ProductNotFoundException => StatusCodes.Status404NotFound,
                ValidationExceptions validation =>handlling_validations(validation.Errors,reponse),
                (_) => StatusCodes.Status500InternalServerError


            };

            context.Response.ContentType = "application/json";

         
           await   context.Response.WriteAsync(reponse.ToString());
        }

        public int handlling_validations(IEnumerable<string> errors, Errorr_Detailes reponse)
        {
            reponse.Errors = errors;

            return StatusCodes.Status404NotFound;

        }
    }
}
