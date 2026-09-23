using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{
    public class ProductClass
    {
        //Atributes
        public string Name { get; set; } = null;

        public string Cod { get; set; } = null;

        public string Description { get; set; } = null;

        public bool State { get; set; } = true;

        public decimal SalePrice { get; set; } = 0;

        public int Stock { get; set; } = 1;

        public int StockMin { get; set; } = 1;

        //Forean Key
        public int CategoryId { get; set; } = 0;

        public int BrandId { get; set; } = 0;

        public int  ProviderId { get; set; } = 0;

        //List of images
        public List<string> Images { get; set; } = new List<string>();
    }
}
