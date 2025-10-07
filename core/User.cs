using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonewkakaxi.core
{
    public class User
    {
        public int Id { get; set; }
        public Role RoleString { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public enum Role
    {
        ADMIN,
        USER,
        MANAGER,
        GUEST
    }
}


