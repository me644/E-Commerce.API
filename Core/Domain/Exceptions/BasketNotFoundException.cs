using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BasketNotFoundException : NotFoundExceptions
    {

        public BasketNotFoundException(string id) : base($"this Cart with this {id} not found")
        {


        }
        
    }
}
