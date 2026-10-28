using System;

namespace NexoStock.Class
{
    internal class PurchaseClass
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Total { get; set; }

        // Datos adicionales para mostrar en el DataGridView
        public string ProviderName { get; set; }
        public string UserName { get; set; }
        public int TotalProducts { get; set; }
    }
}