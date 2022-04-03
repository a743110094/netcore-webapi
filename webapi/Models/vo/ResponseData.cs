using System;

namespace demo.Models.vo
{
    public class ResponseData<T>
    {
        public String Message { get; set; } = "success";

        public int Code { get; set; } = 200;

        public int Total { get; set; }

        public T Data { get; set; }
    }

   
}
