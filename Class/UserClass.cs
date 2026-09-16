using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{
    internal class UserClass
    {

        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string DNI { get; set; } 
        public string Email { get; set; } 
        public string Tel { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Rol { get; set; }
        public bool State { get; set; }

        
    }
}
