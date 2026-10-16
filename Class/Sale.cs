using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{

    public class Sale
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Total { get; set; }

        public bool State { get; set; } = true;
    }
}
