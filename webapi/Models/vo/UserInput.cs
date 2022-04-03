using System;
using System.Collections.Generic;

namespace demo.Models.vo
{
    public class UserListInput:BaseListInput
    {
        public string LoginName { get; set; }

        public string NickName { get; set; }        
        public string RealName { get; set; }            
    }


}
