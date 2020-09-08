using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGamesStore.Models 
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public virtual OrderLineModel OrderLine { get; set; }
    }
}