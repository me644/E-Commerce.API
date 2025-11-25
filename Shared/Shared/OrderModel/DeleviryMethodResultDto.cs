using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared.OrderModel
{
    public   class DeleviryMethodResultDto
    {
       public int Id { get; set; }
        public string shortame { get; set; }

        public string Discription { get; set; }
        public string Price { get; set; }



        public string DeleviryTime {  get; set; }

    }
}
