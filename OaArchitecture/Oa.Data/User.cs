using System;
using System.Collections.Generic;

namespace Oa.Data
{
    public partial class User:BaseEntity
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
