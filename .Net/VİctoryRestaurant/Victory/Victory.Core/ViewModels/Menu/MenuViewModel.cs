using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.Category;
using Victory.Core.ViewModels.Product;

namespace Victory.Core.ViewModels.Menu
{
    public class MenuViewModel
    {
        public List<ProductListViewModel> Products { get; set; }

        public List<CategoryListViewModel> Categories { get; set; }
    }
}
