using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGamesStore.Models 
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal BaseTotal { get; set; }

        [ForeignKey("OrderId")]
        public ICollection<OrderLineModel> OrderLines;
        [ForeignKey("OrderId")]
        public ICollection<ShipmentModel> Shipments;
    }
}