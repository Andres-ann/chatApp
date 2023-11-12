using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Auth
{
    public class Role
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Permission> Permissions { get; set; }

        public Role(string name)
        {
            Name = name;
            Permissions = new List<Permission>();
        }
    }
}
