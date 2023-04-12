using BookSaw.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels
{
    public class BookModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsDiscounted { get; set; }
        public decimal? DiscountedPrice { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; } = null!;

        public DateTime PublishDate { get; set; }

        public string? ImagePath { get; set; }

        public int WriterId { get; set; }


        public int CategoryId { get; set; }
    }
}
