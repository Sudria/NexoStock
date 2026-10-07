using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{
    public class ProviderClass
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Cuit { get; set; }
        
        public string Email { get; set; }
        
        public string Tel { get; set; }

        public bool State { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public String FullName
        {
            get { return $"{Name} {Surname} - {Cuit}"; }
        }

    }
}
