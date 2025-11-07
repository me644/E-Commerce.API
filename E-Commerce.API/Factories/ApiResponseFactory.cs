using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace E_Commerce.API.Factories
{
    public class ApiResponseFactory
    {


        public  static IActionResult  CustomValidationErrorResponse(ActionContext context) {



            var errros = context.ModelState.Where(E => E.Value?.Errors.Any()==true).Select

                    (e => new validationsErrors() { Field = e.Key, errors = e.Value?.Errors.Select(e => e.ErrorMessage)??[] });


            return  new    BadRequestObjectResult( new ValidationErrorDeatiles ()
            {

                Errors=errros,


                
            });


        }
    }
}
