using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ValidationErrorDeatiles
    {

        public int statusCode { get; set; }

        public string Error_Message { get; set; }   


        public IEnumerable<validationsErrors> Errors { get; set; }   = [];
    }
}
