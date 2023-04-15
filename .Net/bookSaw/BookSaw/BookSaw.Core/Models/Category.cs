﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public ICollection<Book> Books { get; set; }

        public ICollection<Article> Articles { get; set; }





    }
}