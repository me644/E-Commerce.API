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
            //1  change Status
            // context.Response.StatusCode=(int) HttpStatusCode .InternalServerError;
            // this is can be  resuable  as



            context.Response.StatusCode = ex switch {


                ProductNotFoundException => StatusCodes.Status404NotFound,
                (_) => StatusCodes.Status500InternalServerError


            };
            //2  content type
            context.Response.ContentType = "application/json";

            //3 write   repsonse in body

            var Body = new Errorr_Detailes()
            {
                
                statusCode = context.Response.StatusCode,
                message=ex.Message

            }.ToString();
            //1 st methode//  context.Response.WriteAsJsonAsync(Body);
            //  methode 2 iss better  to convert  it  once  and resubale it

           await   context.Response.WriteAsync(Body);
        }
    }
}
