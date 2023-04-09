using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.Models
{
    public class Quotation
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public string? Owner { get; set; }

    }
}
