
using System;

namespace NexoStock.Class
{
    public class ProductMovementClass
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Type { get; set; }

        public int ReferenceId { get; set; }

        public DateTime MovementDate { get; set; }
    }
}
