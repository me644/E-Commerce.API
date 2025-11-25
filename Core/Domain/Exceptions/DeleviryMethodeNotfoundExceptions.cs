using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeleviryMethodeNotfoundExceptions : NotFoundExceptions
    {
        public DeleviryMethodeNotfoundExceptions(int id) : base($"this Method with id{id} Not found ")
        {



        }
    }
}
