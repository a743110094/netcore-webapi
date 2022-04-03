using System;
using System.Collections.Generic;

namespace demo.Models.vo
{
    public class BaseListInput
    {
        public int PageSize { get; set; }

        public int PageNum { get; set; }

        public Dictionary<string, DateTime> Params { get; set; }
    }


}
