using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public string Description { get; set; } = null!;

        public DateTime PublishDate { get; set; }

        public string? ImagePath { get; set; }


        public Writer Writer { get; set; } = null!;

        public int WriterId { get; set; }

        [ForeignKey("CategoryId")] 
        public BookCategory Category { get; set; } = null!;

        public int CategoryId { get; set; }

    }
}
