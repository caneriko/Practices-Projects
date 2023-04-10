using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; } 

        public string Content { get; set; } 

        public AppUser User { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; } 

        public int CategoryId { get; set; } 


    }
}
