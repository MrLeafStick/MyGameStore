using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGamesStore.Models 
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        [ForeignKey("CustomerId")]
        public ICollection<OrderModel> orders { get; set; }
    }
}