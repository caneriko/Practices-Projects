using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victory.Core.ViewModels.Menu;

namespace Victory.Core.Services
{
    public interface IMenuService
    {
         Task<MenuViewModel> GetMenuAsync();
    }
}
