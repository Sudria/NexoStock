using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{
    public class UserClass
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Dni { get; set; } 
        public string Email { get; set; } 
        public string Tel { get; set; } 
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Rol { get; set; }
        public bool State { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
