using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Shared
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
