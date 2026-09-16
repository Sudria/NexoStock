using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexoStock.Class
{
    internal class ProductClass
    {
        //Atributes
        public string Name { get; set; }

        public string Cod { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }

        public decimal SalePrice { get; set; }

        public int Stock { get; set; }

        public int StockMin { get; set; }

        //Forean Key
        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public int  ProviderId { get; set; }

        //List of images
        public List<string> Imagenes { get; set; } = new List<string>();
    }
}
