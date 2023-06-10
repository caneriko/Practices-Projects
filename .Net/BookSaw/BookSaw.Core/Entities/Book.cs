using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string? PictureUrl { get; set; } = "default_book_image.jpg";

        public Category? Category { get; set; }

        public int? CategoryId { get; set; }

        public Writer? Writer { get; set; }

        public int? WriterId { get; set; }

    }
}
