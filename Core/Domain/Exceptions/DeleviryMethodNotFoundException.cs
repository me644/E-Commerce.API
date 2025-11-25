using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeleviryMethodNotFoundException : NotFoundExceptions
    {
        public DeleviryMethodNotFoundException(int message) : base($"DELVERIY WITH_{message}_ NOT FOUND!!")
        {
        }
    }
}

