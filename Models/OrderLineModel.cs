using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGamesStore.Models 
{
    public class OrderLineModel
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public virtual OrderModel Order { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}