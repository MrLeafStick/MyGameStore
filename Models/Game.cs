using System;
using System.ComponentModel.DataAnnotations;

namespace MyGamesStore.Models 
{
    public class Game
    {
        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public decimal Price { get; set; }
    }
}