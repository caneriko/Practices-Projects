﻿using BookSaw.Core.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels.Book
{
    public class BookViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string? PictureUrl { get; set; }  

        public int? CategoryId { get; set; }

        public int? WriterId { get; set; }



    }
}
