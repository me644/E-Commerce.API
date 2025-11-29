using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationExceptions:Exception
    {
        public  IEnumerable<string> Errors { get; set; }

        public  ValidationExceptions(IEnumerable<string> errors) : base("validation Flaild") {

            Errors = errors;
        }
    }
}
