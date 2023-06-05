using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Core.Entities
{
    public class Article : EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string? PictureUrl { get; set; }  


    }
}
