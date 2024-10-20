using System;

namespace PetStoreAcceptanceTests.Models
{
    internal class Order
    {
        public long Id { get; set; }
        public long PetId { get; set; }
        public int Quantity { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus Status { get; set; }
        public bool Complete { get; set; }
    }

    public enum OrderStatus
    {
        Placed,
        Approved,
        Delivered
    }
}

