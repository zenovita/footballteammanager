using System;
using System.Collections.Generic;
using System.Text;

namespace Staj.Domain
{
    public class UserDomainModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
        public Nullable<int> myTeam { get; set; }
    }
}
