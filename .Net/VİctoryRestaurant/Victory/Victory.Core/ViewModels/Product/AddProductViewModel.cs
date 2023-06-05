using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.Enums;

namespace Victory.Core.ViewModels.Product
{
    public class AddProductViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public IFormFile? Photo { get; set; }

        public string? PictureUrl { get; set; }

        public ImageType ImageType { get; set; } = ImageType.Article;

    }
}
