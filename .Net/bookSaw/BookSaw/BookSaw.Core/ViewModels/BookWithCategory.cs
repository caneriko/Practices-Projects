using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Core.ViewModels
{
    public class BookWithCategory : BookModel
    {
        public CategoryModel Category { get; set; }
    }
}
