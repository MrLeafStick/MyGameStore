using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGameStore.Models
{
    public class GameModelMongo
    {
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get;set;}

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Display(Name = "Units Sold")]
        public int UnitsSold { get; set;}
    }
}
