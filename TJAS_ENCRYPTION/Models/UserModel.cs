using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJAS_ENCRYPTION.Models
{
    public class UserList : List<UserModel> { }
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string[,,] array3D { get; set; }
    }
}
