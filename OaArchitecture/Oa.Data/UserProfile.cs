using System;
using System.Collections.Generic;

namespace Oa.Data
{
    public partial class UserProfile:BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual User IdNavigation { get; set; }
    }
}
