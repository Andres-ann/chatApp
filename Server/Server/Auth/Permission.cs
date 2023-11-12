using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Auth
{
    public class Permission
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Permission(string name, string description)
        {
            Name = name;
            Description = description;  
        }
    }
}
