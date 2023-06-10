using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Entities
{
    public class Article : EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string? CreatedBy { get; set; } = "Undefined";

        public string? PictureUrl { get; set; } = "default_book_image.jpg";


    }
}
