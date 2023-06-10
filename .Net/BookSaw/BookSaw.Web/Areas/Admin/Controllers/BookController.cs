using BookSaw.Core.Services;
using BookSaw.Core.ViewModels.Book;
using BookSaw.Service.Messages;
using CategorySaw.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using WriterSaw.Core.Services;

namespace BookSaw.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;
        private readonly IToastNotification _toast;


        public BookController(IBookService bookService, ICategoryService categoryService, IWriterService writerService, IToastNotification toast)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _writerService = writerService;
            _toast = toast;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _bookService.GetAllAsync();

            return View(viewModel);
        }

        [HttpGet] 
        public async Task<IActionResult> Update(int id)
        {
            var categories = await _categoryService.GetAllViewModelsAsync();

            var writers = await _writerService.GetAllViewModelsAsync();

  
            var viewModel = await _bookService.GetUpdateViewModelAsync(id);

            ViewBag.Kategori = new SelectList(categories, "Id", "Name", viewModel.CategoryId);

            ViewBag.Writer = new SelectList(writers, "Id", "FullName", viewModel.WriterId);



            return View(viewModel); 
        }

        [HttpPost]

        public async Task<IActionResult> Update(BookUpdateViewModel viewModel)
        {
            var categories = await _categoryService.GetAllViewModelsAsync();

            var writers = await _writerService.GetAllViewModelsAsync();

            ViewBag.Kategori = new SelectList(categories, "Id", "Name", viewModel.CategoryId);

            ViewBag.Writer = new SelectList(writers, "Id", "FullName", viewModel.WriterId);

            var validation = await _bookService.ValidateUpdateModelAsync(viewModel);

            if (validation.IsValid)
            {
                _toast.AddSuccessToastMessage(ResultMessage.Book.Update(viewModel.Name));

                await _bookService.UpdateAsync(viewModel);

                return RedirectToAction("index", "book", new { Area = "Admin" });


            }

            return View(viewModel);
        }

        [HttpGet]

        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllViewModelsAsync();

            ViewBag.Kategori = new SelectList(categories, "Id", "Name");

            var writers = await _writerService.GetAllViewModelsAsync();

            ViewBag.Writer = new SelectList(writers, "Id", "FullName");


            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(BookAddViewModel viewModel)
        {
            var writers = await _writerService.GetAllViewModelsAsync();

            ViewBag.Writer = new SelectList(writers, "Id", "FullName");

            var categories = await _categoryService.GetAllViewModelsAsync();

            ViewBag.Kategori = new SelectList(categories, "Id", "Name", viewModel.CategoryId);


            var validation = await _bookService.ValidateAddModelAsync(viewModel);

            if (validation.IsValid)
            {

              await  _bookService.AddAsync(viewModel);

                _toast.AddSuccessToastMessage(ResultMessage.Book.Add(viewModel.Name));

                return RedirectToAction("index", "book", new { Area = "Admin" });

            }



            return View(viewModel);

        }



        public async Task<IActionResult> SafeDelete(int id)
        {
            await _bookService.SafeDeleteAsync(id);

            _toast.AddSuccessToastMessage("");

            return RedirectToAction("index", "book", new { Area = "Admin" });

        }

    }
}
