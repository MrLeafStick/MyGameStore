using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGamesStore.Models 
{
    public class ShipmentModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
    }
}