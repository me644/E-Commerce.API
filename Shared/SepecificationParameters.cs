using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Shared
{

    public class SepecificationParameters
    {

        public const int MaxPageSize = 10;
        public const int defulat = 5;

        public int? Brand_id { get; set;}
        public int? type_id { get; set; }
        public OrderEnum sort {  get; set; }
        public int orderEnum { get; set; }

        public int PagaIndex { get; set; }

        private int _PageSize = defulat;

        public int PageSize { get {return _PageSize; } set { _PageSize = value > MaxPageSize ? value : defulat; } }

    }

}
