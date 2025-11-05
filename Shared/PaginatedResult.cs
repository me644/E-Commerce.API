using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PaginatedResult<T>
    {


        public   int Page_Index {  get; set; }

        public int Total { get; set; }

        public int Count { get; set; }

        public  IEnumerable<T>Data { get; set; }
    }
}
