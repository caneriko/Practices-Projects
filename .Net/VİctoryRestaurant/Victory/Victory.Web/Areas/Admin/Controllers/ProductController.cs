using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using NToastNotify;
using Victory.Core.Services;
using Victory.Core.ViewModels.Product;
using Victory.Service.ToastrMessages;

namespace Victory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categorytService;
        private readonly IToastNotification _toast;


        public ProductController(IProductService productService, IToastNotification toast, ICategoryService categorytService)
        {
            _productService = productService;
            _toast = toast;
            _categorytService = categorytService;
        }


        public IActionResult Index()
        {
            return RedirectToAction("Index", "menu", new { Area = "Admin" });

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _categorytService.GetAllActiveCategoriesAsync();

            var viewModel = await _productService.GetByIdAsync(id);

            return View(viewModel);
        }


        [HttpPost]

        public async Task<IActionResult> Update(UpdateProductViewModel viewModel)
        {
            ViewBag.Categories = await _categorytService.GetAllActiveCategoriesAsync();

            if (ModelState.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Product.Update(viewModel.Name), new ToastrOptions { Title = "Başarılı" });

                await _productService.UpdateAsync(viewModel);
                return RedirectToAction("Index", "Product");
            }

            return View(viewModel);
        }

        [HttpGet]

        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _categorytService.GetAllActiveCategoriesAsync();

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Category.Add(viewModel.Name), new ToastrOptions { Title = "Başarılı" });

                await _productService.AddAsync(viewModel);
                return RedirectToAction("index", "Product");
            }

            return View(viewModel);
        }


        public async Task<IActionResult> SafeDelete(int id)
        {
            await _productService.SafeDeleteAsync(id);
            var viewModel = await _productService.GetByIdAsync(id);
            _toast.AddSuccessToastMessage(ResultMessage.Category.Add(viewModel.Name), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }

    }
}

