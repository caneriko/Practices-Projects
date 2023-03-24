﻿namespace MyMvcApp.Core.DTOs
{
    public class ProductDto : BaseDto
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
