using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{

    public class SaleDetail
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        // Subtotal calculado a partir de Quantity * UnitPrice
        public decimal Subtotal => Quantity * UnitPrice;
    }

}
